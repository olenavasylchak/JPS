using AutoMapper;
using JPS.Domain.Entities.Entities;
using JPS.Infrastructure.Context;
using JPS.Services.Constants;
using JPS.Services.DTO.DTOs.QuestionSectionDTOs;
using JPS.Services.DTO.DTOs.QuestionSectionDTOs.UpdateDTOs;
using JPS.Services.Exceptions;
using JPS.Services.Helpers;
using JPS.Services.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPS.Services.Services
{
	/// <inheritdoc/>
	public class QuestionSectionService : IQuestionSectionService
	{
		private readonly IMapper _mapper;
		private readonly JPSContext _context;

		public QuestionSectionService(IMapper mapper, JPSContext jpsContext)
		{
			_context = jpsContext;
			_mapper = mapper;
		}

		/// <inheritdoc/>
		public async Task<IEnumerable<QuestionSectionDTO>> GetAllSectionsByPollIdAsync(int pollId)
		{
			await ValidateDoesPollExistAsync(pollId);
			var allQuestionSectionsInPoll = await _context.QuestionSections
				.Where(section => section.PollId == pollId)
				.AsNoTracking()
				.ToListAsync();

			var questionSectionDTOs = _mapper.Map<IEnumerable<QuestionSectionDTO>>(allQuestionSectionsInPoll);
			return questionSectionDTOs;
		}

		/// <inheritdoc/>
		public async Task<IEnumerable<QuestionSectionDTO>> GetAllSectionsWithQuestionsByPollIdAsync(int pollId)
		{
			await ValidateDoesPollExistAsync(pollId);
			var allQuestionSectionsWithQuestionsInPoll = await _context.QuestionSections
				.Include(section => section.Questions)
				.Where(section => section.PollId == pollId)
				.AsNoTracking()
				.ToListAsync();

			var questionSectionWithQuestionsDTOs =
				_mapper.Map<IEnumerable<QuestionSectionDTO>>(allQuestionSectionsWithQuestionsInPoll);
			return questionSectionWithQuestionsDTOs;
		}

		/// <inheritdoc/>
		public async Task<QuestionSectionDTO> CreateQuestionSectionAsync(CreateQuestionSectionDTO createQuestionSectionDTO)
		{
			await ValidateDoesPollExistAsync(createQuestionSectionDTO.PollId);

			await ValidateIsQuestionSectionOrderUniqueAsync(createQuestionSectionDTO.Order, createQuestionSectionDTO.PollId);

			var questionSectionToCreate = _mapper.Map<QuestionSectionEntity>(createQuestionSectionDTO);
			var createdQuestionSection = await _context.AddAsync(questionSectionToCreate);
			await _context.SaveChangesAsync();

			var createdQuestionSectionDTO = _mapper.Map<QuestionSectionDTO>(createdQuestionSection.Entity);
			return createdQuestionSectionDTO;
		}

		/// <inheritdoc/>
		public async Task<QuestionSectionDTO> UpdateQuestionSectionTitleAsync(
			int sectionId, UpdateQuestionSectionTitleDTO updateQuestionSectionDTO)
		{
			var questionSectionToUpdate = await _context.QuestionSections
				.SingleOrDefaultAsync(section => section.Id == sectionId);

			ValidationHelper.ValidateDoesItemExist(
			questionSectionToUpdate, ExceptionMessageConstants.QuestionSectionNotFoundMessage);

			questionSectionToUpdate.Title = updateQuestionSectionDTO.Title;
			await _context.SaveChangesAsync();

			var updatedQuestionSectionDTO = _mapper.Map<QuestionSectionDTO>(questionSectionToUpdate);
			return updatedQuestionSectionDTO;
		}

		/// <inheritdoc/>
		public async Task<IEnumerable<QuestionSectionDTO>> UpdateQuestionSectionOrdersAsync(
			IEnumerable<UpdateQuestionSectionOrderDTO> updateQuestionSectionDTOs)
		{
			var sectionsToUpdateIds = updateQuestionSectionDTOs.Select(section => section.Id);

			ValidationHelper.ValidateContainsCollectionDuplicates(sectionsToUpdateIds,
				ExceptionMessageConstants.IdDuplicatedMessage);
			ValidationHelper.ValidateContainsCollectionDuplicates(
				updateQuestionSectionDTOs.Select(section => section.Order),
				ExceptionMessageConstants.OrderDuplicatedMessage);
			await ValidateAreAllQuestionSectionsExist(sectionsToUpdateIds);

			var firstSectionId = sectionsToUpdateIds.First();
			var poll = await _context.Polls
				.Include(poll => poll.QuestionSections)
				.FirstOrDefaultAsync(poll => poll.QuestionSections.Any(section => section.Id == firstSectionId));

			ValidationHelper.ValidateAreListsCountsEqual(poll.QuestionSections, updateQuestionSectionDTOs,
				ExceptionMessageConstants.PollContainsLessOrMoreSections);
			ValidateAllSectionsBelongSamePoll(poll, updateQuestionSectionDTOs);

			poll.QuestionSections.ForEach(toUpdateQuestionSection =>
				toUpdateQuestionSection.Order = updateQuestionSectionDTOs
					.First(section => section.Id == toUpdateQuestionSection.Id).Order);

			await _context.SaveChangesAsync();

			var updatedQuestionSectionDTOs = _mapper.Map<IEnumerable<QuestionSectionDTO>>(poll.QuestionSections);
			return updatedQuestionSectionDTOs;
		}

		/// <inheritdoc/>
		public async Task<QuestionSectionDTO> UpdateQuestionSectionDescriptionAsync(
			int sectionId, UpdateQuestionSectionDescriptionDTO updateQuestionSectionDTO)
		{
			var questionSectionToUpdate = await _context.QuestionSections
				.SingleOrDefaultAsync(section => section.Id == sectionId);

			ValidationHelper.ValidateDoesItemExist(
				questionSectionToUpdate, ExceptionMessageConstants.QuestionSectionNotFoundMessage);

			questionSectionToUpdate.Description = updateQuestionSectionDTO.Description;
			await _context.SaveChangesAsync();

			var updatedQuestionSectionDTO = _mapper.Map<QuestionSectionDTO>(questionSectionToUpdate);
			return updatedQuestionSectionDTO;
		}

		/// <inheritdoc/>
		public async Task DeleteQuestionSectionAsync(int sectionId)
		{
			var questionSection = await _context.QuestionSections
				.Include(section => section.Poll)
					.ThenInclude(poll => poll.QuestionSections)
				.Include(section => section.Questions)
				.FirstOrDefaultAsync(section => section.Id == sectionId);

			ValidationHelper.ValidateDoesItemExist(questionSection,
				ExceptionMessageConstants.QuestionSectionNotFoundMessage);
			ValidateDoesQuestionSectionContainQuestions(questionSection);
			ValidateDoSectionsNumberInPollMoreThanMinimal(questionSection);

			_context.Remove(questionSection);
			await _context.SaveChangesAsync();
		}

		private void ValidateAllSectionsBelongSamePoll(PollEntity poll,
			IEnumerable<UpdateQuestionSectionOrderDTO> questionSectionDTOs)
		{
			var doAllSectionsBelongSamePoll = poll.QuestionSections
				   .All(section => questionSectionDTOs
					   .Any(sectionDTO => sectionDTO.Id == section.Id));

			if (!doAllSectionsBelongSamePoll)
			{
				throw new ArgumentException(ExceptionMessageConstants.InvalidSectionsToUpdateOrdersMessage);
			}
		}

		private void ValidateDoSectionsNumberInPollMoreThanMinimal(QuestionSectionEntity questionSection)
		{
			var numberOfQuestionSectionsInPoll = questionSection.Poll.QuestionSections.Count();
			if (numberOfQuestionSectionsInPoll <= ServiceConstants.MinimalNumberOfQuestionSectionInPollValue)
			{
				throw new InvalidOperationException(ExceptionMessageConstants.NotAllowedToDeleteLastSectionMessage);
			}
		}

		private void ValidateDoesQuestionSectionContainQuestions(QuestionSectionEntity questionSection)
		{
			var doesQuestionSectionContainQuestions = questionSection.Questions.Any();
			if (doesQuestionSectionContainQuestions)
			{
				throw new InvalidOperationException(ExceptionMessageConstants.NotAllowedToDeleteSectionContainsQuestionsMessage);
			}
		}

		private async Task ValidateDoesPollExistAsync(int pollId)
		{
			var doesPollExist = await _context.Polls.AnyAsync(poll => poll.Id == pollId);
			if (!doesPollExist)
			{
				throw new NotFoundException(ExceptionMessageConstants.PollNotFoundMessage);
			}
		}

		private async Task ValidateIsQuestionSectionOrderUniqueAsync(int order, int pollId)
		{
			var hasQuestionSectionSameOrders = await _context.QuestionSections
				.AnyAsync(section => section.PollId == pollId && section.Order == order);
			if (hasQuestionSectionSameOrders)
			{
				throw new ArgumentException(ExceptionMessageConstants.ExistingOrderForSectionMessage);
			}
		}

		private async Task ValidateAreAllQuestionSectionsExist(IEnumerable<int> sectionIds)
		{
			var dbSectionIdsCount = await _context.QuestionSections.CountAsync(section => sectionIds.Contains(section.Id));
			if (dbSectionIdsCount != sectionIds.Count())
			{
				throw new NotFoundException(ExceptionMessageConstants.QuestionSectionNotFoundMessage);
			}
		}
	}
}