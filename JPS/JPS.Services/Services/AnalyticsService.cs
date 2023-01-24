using AutoMapper;
using JPS.Domain.Entities.Entities;
using JPS.Infrastructure.Context;
using JPS.Services.Constants;
using JPS.Services.DTO.DTOs.AnswerDTOs;
using JPS.Services.DTO.DTOs.AnswerDTOs.GroupedAnswerDTOs;
using JPS.Services.DTO.DTOs.PollDTOs.AnalyticsDTOs;
using JPS.Services.Enums;
using JPS.Services.Helpers;
using JPS.Services.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPS.Services.DTO.DTOs.OptionRowDTOs;
using JPS.Services.Exceptions;

namespace JPS.Services.Services
{
	/// <summary>
	/// Service for analytics logic.
	/// </summary>
	public class AnalyticsService : IAnalyticsService
	{
		private readonly IMapper _mapper;
		private readonly JPSContext _context;
		private readonly IGraphService _graphService;

		public AnalyticsService(JPSContext context, IMapper mapper, IGraphService graphService)
		{
			_context = context;
			_mapper = mapper;
			_graphService = graphService;
		}

		/// <inheritdoc/>
		public async Task<PollAnalyticsDTO> GetPollAnalyticsAsync(int id)
		{
			var pollEntity = await _context.Polls
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

				.Include(poll => poll.QuestionSections)
					.ThenInclude(section => section.Questions)
						.ThenInclude(question => question.OptionRows)
							.SingleOrDefaultAsync(poll => poll.Id == id);

			ValidationHelper.ValidateDoesItemExist(pollEntity, ExceptionMessageConstants.PollNotFoundMessage);

			var questionEntities = pollEntity.QuestionSections
				.SelectMany(sections => sections.Questions);

			var pollAnalyticsDTO = _mapper.Map<PollAnalyticsDTO>(pollEntity);
			pollAnalyticsDTO.Progress = await GetPollProgressAsync(questionEntities);
			pollAnalyticsDTO.Questions = await GetAnalyticsQuestionsWithAnswers(questionEntities);

			return pollAnalyticsDTO;
		}

		private async Task<IEnumerable<QuestionAnalyticsDTO>> GetAnalyticsQuestionsWithAnswers(IEnumerable<QuestionEntity> questionEntities)
		{
			var questionAnalyticsDTOs = _mapper.Map<IEnumerable<QuestionAnalyticsDTO>>(questionEntities);

			using var questionEntitiesEnumerator = questionEntities.GetEnumerator();
			using var groupedQuestionsEnumerator = questionAnalyticsDTOs.GetEnumerator();
			while (questionEntitiesEnumerator.MoveNext() && groupedQuestionsEnumerator.MoveNext())
			{
				groupedQuestionsEnumerator.Current.GroupedAnswers = await GetAnswersAnalyticsForQuestionAsync(questionEntitiesEnumerator.Current);
			}

			return questionAnalyticsDTOs;
		}

		private async Task<double> GetPollProgressAsync(IEnumerable<QuestionEntity> questionEntities)
		{
			var amountOfUsersThatAnswered = questionEntities.SelectMany(question => question.Answers)
				.Select(answer => answer.UserId)
				.Distinct()
				.Count();

			var pollProgress = await CountPerсentOfUsersAnsweredThePoll(amountOfUsersThatAnswered);
			return pollProgress;
		}

