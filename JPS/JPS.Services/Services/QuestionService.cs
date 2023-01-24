using AutoMapper;
using JPS.Domain.Entities.Entities;
using JPS.Infrastructure.Context;
using JPS.Services.Constants;
using JPS.Services.DTO.DTOs.QuestionDTOs;
using JPS.Services.DTO.DTOs.QuestionDTOs.UpdateDTOs;
using JPS.Services.Enums;
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
	/// <summary>
	/// Implements IQuestionService interface methods. 
	/// </summary>
	public class QuestionService : IQuestionService
	{
		private readonly JPSContext _context;
		private readonly IMapper _mapper;

		public QuestionService(JPSContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		/// <inheritdoc/>		
		public async Task<IEnumerable<QuestionDTO>> GetAllQuestionsByPollIdAsync(int pollId)
		{
			await ValidateDoesPollExistAsync(pollId);

			var questionEntities = await _context.Questions
				.Where(question => question.QuestionSection.PollId == pollId).AsNoTracking().ToListAsync();
			var questionDTOs = _mapper.Map<IEnumerable<QuestionDTO>>(questionEntities);
			return questionDTOs;
		}

		/// <inheritdoc/>				
		public async Task<QuestionDTO> CreateQuestionAsync(CreateQuestionDTO questionDTO)
		{
			ValidateCanQuestionHaveOtherOption(questionDTO.QuestionTypeId, questionDTO.CanHaveOtherOption);
			await ValidateDoesQuestionSectionExistAsync(questionDTO.QuestionSectionId);
			await ValidateDoesQuestionOrderUnique(questionDTO.QuestionSectionId, questionDTO.Order);

			var questionEntity = _mapper.Map<QuestionEntity>(questionDTO);
			var result = await _context.Questions.AddAsync(questionEntity);
			await _context.SaveChangesAsync();

			var question = _mapper.Map<QuestionDTO>(result.Entity);
			return question;
		}

		/// <inheritdoc/>
		public async Task<QuestionDTO> CopyQuestionAsync(int id)
		{
			var questionEntity = await _context.Questions
				.Include(question => question.Options)
				.Include(question => question.OptionRows)
				.FirstOrDefaultAsync(question => question.Id == id);

			ValidationHelper.ValidateDoesItemExist(questionEntity,
				ExceptionMessageConstants.NotFoundObjectMessage);

			var questionEntityCopy = new QuestionEntity
			{
				Text = questionEntity.Text,
				QuestionSectionId = questionEntity.QuestionSectionId,
				QuestionTypeId = questionEntity.QuestionTypeId,
				IsRequired = questionEntity.IsRequired,
				Comment = questionEntity.Comment,
				ImageUrl = questionEntity.ImageUrl,
				VideoUrl = questionEntity.VideoUrl,
				Order = await SetQuestionOrder(questionEntity.QuestionSectionId)
			};

			if (questionEntity.OptionRows.Count > 0)
			{
				questionEntityCopy.OptionRows = CopyHelper.CopyOptionRows(questionEntity.OptionRows);
			}
			if (questionEntity.Options.Count > 0)
			{
				questionEntityCopy.Options = CopyHelper.CopyOptions(questionEntity.Options);
			}

			await _context.Questions.AddAsync(questionEntityCopy);
			await _context.SaveChangesAsync();

			var questionDTO = _mapper.Map<QuestionDTO>(questionEntityCopy);
			return questionDTO;
		}

		private async Task<int> SetQuestionOrder(int questionSectionId)
		{
			var questionOrder = await _context.Questions
				.Where(question => question.QuestionSectionId == questionSectionId)
				.MaxAsync(question => question.Order) + 1;
			return questionOrder;
		}

		/// <inheritdoc/>			
		public async Task<QuestionDTO> UpdateQuestionTextAsync(int id, UpdateQuestionTextDTO questionDTO)
		{
			var questionEntity = await _context.Questions
				.Include(question => question.Answers)
				.SingleOrDefaultAsync(question => question.Id == id);

			ValidationHelper.ValidateDoesItemExist(
				questionEntity, ExceptionMessageConstants.NotFoundObjectMessage);
			ValidateQuestionHasNoAnswersAsync(questionEntity);

			questionEntity.Text = questionDTO.Text;
			await _context.SaveChangesAsync();

			var updatedQuestionDTO = _mapper.Map<QuestionDTO>(questionEntity);
			return updatedQuestionDTO;
		}

		/// <inheritdoc/>			
		public async Task<IEnumerable<QuestionDTO>> UpdateQuestionsOrderAsync(
			IEnumerable<UpdateQuestionOrderDTO> questionDTOs)
		{
			var questionsToUpdateIds = questionDTOs.Select(question => question.Id);
			ValidationHelper.ValidateContainsCollectionDuplicates(questionsToUpdateIds,
				ExceptionMessageConstants.IdDuplicatedMessage);

			ValidateContainsQuestionOrderInSectionDuplicates(questionDTOs);
			await ValidateAreAllQuestionsExistAsync(questionsToUpdateIds);

			var questionsToUpdateSectionIds = questionDTOs
				.Select(question => question.SectionId).Distinct();
			await ValidateAreAllSectionsExistAsync(questionsToUpdateSectionIds);

			var firstQuestionSectionId = questionDTOs.First().SectionId;
			var pollEntity = await _context.Polls
				.Include(poll => poll.QuestionSections)
					.ThenInclude(section => section.Questions)
				.FirstAsync(poll =>
				poll.QuestionSections.Any(section => section.Id == firstQuestionSectionId));

			var questionEntities = pollEntity.QuestionSections.SelectMany(section => section.Questions);
			ValidationHelper.ValidateAreListsCountsEqual(questionEntities, questionDTOs,
				ExceptionMessageConstants.PollContainsLessOrMoreQuestions);

			ValidateDoesAllQuestionsBelongOnePoll(pollEntity, questionsToUpdateIds);

			ValidateDoesAllSectionsBelongOnePoll(pollEntity, questionsToUpdateSectionIds);

			questionEntities.ToList().ForEach(toUpdateQuestion =>
			{
				var appropriateQuestion = questionDTOs
					.First(question => question.Id == toUpdateQuestion.Id);
				toUpdateQuestion.Order = appropriateQuestion.Order;
				toUpdateQuestion.QuestionSectionId = appropriateQuestion.SectionId;
			});

			await _context.SaveChangesAsync();

			var updatedQuestions = _mapper.Map<IEnumerable<QuestionDTO>>(questionEntities);
			return updatedQuestions;
		}

		/// <inheritdoc/>		
		public async Task<QuestionDTO> UpdateQuestionIsRequiredAsync(int id, UpdateQuestionIsRequiredDTO questionDTO)
		{
			var questionEntity = await _context.Questions
				.Include(question => question.Answers)
				.SingleOrDefaultAsync(question => question.Id == id);

			ValidationHelper.ValidateDoesItemExist(
				questionEntity, ExceptionMessageConstants.NotFoundObjectMessage);
			ValidateQuestionHasNoAnswersAsync(questionEntity);

			questionEntity.IsRequired = questionDTO.IsRequired;
			await _context.SaveChangesAsync();

			var updatedQuestionDTO = _mapper.Map<QuestionDTO>(questionEntity);
			return updatedQuestionDTO;
		}

		/// <inheritdoc/>		
		public async Task<QuestionDTO> UpdateQuestionsFlagForOtherOptionAsync(int id, UpdateQuestionCanHaveOtherOptionDTO questionDTO)
		{
			var questionEntity = await _context.Questions
				.Include(question => question.Answers)
				.SingleOrDefaultAsync(question => question.Id == id);

			ValidationHelper.ValidateDoesItemExist(
				questionEntity, ExceptionMessageConstants.NotFoundObjectMessage);
			ValidateQuestionHasNoAnswersAsync(questionEntity);
			ValidateCanQuestionHaveOtherOption(questionEntity.QuestionTypeId, questionDTO.CanHaveOtherOption);

			questionEntity.CanHaveOtherOption = questionDTO.CanHaveOtherOption;
			await _context.SaveChangesAsync();

			var updatedQuestionDTO = _mapper.Map<QuestionDTO>(questionEntity);
			return updatedQuestionDTO;
		}

		/// <inheritdoc/>			
		public async Task<QuestionDTO> UpdateQuestionCommentAsync(int id, UpdateQuestionCommentDTO questionDTO)
		{
			var questionEntity = await _context.Questions
				.SingleOrDefaultAsync(question => question.Id == id);

			ValidationHelper.ValidateDoesItemExist(
				questionEntity, ExceptionMessageConstants.NotFoundObjectMessage);

			questionEntity.Comment = questionDTO.Comment;
			await _context.SaveChangesAsync();

			var updatedQuestionDTO = _mapper.Map<QuestionDTO>(questionEntity);
			return updatedQuestionDTO;
		}

		/// <inheritdoc/>			
		public async Task<QuestionDTO> UpdateQuestionTypeIdAsync(int id, UpdateQuestionTypeIdDTO questionDTO)
		{

			var questionEntity = await _context.Questions
				.Include(questions => questions.Options)
				.Include(questions => questions.OptionRows)
				.Include(question => question.Answers)
				.SingleOrDefaultAsync(question => question.Id == id);

			ValidationHelper.ValidateDoesItemExist(
				questionEntity, ExceptionMessageConstants.NotFoundObjectMessage);
			ValidateQuestionHasNoAnswersAsync(questionEntity);

			DeleteOptionsOnQuestionTypeUpdate(questionDTO.QuestionTypeId, questionEntity);

			questionEntity.QuestionTypeId = questionDTO.QuestionTypeId;
			await _context.SaveChangesAsync();

			var updatedQuestionDTO = _mapper.Map<QuestionDTO>(questionEntity);
			return updatedQuestionDTO;
		}

		/// <inheritdoc/>		
		public async Task<QuestionDTO> UpdateQuestionImageUrlAsync(int id, UpdateQuestionImageUrlDTO questionDTO)
		{
			var questionEntity = await _context.Questions
				.Include(question => question.Answers)
				.SingleOrDefaultAsync(question => question.Id == id);

			ValidationHelper.ValidateDoesItemExist(
				questionEntity, ExceptionMessageConstants.NotFoundObjectMessage);
			ValidateQuestionHasNoAnswersAsync(questionEntity);

			questionEntity.ImageUrl = questionDTO.ImageUrl;
			await _context.SaveChangesAsync();

			var updatedQuestionDTO = _mapper.Map<QuestionDTO>(questionEntity);
			return updatedQuestionDTO;
		}

		/// <inheritdoc/>		
		public async Task<QuestionDTO> UpdateQuestionVideoUrlAsync(int id, UpdateQuestionVideoUrlDTO questionDTO)
		{
			var questionEntity = await _context.Questions
				.Include(question => question.Answers)
				.SingleOrDefaultAsync(question => question.Id == id);

			ValidationHelper.ValidateDoesItemExist(
				questionEntity, ExceptionMessageConstants.NotFoundObjectMessage);
			ValidateQuestionHasNoAnswersAsync(questionEntity);

			questionEntity.VideoUrl = questionDTO.VideoUrl;
			await _context.SaveChangesAsync();

			var updatedQuestionDTO = _mapper.Map<QuestionDTO>(questionEntity);
			return updatedQuestionDTO;
		}

		/// <inheritdoc/>		
		public async Task DeleteQuestionAsync(int id)
		{
			var questionEntity = await _context.Questions
				.Include(question => question.Answers)
				.SingleOrDefaultAsync(question => question.Id == id);

			ValidationHelper.ValidateDoesItemExist(
				questionEntity, ExceptionMessageConstants.NotFoundObjectMessage);
			ValidateQuestionHasNoAnswersAsync(questionEntity);

			if (questionEntity.PrototypeQuestionId == questionEntity.Id)
			{
				await SetClonesNewPrototypeQuestion(questionEntity.Id);
			}

			_context.Remove(questionEntity);
			await _context.SaveChangesAsync();
		}

		private async Task ValidateDoesPollExistAsync(int pollId)
		{
			var doesPollExist = await _context.Polls.AnyAsync(poll => poll.Id == pollId);
			if (!doesPollExist)
			{
				throw new NotFoundException(ExceptionMessageConstants.PollNotFoundMessage);
			}
		}

		private void DeleteOptionsOnQuestionTypeUpdate(int questionTypeIdToUpdate, QuestionEntity questionEntity)
		{
			switch (questionTypeIdToUpdate)
			{
				case (int)QuestionTypes.MultipleChoice:
				case (int)QuestionTypes.CheckBoxes:
				case (int)QuestionTypes.Dropdown:
					if (questionEntity.QuestionTypeId == (int)QuestionTypes.MultipleChoiceGrid ||
						questionEntity.QuestionTypeId == (int)QuestionTypes.CheckboxGrid)
					{
						_context.RemoveRange(questionEntity.OptionRows);
					}

					if (questionEntity.QuestionTypeId == (int)QuestionTypes.LinearScale)
					{
						_context.RemoveRange(questionEntity.Options);
					}

					if (questionTypeIdToUpdate == (int)QuestionTypes.Dropdown)
					{
						questionEntity.CanHaveOtherOption = false;
					}

					break;
				case (int)QuestionTypes.CheckboxGrid:
				case (int)QuestionTypes.MultipleChoiceGrid:
					questionEntity.CanHaveOtherOption = false;

					if (questionEntity.QuestionTypeId == (int)QuestionTypes.LinearScale)
					{
						_context.RemoveRange(questionEntity.Options);
					}

					break;
				default:
					if (questionTypeIdToUpdate == (int)QuestionTypes.LinearScale &&
						questionEntity.QuestionTypeId == (int)QuestionTypes.LinearScale)
					{
						break;
					}

					questionEntity.CanHaveOtherOption = false;
					_context.RemoveRange(questionEntity.Options);
					_context.RemoveRange(questionEntity.OptionRows);

					break;
			}
		}

		private async Task SetClonesNewPrototypeQuestion(int id)
		{
			var questionsToBeUpdated = await _context.Questions
				.Where(question => question.PrototypeQuestionId == id)
				.ToListAsync();
			var newPrototypeQuestion = questionsToBeUpdated
				.FirstOrDefault(question => question.Id != id);
			foreach (var question in questionsToBeUpdated)
			{
				question.PrototypeQuestion = newPrototypeQuestion;
			}
		}

		private async Task ValidateDoesQuestionSectionExistAsync(int questionSectionId)
		{
			var isQuestionSectionPresent = await _context.QuestionSections
				.AnyAsync(questionSection => questionSection.Id == questionSectionId);

			if (!isQuestionSectionPresent)
			{
				throw new ArgumentException(ExceptionMessageConstants.InvalidSectionMessage);
			}
		}

		private void ValidateQuestionHasNoAnswersAsync(QuestionEntity question)
		{
			var questionHasAnswer = question.Answers.Any();
			if (questionHasAnswer)
			{
				throw new NotAllowed(ExceptionMessageConstants.AnsweredQuestionMessage);
			}
		}

		private void ValidateContainsQuestionOrderInSectionDuplicates(
			IEnumerable<UpdateQuestionOrderDTO> questionsDTO)
		{
			var containsOrderDuplicate = questionsDTO
				.GroupBy(x => new { x.Order, x.SectionId })
				.Any(group => group.Count() > 1);

			if (containsOrderDuplicate)
			{
				throw new ArgumentException(ExceptionMessageConstants.OrderDuplicatedMessage);
			}
		}

		private async Task ValidateDoesQuestionOrderUnique(int questionSectionId, int order)
		{
			var hasQuestionOrderDuplicate = await _context.Questions
					.AnyAsync(question => question.QuestionSectionId == questionSectionId && question.Order == order);
			if (hasQuestionOrderDuplicate)
			{
				throw new ArgumentException(ExceptionMessageConstants.OrderDuplicatedMessage);
			}
		}

		private void ValidateCanQuestionHaveOtherOption(int questionTypeId, bool canHaveOtherOption)
		{
			if (canHaveOtherOption)
			{
				if (questionTypeId == (int)QuestionTypes.CheckBoxes ||
					questionTypeId == (int)QuestionTypes.MultipleChoice)
				{
					return;
				}
				throw new InvalidOperationException(ExceptionMessageConstants.QuestionCantAllowOtherOptionMessage);
			}
		}

		private void ValidateDoesAllQuestionsBelongOnePoll(PollEntity pollEntity, IEnumerable<int> questionIds)
		{
			bool areAllQuestionsBelongOnePoll = questionIds.All(questionId => pollEntity.QuestionSections
				.SelectMany(section => section.Questions)
				.Select(question => question.Id).ToList()
				.Contains(questionId));

			if (!areAllQuestionsBelongOnePoll)
			{
				throw new ArgumentException(ExceptionMessageConstants.QuestionsFromDifferentPolls);
			}
		}

		private void ValidateDoesAllSectionsBelongOnePoll(PollEntity pollEntity, IEnumerable<int> sectionIds)
		{
			bool areAllSectionsBelongOnePoll = sectionIds
				.All(sectionId => pollEntity.QuestionSections
				.Any(section => section.Id == sectionId));

			if (!areAllSectionsBelongOnePoll)
			{
				throw new ArgumentException(ExceptionMessageConstants.SectionsFromDifferentPolls);
			}
		}

		private async Task ValidateAreAllQuestionsExistAsync(IEnumerable<int> questionIds)
		{
			var dbQuestionIdsCount = await _context.Questions
				.Where(question => questionIds
				.Contains(question.Id)).CountAsync();
			bool areAllQuestionsExist = questionIds.Count() == dbQuestionIdsCount;

			if (!areAllQuestionsExist)
			{
				throw new NotFoundException(ExceptionMessageConstants.QuestionNotFoundMessage);
			}
		}

		private async Task ValidateAreAllSectionsExistAsync(IEnumerable<int> sectionIds)
		{
			var dbSectionIdsCount = await _context.QuestionSections
				.Where(section => sectionIds.Contains(section.Id)).CountAsync();
			bool areAllSectionsExist = sectionIds.Count() == dbSectionIdsCount;

			if (!areAllSectionsExist)
			{
				throw new NotFoundException(ExceptionMessageConstants.QuestionSectionNotFoundMessage);
			}
		}
	}
}