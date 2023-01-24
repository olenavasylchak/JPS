using AutoMapper;
using Hangfire;
using JPS.Common;
using JPS.Domain.Entities.Entities;
using JPS.Infrastructure.Context;
using JPS.Services.Constants;
using JPS.Services.DTO.DTOs;
using JPS.Services.DTO.DTOs.PollDTOs;
using JPS.Services.DTO.DTOs.PollDTOs.UpdateDTOs;
using JPS.Services.Enums;
using JPS.Services.Exceptions;
using JPS.Services.Helpers;
using JPS.Services.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JPS.Services.Services
{
	/// <summary>
	/// Poll service that implements IPollService interface methods.
	/// Contains all methods to interact with poll.
	/// </summary>
	public class PollService : IPollService
	{
		private readonly JPSContext _jpsContext;
		private readonly IMapper _mapper;
		private readonly IEmailSenderService _emailSenderService;

		public PollService(JPSContext jpsContext, IMapper mapper,
			IEmailSenderService emailSenderService)
		{
			_jpsContext = jpsContext;
			_mapper = mapper;
			_emailSenderService = emailSenderService;
		}

		/// <inheritdoc/>
		public async Task<PagedList<PollDTO>> GetAllPollsAsync(int? categoryId, PaginationDTO paginationDTO)
		{
			if (categoryId != 0)
			{
				await ValidateDoesCategoryExist(categoryId);
			}

			var queryToPaginateListOfPolls = _jpsContext.Polls.AsNoTracking()
				.Include(poll => poll.QuestionSections)
					.ThenInclude(section => section.Questions)
						.ThenInclude(question => question.Options)
				.Include(poll => poll.QuestionSections)
					.ThenInclude(section => section.Questions)
						.ThenInclude(question => question.OptionRows)
				.Include(poll => poll.PollStyle)
				.AsQueryable();

			if (categoryId != 0)
			{
				queryToPaginateListOfPolls = queryToPaginateListOfPolls
					.Where(poll => poll.CategoryId == categoryId);
			}

			var pagedListOfPollEntities = await queryToPaginateListOfPolls
				.ToPaginatedCollection(paginationDTO.PageNumber, paginationDTO.PageSize);

			var pagedListOfPollDTOs = _mapper.Map<PagedList<PollDTO>>(pagedListOfPollEntities);
			return pagedListOfPollDTOs;
		}

		/// <inheritdoc/>
		public async Task<PollDTO> CreatePollAsync(CreatePollDTO createPollDTO)
		{
			ValidationHelper.ValidateFirstDateEarlierThanSecondDate(
				createPollDTO.StartsAt, createPollDTO.FinishesAt,
				ExceptionMessageConstants.EndDateIsEarlierThanStartDateMessage);
			await ValidateDoesCategoryExist(createPollDTO.CategoryId);

			var pollEntity = _mapper.Map<PollEntity>(createPollDTO);

			pollEntity.QuestionSections = new List<QuestionSectionEntity>
			{
				new QuestionSectionEntity
				{
					Order = 1
				}
			};

			await _jpsContext.Polls.AddAsync(pollEntity);

			await _jpsContext.SaveChangesAsync();

			var pollDTO = _mapper.Map<PollDTO>(pollEntity);
			return pollDTO;
		}

		/// <inheritdoc/>
		public async Task<PollDTO> CopyPollAsync(int id)
		{
			var pollEntity = await _jpsContext.Polls
			.Include(poll => poll.QuestionSections)
					.ThenInclude(section => section.Questions)
						.ThenInclude(question => question.Options)
				.Include(poll => poll.QuestionSections)
					.ThenInclude(section => section.Questions)
						.ThenInclude(question => question.OptionRows)
				.Include(poll => poll.QuestionSections)
					.ThenInclude(section => section.Questions)
						.ThenInclude(question => question.PrototypeQuestion)
			.Include(poll => poll.PollStyle)
			.SingleOrDefaultAsync(poll => poll.Id == id);

			ValidationHelper.ValidateDoesItemExist(pollEntity,
				ExceptionMessageConstants.PollNotFoundMessage);

			var pollEntityCopy = CopyHelper.CopyPoll(pollEntity);

			await _jpsContext.Polls.AddAsync(pollEntityCopy);
			await _jpsContext.SaveChangesAsync();

			var pollDTO = _mapper.Map<PollDTO>(pollEntityCopy);
			return pollDTO;
		}

		/// <inheritdoc/>
		public async Task<PollDTO> UpdatePollCategoryIdAsync(UpdatePollCategoryIdDTO updatePollDTO, int id)
		{
			await ValidateDoesCategoryExist(updatePollDTO.CategoryId);

			var pollEntity = await _jpsContext.Polls
				.SingleOrDefaultAsync(poll => poll.Id == id);

			ValidationHelper.ValidateDoesItemExist(
				pollEntity, ExceptionMessageConstants.PollNotFoundMessage);

			pollEntity.CategoryId = updatePollDTO.CategoryId;
			await _jpsContext.SaveChangesAsync();

			var pollDTO = _mapper.Map<PollDTO>(pollEntity);
			return pollDTO;
		}

		/// <inheritdoc/>
		public async Task<PollDTO> UpdatePollTitleAsync(UpdatePollTitleDTO updatePollDTO, int id)
		{
			var pollEntity = await _jpsContext.Polls
				.SingleOrDefaultAsync(poll => poll.Id == id);

			ValidationHelper.ValidateDoesItemExist(
				pollEntity, ExceptionMessageConstants.PollNotFoundMessage);
			ValidationHelper.ValidateDateHasNotPassed(
				pollEntity.StartsAt, ExceptionMessageConstants.InvalidOperationAfterStartMessage);

			pollEntity.Title = updatePollDTO.Title;
			await _jpsContext.SaveChangesAsync();

			var pollDTO = _mapper.Map<PollDTO>(pollEntity);
			return pollDTO;
		}

		/// <inheritdoc/>
		public async Task<PollDTO> UpdatePollDescriptionAsync(UpdatePollDescriptionDTO updatePollDTO, int id)
		{
			var pollEntity = await _jpsContext.Polls
				.SingleOrDefaultAsync(poll => poll.Id == id);

			ValidationHelper.ValidateDoesItemExist(
				pollEntity, ExceptionMessageConstants.PollNotFoundMessage);
			ValidationHelper.ValidateDateHasNotPassed(
				pollEntity.StartsAt, ExceptionMessageConstants.InvalidOperationAfterStartMessage);

			pollEntity.Description = updatePollDTO.Description;
			await _jpsContext.SaveChangesAsync();

			var pollDTO = _mapper.Map<PollDTO>(pollEntity);
			return pollDTO;
		}

		/// <inheritdoc/>
		public async Task<PollDTO> UpdatePollStartDateAsync(UpdatePollStartDateDTO updatePollDTO, int id)
		{
			var pollEntity = await _jpsContext.Polls
				.SingleOrDefaultAsync(poll => poll.Id == id);

			ValidationHelper.ValidateDoesItemExist(
				pollEntity, ExceptionMessageConstants.PollNotFoundMessage);
			ValidationHelper.ValidateDateHasNotPassed(
				pollEntity.StartsAt, ExceptionMessageConstants.InvalidOperationAfterStartMessage);
			ValidationHelper.ValidateFirstDateEarlierThanSecondDate(
				updatePollDTO.StartsAt, pollEntity.FinishesAt,
				ExceptionMessageConstants.EndDateIsEarlierThanStartDateMessage);

			pollEntity.StartsAt = updatePollDTO.StartsAt;

			if (pollEntity.StartsAt != null)
			{
				pollEntity.StartPollJobId = UpdateJob(pollEntity.StartPollJobId,
						 () => _emailSenderService.NotifyAboutStartPollAsync(pollEntity.Id), pollEntity.StartsAt.Value);

				pollEntity.InProgressPollJobId = UpdateJob(pollEntity.InProgressPollJobId,
						 () => _emailSenderService.CallReccuringPollInProgressJob(pollEntity.Id), pollEntity.StartsAt.Value);
				RecurringJob.RemoveIfExists(RecurringJobsHelper.GetPollInProgressJobId(id));
			}
			else
			{
				DeleteJob(pollEntity.StartPollJobId);
				DeleteJob(pollEntity.InProgressPollJobId);
				RecurringJob.RemoveIfExists(RecurringJobsHelper.GetPollInProgressJobId(id));
				pollEntity.StartPollJobId = null;
				pollEntity.InProgressPollJobId = null;
			}

			await _jpsContext.SaveChangesAsync();

			var pollDTO = _mapper.Map<PollDTO>(pollEntity);

			return pollDTO;
		}

		/// <inheritdoc/>
		public async Task<PollDTO> UpdatePollFinishDateAsync(UpdatePollFinishDateDTO updatePollDTO, int id)
		{
			var pollEntity = await _jpsContext.Polls
				.SingleOrDefaultAsync(poll => poll.Id == id);

			ValidationHelper.ValidateDoesItemExist(
				pollEntity, ExceptionMessageConstants.PollNotFoundMessage);
			ValidationHelper.ValidateFirstDateEarlierThanSecondDate(
				pollEntity.StartsAt, updatePollDTO.FinishesAt,
				ExceptionMessageConstants.EndDateIsEarlierThanStartDateMessage);

			pollEntity.FinishesAt = updatePollDTO.FinishesAt;

			if (pollEntity.FinishesAt != null)
			{
				pollEntity.EndPollJobId = UpdateJob(pollEntity.EndPollJobId,
						 () => _emailSenderService.NotifyAboutPollEndAsync(pollEntity.Id), pollEntity.FinishesAt.Value);
			}
			else
			{
				DeleteJob(pollEntity.EndPollJobId);
				pollEntity.EndPollJobId = null;
			}

			await _jpsContext.SaveChangesAsync();

			var pollDTO = _mapper.Map<PollDTO>(pollEntity);
			return pollDTO;
		}

		/// <inheritdoc/>
		public async Task<PollDTO> UpdatePollIsAnonymousAsync(UpdatePollIsAnonymousDTO updatePollDTO, int id)
		{
			var pollEntity = await _jpsContext.Polls
				.SingleOrDefaultAsync(poll => poll.Id == id);

			ValidationHelper.ValidateDoesItemExist(
				pollEntity, ExceptionMessageConstants.PollNotFoundMessage);
			if (await HasPollAnyAnswersAsync(id))
			{
				throw new InvalidOperationException(ExceptionMessageConstants.InvalidPollUpdatingAfterAnswerMessage);
			}

			pollEntity.IsAnonymous = updatePollDTO.IsAnonymous;
			await _jpsContext.SaveChangesAsync();

			var pollDTO = _mapper.Map<PollDTO>(pollEntity);
			return pollDTO;
		}

		/// <inheritdoc/>
		public async Task DeletePollAsync(int id)
		{
			var pollEntity = await _jpsContext.Polls
				.SingleOrDefaultAsync(poll => poll.Id == id);

			ValidationHelper.ValidateDoesItemExist(
				pollEntity, ExceptionMessageConstants.PollNotFoundMessage);
			if (await HasPollAnyAnswersAsync(id))
			{
				throw new InvalidOperationException(ExceptionMessageConstants.InvalidPollDeletingAfterAnswerMessage);
			}

			DeleteJob(pollEntity.StartPollJobId);
			DeleteJob(pollEntity.InProgressPollJobId);

			DeleteJob(pollEntity.EndPollJobId);

			_jpsContext.Remove(pollEntity);
			await _jpsContext.SaveChangesAsync();

			RecurringJob.RemoveIfExists(RecurringJobsHelper.GetPollInProgressJobId(id));
		}


		/// <inheritdoc/>
		public async Task<PollDTO> GetPollByIdAsync(int id)
		{
			var pollEntity = await _jpsContext.Polls.AsNoTracking()
				.Include(poll => poll.QuestionSections)
					.ThenInclude(section => section.Questions)
						.ThenInclude(question => question.Options)
				.Include(poll => poll.QuestionSections)
						.ThenInclude(section => section.Questions)
							.ThenInclude(question => question.OptionRows)
				.Include(poll => poll.PollStyle)
				.SingleOrDefaultAsync(poll => poll.Id == id);

			ValidationHelper.ValidateDoesItemExist(
				pollEntity, ExceptionMessageConstants.PollNotFoundMessage);

			var pollDTO = _mapper.Map<PollDTO>(pollEntity);
			return pollDTO;
		}

		///<inheritdoc/>
		public async Task<PollDTO> PublishPollAsync(int id)
		{
			var pollEntity = await _jpsContext.Polls
				.Include(poll => poll.QuestionSections)
					.ThenInclude(questionSection => questionSection.Questions)
						.ThenInclude(question => question.Options)
				.Include(poll => poll.QuestionSections)
					.ThenInclude(questionSection => questionSection.Questions)
						.ThenInclude(question => question.OptionRows)
				.Include(poll=>poll.PollStyle)
				.SingleOrDefaultAsync(poll => poll.Id == id);

			ValidationHelper.ValidateDoesItemExist(
				pollEntity, ExceptionMessageConstants.PollNotFoundMessage);

			foreach (var question in pollEntity.QuestionSections
				.SelectMany(questionSection => questionSection.Questions))
			{
				ValidateQuestionHasMoreThanOneOption(question);
				ValidateQuestionHasMoreThanOneOptionRow(question);
				ValidateLinearScaleQuestionHasValues(question);
			}

			if (pollEntity.StartsAt == null)
			{
				pollEntity.StartsAt = DateTimeOffset.Now;
			}

			if (pollEntity.FinishesAt != null)
			{
				pollEntity.EndPollJobId = BackgroundJob.Schedule(
				  () => _emailSenderService.NotifyAboutPollEndAsync(pollEntity.Id),
				  pollEntity.FinishesAt.Value);
			}

			pollEntity.StartPollJobId = BackgroundJob.Schedule(
				() => _emailSenderService.NotifyAboutStartPollAsync(pollEntity.Id),
				pollEntity.StartsAt.Value);

			pollEntity.InProgressPollJobId = BackgroundJob.Schedule(
				() => _emailSenderService.CallReccuringPollInProgressJob(pollEntity.Id),
				pollEntity.StartsAt.Value);

			await _jpsContext.SaveChangesAsync();

			var pollDTO = _mapper.Map<PollDTO>(pollEntity);
			return pollDTO;
		}

		private void ValidateLinearScaleQuestionHasValues(QuestionEntity question)
		{
			var hasQuestionSpecificType =
				question.QuestionTypeId == (int)QuestionTypes.LinearScale;

			if (!hasQuestionSpecificType)
			{
				return;
			}

			if (question.Options.Any(option => option.Value == null))
			{
				throw new NotAllowed(string.Format(
					ExceptionMessageConstants.NotAllowedLinearScaleWithoutValuesMessage,
					question.Text, question.Order));
			}
		}

		private void ValidateQuestionHasMoreThanOneOption(QuestionEntity question)
		{
			var hasQuestionSpecificType = question.QuestionTypeId == (int)QuestionTypes.MultipleChoiceGrid
				|| question.QuestionTypeId == (int)QuestionTypes.MultipleChoice
				|| question.QuestionTypeId == (int)QuestionTypes.CheckBoxes
				|| question.QuestionTypeId == (int)QuestionTypes.CheckboxGrid
				|| question.QuestionTypeId == (int)QuestionTypes.Dropdown
				|| question.QuestionTypeId == (int)QuestionTypes.LinearScale;

			if (!hasQuestionSpecificType)
			{
				return;
			}

			if (question.Options.Count < ServiceConstants.MinimalNumberOfOptionsInQuestion)
			{
				throw new NotAllowed(string.Format(
					ExceptionMessageConstants.NotAllowedOptionsCountMessage,
					question.Text, question.Order));
			}
		}

		private string UpdateJob(string jobId, Expression<Func<Task>> methodCall, DateTimeOffset date)
		{
			DeleteJob(jobId);

			var newJobId = BackgroundJob.Schedule(methodCall, date);

			return newJobId;
		}

		private void DeleteJob(string jobId)
		{
			if (jobId != null)
			{
				BackgroundJob.Delete(jobId);
			}
		}

		private void ValidateQuestionHasMoreThanOneOptionRow(QuestionEntity question)
		{
			var hasQuestionSpecificType = question.QuestionTypeId == (int)QuestionTypes.MultipleChoiceGrid
										  || question.QuestionTypeId == (int)QuestionTypes.CheckboxGrid;

			if (!hasQuestionSpecificType)
			{
				return;
			}

			if (question.OptionRows.Count < ServiceConstants.MinimalNumberOfOptionRowsInQuestion)
			{
				throw new NotAllowed(string.Format(
					ExceptionMessageConstants.NotAllowedRowsCountMessage,
					question.Text, question.Order));
			}
		}

		private async Task<bool> HasPollAnyAnswersAsync(int id)
		{
			var hasPollAnswer = await _jpsContext.Answers
				.AnyAsync(answer => answer.Question.QuestionSection.PollId == id);
			return hasPollAnswer;
		}

		private async Task ValidateDoesCategoryExist(int? id)
		{
			if (id != null)
			{
				var isCategoryExist = await _jpsContext.Categories
					.AnyAsync(category => category.Id == id);

				if (!isCategoryExist)
				{
					throw new NotFoundException(ExceptionMessageConstants.InvalidCategoryIdMessage);
				}
			}
		}
	}
}
