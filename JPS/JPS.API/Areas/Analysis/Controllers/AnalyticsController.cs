using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using JPS.API.ViewModels.ValidationAttributes;
using JPS.API.ViewModels.ViewModels.AnswerViewModels.GroupedAnswersViewModel;
using JPS.API.ViewModels.ViewModels.PollViewModels.AnalyticsViewModels;
using JPS.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using JPS.API.ViewModels.StringConstants;

namespace JPS.API.Areas.Analysis.Controllers
{
	/// <summary>
	/// This controller allow to work with analytics.
	/// </summary>
	[Area("analysis")]
	[Route("api/[area]/analytics")]
	public class AnalyticsController : ControllerBase
	{
		private readonly IAnalyticsService _analyticsService;
		private readonly IMapper _mapper;

		public AnalyticsController(IAnalyticsService analyticsService, IMapper mapper)
		{
			_analyticsService = analyticsService;
			_mapper = mapper;
		}

		/// <summary>
		/// Gets grouped answers by question id.
		/// </summary>
		/// <param name="questionId">Used to find necessary answers.</param>
		/// <returns>Grouped collection of answers.</returns>
		[HttpGet("grouped-answers/{questionId}")]
		[ProducesResponseType(typeof(GroupedAnswerViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<GroupedAnswerViewModel>> GetGroupedAnswers(
		[NumericIdGreaterThanZero] int questionId)
		{
			var groupedAnswersDTO = await _analyticsService.GetGroupedAnswersByQuestionIdAsync(questionId);
			var groupedAnswersViewModel = _mapper.Map<GroupedAnswerViewModel>(groupedAnswersDTO);
			return Ok(groupedAnswersViewModel);
		}

		/// <summary>
		/// Gets poll analytics by poll id.
		/// </summary>
		/// <param name="pollId">Used to find necessary poll.</param>
		/// <returns>Grouped collection of answers.</returns>
		[HttpGet("poll/{pollId}")]
		public async Task<ActionResult> GetPollAnalyticsAsync(
			[NumericIdGreaterThanZero] int pollId)
		{
			var pollAnalyticsDTO = await _analyticsService.GetPollAnalyticsAsync(pollId);
			var pollAnalyticViewModel = _mapper.Map<PollAnalyticsViewModel>(pollAnalyticsDTO);
			return Ok(pollAnalyticViewModel);
		}

		/// <summary>
		/// Gets model with two analytics poll models and their grouped questions.
		/// </summary>
		/// <param name="firstPollId">Used to find first poll.</param>
		/// <param name="secondPollId">Used to find second poll.</param>
		/// <returns>Model with two analytics poll models with grouped questions.</returns>
		[HttpGet("compare-polls")]
		[ProducesResponseType(typeof(PollsComparisonViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<PollsComparisonViewModel>> GetPollsComparison(
			[NumericIdGreaterThanZero] [FromQuery] [Required] int firstPollId,
			[NumericIdGreaterThanZero] [FromQuery] [Required] int secondPollId)
		{
			if(firstPollId == secondPollId)
			{
				throw new ArgumentException(ExceptionMessages.SamePollIdsToCompareMessage);
			}
			var pollComparisonDTO = await _analyticsService.GetPollsComparison(firstPollId, secondPollId);
			var pollComparisonViewModel = _mapper.Map<PollsComparisonViewModel>(pollComparisonDTO);
			return Ok(pollComparisonViewModel);
		}

		/// <summary>
		/// Gets percent of users that answered the specific poll.
		/// </summary>
		/// <param name="pollId">Used to find necessary poll.</param>
		/// <returns>Percent of users.</returns>
		[HttpGet("poll-progress/{pollId}")]
		[ProducesResponseType(typeof(double), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<double>> GetPercentOfUsersAnsweredThePoll(
			[NumericIdGreaterThanZero] int pollId)
		{
			var pollAnswersProgress = await _analyticsService.GetPerсentOfUsersAnsweredThePoll(pollId);
			return Ok(pollAnswersProgress);
		}
	}
}