		public async Task<GroupedAnswerDTO> GetGroupedAnswersByQuestionIdAsync(int id)
		{
			var questionEntity = await _context.Questions.AsNoTracking()
				.Include(question => question.Options)
				.Include(question => question.OptionRows)
				.Include(question => question.Answers)
					.ThenInclude(question => question.TimeAnswer)
				.Include(question => question.Answers)
					.ThenInclude(question => question.DateAnswer)
				.Include(question => question.Answers)
					.ThenInclude(question => question.TextAnswer)
				.Include(question => question.Answers)
					.ThenInclude(question => question.ParagraphAnswer)
				.Include(question => question.Answers)
					.ThenInclude(question => question.FileAnswer)
				.Include(question => question.Answers)
					.ThenInclude(question => question.OptionAnswers)
						.ThenInclude(optionAnswer => optionAnswer.Option)
				.Include(question => question.Answers)
					.ThenInclude(question => question.OptionAnswers)
						.ThenInclude(optionAnswer => optionAnswer.OptionRow)
				.SingleOrDefaultAsync(question => question.Id == id);

			return await GetAnswersAnalyticsForQuestionAsync(questionEntity);
		}

		private async Task<GroupedAnswerDTO> GetAnswersAnalyticsForQuestionAsync(QuestionEntity questionEntity)
		{
			ValidationHelper.ValidateDoesItemExist(questionEntity, ExceptionMessageConstants.QuestionNotFoundMessage);

			var groupedAnswerDTO = new GroupedAnswerDTO();
			var answerDTOs = _mapper.Map<IEnumerable<AnswerDTO>>(questionEntity.Answers);

			var hasTextAnswers = questionEntity.QuestionTypeId == (int)QuestionTypes.Text;
			if (hasTextAnswers)
			{
				var groupedTextAnswerDTO = new GroupedTextAnswerDTO
				{
					TextAnswers = answerDTOs.Select(answer => answer.TextAnswer).ToList(),
				};
				groupedAnswerDTO.TextAnswers = groupedTextAnswerDTO;
			}

			var hasParagraphAnswers = questionEntity.QuestionTypeId == (int)QuestionTypes.Paragraph;
			if (hasParagraphAnswers)
			{
				var groupedParagraphAnswerDTO = new GroupedParagraphAnswerDTO
				{
					ParagraphAnswers = answerDTOs.Select(answer => answer.ParagraphAnswer).ToList(),
				};
				groupedAnswerDTO.ParagraphAnswers = groupedParagraphAnswerDTO;
			}

			var hasFileAnswers = questionEntity.QuestionTypeId == (int)QuestionTypes.FileUpload;
			if (hasFileAnswers)
			{
				var groupedFileAnswerDTO = new GroupedFileAnswerDTO
				{
					FileAnswers = answerDTOs.Select(answer => answer.FileAnswer).ToList(),
				};
				groupedAnswerDTO.FileAnswers = groupedFileAnswerDTO;
			}

			if (hasTextAnswers || hasParagraphAnswers || hasFileAnswers)
			{
				return groupedAnswerDTO;
			}

			var allUsersCount = await _graphService.GetNumberOfUsersAsync();
			var alreadyAnsweredUsersCount = answerDTOs.Count();

			if (questionEntity.QuestionTypeId == (int)QuestionTypes.Date)
			{
				groupedAnswerDTO.DateAnswers = GetGroupedDateAnswers(answerDTOs);
				SetAnswerStatisticValues(groupedAnswerDTO.DateAnswers, allUsersCount, alreadyAnsweredUsersCount);
			}

			if (questionEntity.QuestionTypeId == (int)QuestionTypes.Time)
			{
				groupedAnswerDTO.TimeAnswers = GetGroupedTimeAnswers(answerDTOs);
				SetAnswerStatisticValues(groupedAnswerDTO.TimeAnswers, allUsersCount, alreadyAnsweredUsersCount);
			}

			var hasOptionAnswers = questionEntity.QuestionTypeId == (int)QuestionTypes.MultipleChoice
								   || questionEntity.QuestionTypeId == (int)QuestionTypes.CheckBoxes
								   || questionEntity.QuestionTypeId == (int)QuestionTypes.Dropdown
								   || questionEntity.QuestionTypeId == (int)QuestionTypes.LinearScale;
			if (hasOptionAnswers)
			{
				groupedAnswerDTO.OptionAnswers = GetGroupedOptionAnswers(questionEntity);
				SetAnswerStatisticValues(groupedAnswerDTO.OptionAnswers, allUsersCount, alreadyAnsweredUsersCount);
			}

			var hasGridAnswers = questionEntity.QuestionTypeId == (int)QuestionTypes.MultipleChoiceGrid
								   || questionEntity.QuestionTypeId == (int)QuestionTypes.CheckboxGrid;
			if (hasGridAnswers)
			{
				groupedAnswerDTO.GridAnswers = GetGroupedGridAnswers(questionEntity);
				foreach (var gridAnswer in groupedAnswerDTO.GridAnswers)
				{
					SetAnswerStatisticValues(gridAnswer.OptionAnswers, allUsersCount, alreadyAnsweredUsersCount);
				}
			}

			return groupedAnswerDTO;
		}

