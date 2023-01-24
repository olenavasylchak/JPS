using AutoMapper;
using JPS.Domain.Entities.Entities;
using JPS.Infrastructure.Context;
using JPS.Services.Constants;
using JPS.Services.DTO.Attributes;
using JPS.Services.DTO.DTOs.AnswerDTOs;
using JPS.Services.DTO.DTOs.AnswerDTOs.CreateDTOs;
using JPS.Services.DTO.DTOs.AnswerDTOs.GetAnonymousDTOs;
using JPS.Services.DTO.DTOs.PollDTOs;
using JPS.Services.Enums;
using JPS.Services.Exceptions;
using JPS.Services.Helpers;
using JPS.Services.Helpers.PollAnswersValidations;
using JPS.Services.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace JPS.Services.Services
{
	/// <inheritdoc/>
	public class AnswerService : IAnswerService
	{
		private readonly IMapper _mapper;
		private readonly JPSContext _context;

		public AnswerService(JPSContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		/// <inheritdoc/>
		public async Task<IEnumerable<AnswerDTO>> GetAnswersByQuestionIdAsync(int id)
		{
			var questionEntity = await _context.Questions
				.AsNoTracking()
				.Include(question => question.Answers)
					.ThenInclude(answer => answer.TimeAnswer)
				.Include(question => question.Answers)
					.ThenInclude(answer => answer.DateAnswer)
				.Include(question => question.Answers)
					.ThenInclude(answer => answer.TextAnswer)
				.Include(question => question.Answers)
					.ThenInclude(answer => answer.ParagraphAnswer)
				.Include(question => question.Answers)
					.ThenInclude(answer => answer.OptionAnswers)
						.ThenInclude(optionAnswer => optionAnswer.Option)
				.Include(question => question.Answers)
					.ThenInclude(answer => answer.OptionAnswers)
						.ThenInclude(optionAnswer => optionAnswer.OptionRow)
				.Include(question => question.Answers)
					.ThenInclude(answer => answer.FileAnswer)
				.FirstOrDefaultAsync(question => question.Id == id);

			ValidationHelper.ValidateDoesItemExist(questionEntity, ExceptionMessageConstants.QuestionNotFoundMessage);
			var answerDTOs = _mapper.Map<IEnumerable<AnswerDTO>>(questionEntity.Answers);
			return answerDTOs;
		}

		/// <inheritdoc/>
		public async Task<PollDTO> GetUsersAnswersByPollIdAsync(int id)
		{
			var pollEntity = await _context.Polls
				.AsNoTracking()
				.Include(poll => poll.QuestionSections)
					.ThenInclude(section => section.Questions)
						.ThenInclude(question => question.Answers)
							.ThenInclude(answer => answer.TimeAnswer)

				.Include(poll => poll.QuestionSections)
					.ThenInclude(section => section.Questions)
						.ThenInclude(question => question.Answers)
							.ThenInclude(answer => answer.DateAnswer)

				.Include(poll => poll.QuestionSections)
					.ThenInclude(section => section.Questions)
						.ThenInclude(question => question.Answers)
							.ThenInclude(answer => answer.TextAnswer)

				.Include(poll => poll.QuestionSections)
					.ThenInclude(section => section.Questions)
						.ThenInclude(question => question.Answers)
							.ThenInclude(answer => answer.ParagraphAnswer)

				.Include(poll => poll.QuestionSections)
					.ThenInclude(section => section.Questions)
						.ThenInclude(question => question.Answers)
							.ThenInclude(answer => answer.OptionAnswers)
								.ThenInclude(optionAnswer => optionAnswer.Option)

				.Include(poll => poll.QuestionSections)
					.ThenInclude(section => section.Questions)
						.ThenInclude(question => question.Answers)
							.ThenInclude(answer => answer.OptionAnswers)
								.ThenInclude(optionAnswer => optionAnswer.OptionRow)

				.Include(poll => poll.QuestionSections)
					.ThenInclude(section => section.Questions)
						.ThenInclude(question => question.Answers)
							.ThenInclude(answer => answer.FileAnswer)

				.Include(poll => poll.QuestionSections)
					.ThenInclude(section => section.Questions)
						.ThenInclude(question => question.Options)

				.SingleOrDefaultAsync(poll => poll.Id == id);

			ValidationHelper.ValidateDoesItemExist(pollEntity, ExceptionMessageConstants.PollNotFoundMessage);

			var pollWithAnswersDTO = pollEntity.IsAnonymous ?
				_mapper.Map<AnonymousPollDTO>(pollEntity) : _mapper.Map<PollDTO>(pollEntity);

			return pollWithAnswersDTO;
		}

		/// <inheritdoc/>
		public async Task<PollDTO> GetUserAnswersForPollAsync(int pollId, string userId)
		{
			var pollEntity = await _context.Polls
				.SingleOrDefaultAsync(poll => poll.Id == pollId);
			ValidationHelper.ValidateDoesItemExist(pollEntity,
				ExceptionMessageConstants.PollNotFoundMessage);
			ValidationHelper.ValidateDoesPollAnonymous(pollEntity,
				ExceptionMessageConstants.AnonymousPollMessage);

			pollEntity = await _context.Polls
			.AsNoTracking()
			.Include(poll => poll.QuestionSections)
				.ThenInclude(section => section.Questions)
					.ThenInclude(question => question.Answers)
						.ThenInclude(answer => answer.TimeAnswer)

			.Include(poll => poll.QuestionSections)
				.ThenInclude(section => section.Questions)
					.ThenInclude(question => question.Answers)
						.ThenInclude(answer => answer.DateAnswer)

			.Include(poll => poll.QuestionSections)
				.ThenInclude(section => section.Questions)
					.ThenInclude(question => question.Answers)
						.ThenInclude(answer => answer.TextAnswer)

			.Include(poll => poll.QuestionSections)
				.ThenInclude(section => section.Questions)
					.ThenInclude(question => question.Answers)
						.ThenInclude(answer => answer.ParagraphAnswer)

			.Include(poll => poll.QuestionSections)
				.ThenInclude(section => section.Questions)
					.ThenInclude(question => question.Answers)
						.ThenInclude(answer => answer.OptionAnswers)

			.Include(poll => poll.QuestionSections)
				.ThenInclude(section => section.Questions)
					.ThenInclude(question => question.Answers)
						.ThenInclude(answer => answer.FileAnswer)

			.Include(poll => poll.QuestionSections)
				.ThenInclude(section => section.Questions)
					.ThenInclude(question => question.Options)

			.SingleOrDefaultAsync(poll => poll.Id == pollId);

			pollEntity.QuestionSections.ForEach(section => section.
				Questions.ForEach(question => question
					.Answers.RemoveAll(answer => !answer.UserId.Equals(userId))));

			ValidateDoesUserAnswered(pollEntity, userId);

			var pollDTO = _mapper.Map<PollDTO>(pollEntity);

			return pollDTO;
		}

		/// <inheritdoc/>
		public async Task CreatePollAnswersAsync(CreatePollAnswersDTO answersDTO, IUsersClaimsAccessorService usersClaimsAccessor)
		{
			await ValidatePollIsNotAnswered(answersDTO.PollId, usersClaimsAccessor.UserId);

			var pollToAnswer = _context.Polls
				.Include(poll => poll.QuestionSections)
					.ThenInclude(section => section.Questions)
						.ThenInclude(question => question.Options)
				.Include(poll => poll.QuestionSections)
					.ThenInclude(section => section.Questions)
						.ThenInclude(question => question.OptionRows)
				.FirstOrDefault(poll => poll.Id == answersDTO.PollId);

			ValidationHelper.ValidateDoesItemExist(pollToAnswer, ExceptionMessageConstants.PollNotFoundMessage);
			ValidatePollStartDate(pollToAnswer.StartsAt);
			ValidationHelper.ValidateDateHasNotPassed(pollToAnswer.FinishesAt,
				ExceptionMessageConstants.NotAllowedToCreateOrChangeAnswerAfterFinishDateMessage);

			var questionsInPoll = pollToAnswer.QuestionSections.SelectMany(section => section.Questions);

			var validatedQuestions = new List<AnswerEntity>();
			foreach (var questionInPoll in questionsInPoll)
			{

				var pollAnswer = answersDTO.Answers.FirstOrDefault(answers => answers.QuestionId == questionInPoll.Id);

				var validator = AnswersValidatorFactory.Create((QuestionTypes)questionInPoll.QuestionTypeId);

				validator.ValidateAnswer(questionInPoll, pollAnswer);
				if (pollAnswer != null)
				{
					var properties = FilterRedundantAnswerProperties(pollAnswer, questionInPoll.QuestionTypeId);
					SetPropertiesNull(properties, pollAnswer);
					pollAnswer.UserId = usersClaimsAccessor.UserId;
					var questionEntity = _mapper.Map<AnswerEntity>(pollAnswer);
					validatedQuestions.Add(questionEntity);
				}
			}
			await _context.Answers.AddRangeAsync(validatedQuestions);
			await _context.SaveChangesAsync();
		}

		private async Task ValidatePollIsNotAnswered(int pollId, string userId)
		{
			var userAnswered = await _context.Answers
				.AnyAsync(answer => answer.UserId == userId && answer.Question.QuestionSection.PollId == pollId);
			if (userAnswered)
			{
				throw new NotAllowed(ExceptionMessageConstants.AnswerAlreadyExistsMessage);
			}
		}

		private void ValidatePollStartDate(DateTimeOffset? startsAt)
		{
			if (startsAt is null)
			{
				return;
			}
			if (DateTimeOffset.Now < startsAt)
			{
				throw new NotAllowed(ExceptionMessageConstants.NotAllowedToCreateAnswerBeforeStartDateMessage);
			}
		}

		private void ValidateDoesUserAnswered(PollEntity poll, string userId)
		{
			var hasUserAnswered = poll.QuestionSections.Any(section => section.
				Questions.Any(question => question
					.Answers.Any(answer => answer.UserId.Equals(userId))));

			if (!hasUserAnswered)
			{
				throw new ArgumentException(ExceptionMessageConstants.UserHasNotAnsweredMessage);
			}
		}

		private IEnumerable<PropertyInfo> FilterRedundantAnswerProperties(PollAnswersDTO pollAnswerDTO, int questionTypeId)
		{
			Type type = pollAnswerDTO.GetType();
			var answerProperties = type.GetProperties().Where(
				prop => Attribute.IsDefined(prop, typeof(AllowedQuestionTypesAttribute)));

			var propertiesToDelete = answerProperties.Where(property =>
			{
				var attribute = property.GetCustomAttribute(typeof(AllowedQuestionTypesAttribute), false);

				AllowedQuestionTypesAttribute customAttribute = (AllowedQuestionTypesAttribute)attribute;

				return !customAttribute.Values.Contains(questionTypeId);
			});

			return propertiesToDelete;
		}

		private void SetPropertiesNull(IEnumerable<PropertyInfo> properties, PollAnswersDTO pollAnswersDTO)
		{
			foreach (var prop in properties)
			{
				prop.SetValue(pollAnswersDTO, null);
			}
		}
	}
}