		private void SetAnswerStatisticValues(
			IEnumerable<DiscreteAnswerDTO> answers, int allUsersCount, int alreadyAnsweredUsersCount)
		{
			foreach (var answer in answers)
			{
				var percentageToAll = (100 * (double)answer.Count) / (double)allUsersCount;
				percentageToAll = Math.Round(percentageToAll, ServiceConstants.RoundingFactor);
				answer.PercentageToAll = percentageToAll;
				var percentageToAlreadyAnswered = (100 * (double)answer.Count) / (double)alreadyAnsweredUsersCount;
				percentageToAlreadyAnswered = Math.Round(percentageToAlreadyAnswered, ServiceConstants.RoundingFactor);
				answer.PercentageToAlreadyAnswered = percentageToAlreadyAnswered;
			}
		}

		/// <inheritdoc/>
		public async Task<double> GetPerсentOfUsersAnsweredThePoll(int pollId)
		{
			await ValidateDoesPollExistAsync(pollId);

			var amountOfUsersThatAnswered = await _context.Answers
				.Where(answer => answer.Question.QuestionSection.PollId == pollId)
				.Select(answer => answer.UserId)
				.Distinct().CountAsync();
			return await CountPerсentOfUsersAnsweredThePoll(amountOfUsersThatAnswered);
		}

		/// <inheritdoc/>
		public async Task<PollComparisonDTO> GetPollsComparison(int firstPollId, int secondPollId)
		{
			var pollEntities = await _context.Polls
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

				.Include(poll => poll.QuestionSections)
					.ThenInclude(section => section.Questions)
						.ThenInclude(question => question.OptionRows)
				.Where(poll => poll.Id == firstPollId || poll.Id == secondPollId)
				.ToListAsync();

			ValidateComparisonPollsCountIsTwo(pollEntities);

			var pollAnalyticsDTOs = _mapper.Map<IEnumerable<PollAnalyticsWithoutQuestionsDTO>>(pollEntities);
			var allQuestionEntities = new List<QuestionEntity>();

			using var pollEntitiesEnumerator = pollEntities.GetEnumerator();
			using var pollDTOsEnumerator = pollAnalyticsDTOs.GetEnumerator();
			while (pollEntitiesEnumerator.MoveNext() && pollDTOsEnumerator.MoveNext())
			{
				var questionEntities = pollEntitiesEnumerator.Current.QuestionSections
					.SelectMany(sections => sections.Questions);
				allQuestionEntities.AddRange(questionEntities);

				pollDTOsEnumerator.Current.Progress = await GetPollProgressAsync(questionEntities);
			}

			var questions = await GetAnalyticsQuestionsWithAnswers(allQuestionEntities);

			var gropedByPrototypeQuestionDTOs = questions
				.GroupBy(question => question.PrototypeQuestionId)
				.ToList();

			var pollComparisonDTO = new PollComparisonDTO
			{
				FirstPoll = pollAnalyticsDTOs.Single(poll => poll.Id == firstPollId),
				SecondPoll = pollAnalyticsDTOs.Single(poll => poll.Id == secondPollId),
				Questions = gropedByPrototypeQuestionDTOs
			};
			return pollComparisonDTO;
		}

		private async Task<double> CountPerсentOfUsersAnsweredThePoll(int amountOfUsersThatAnswered)
		{
			var amountOfAllUsers = await _graphService.GetNumberOfUsersAsync();
			double pollAnswersProgress = (double)amountOfUsersThatAnswered / (double)amountOfAllUsers;
			pollAnswersProgress = Math.Round(pollAnswersProgress, 2);
			return pollAnswersProgress;
		}

		private IEnumerable<GroupedTimeAnswerDTO> GetGroupedTimeAnswers(IEnumerable<AnswerDTO> answerDTOs)
		{
			var groupedAnswerDTOs = answerDTOs
				.GroupBy(answer => answer.TimeAnswer.Time)
				.Select(group => group.ToList());

			var groupedTimeAnswerDTOs = groupedAnswerDTOs
				.Select(listOfAnswerDTOs => new GroupedTimeAnswerDTO
				{
					TimeAnswer = listOfAnswerDTOs
						.Select(answer => answer.TimeAnswer).First(),
					Count = listOfAnswerDTOs.Count
				}).ToList();

			return groupedTimeAnswerDTOs;
		}

		private IEnumerable<GroupedOptionAnswerDTO> GetGroupedOptionAnswers(QuestionEntity questionEntity)
		{
			var optionDTOs = _mapper.Map<IEnumerable<GroupedOptionAnswerDTO>>(questionEntity.Options);

			var optionAnswerEntities = questionEntity.Answers.SelectMany(answer => answer.OptionAnswers
				.Select(optionAnswer => optionAnswer.Option));

			foreach (var option in optionDTOs)
			{
				option.Count = optionAnswerEntities.Count(optionAnswer => optionAnswer.Id == option.OptionAnswer.Id);
			}

			return optionDTOs;
		}

		private IEnumerable<GroupedDateAnswerDTO> GetGroupedDateAnswers(IEnumerable<AnswerDTO> answerDTOs)
		{
			var groupedAnswerDTOs = answerDTOs
				.GroupBy(answer => answer.DateAnswer.Date)
				.Select(group => group.ToList());

			var groupedDateAnswerDTOs = groupedAnswerDTOs
				.Select(listOfAnswerDTOs => new GroupedDateAnswerDTO
				{
					DateAnswer = listOfAnswerDTOs
						.Select(answer => answer.DateAnswer).First(),
					Count = listOfAnswerDTOs.Count
				}).ToList();

			return groupedDateAnswerDTOs;
		}

		private IEnumerable<GroupedGridAnswerDTO> GetGroupedGridAnswers(QuestionEntity questionEntity)
		{
			var optionRowDTOs = _mapper.Map<IEnumerable<OptionRowDTO>>(questionEntity.OptionRows);

			var groupedRowAnswerDTOs = optionRowDTOs.Select(row => new GroupedGridAnswerDTO
			{
				OptionRow = row,
				OptionAnswers = _mapper.Map<IEnumerable<GroupedOptionAnswerDTO>>(questionEntity.Options)
			}).ToList();

			var optionAnswerEntities = questionEntity.Answers.SelectMany(answer => answer.OptionAnswers).ToList();

			foreach (var row in groupedRowAnswerDTOs)
			{
				foreach (var option in row.OptionAnswers)
				{
					option.Count = optionAnswerEntities
						.Count(optionAnswer => optionAnswer.OptionId == option.OptionAnswer.Id &&
											   optionAnswer.OptionRowId == row.OptionRow.Id);
				}
			}

			return groupedRowAnswerDTOs;
		}

		private void ValidateComparisonPollsCountIsTwo(IEnumerable<PollEntity> pollEntities)
		{
			if (pollEntities.Count() != ServiceConstants.NumberOfPollsToBeCompared)
			{
				throw new NotFoundException(ExceptionMessageConstants.PollsToCompareNotFoundMessage);
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
	}
}
