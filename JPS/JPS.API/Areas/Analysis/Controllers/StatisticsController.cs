using AutoMapper;
using JPS.API.ViewModels.ValidationAttributes;
using JPS.API.ViewModels.ViewModels.PollViewModels;
using JPS.API.ViewModels.ViewModels.PollViewModels.PollsWithContainedSectionsQuestionsViewModels;
using JPS.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace JPS.API.Areas.Analysis.Controllers
{
	/// <summary>
	/// This controller allow to work with statistics.
	/// </summary>
	[Area("analysis")]
	[Route("api/[area]/statistics")]
	public class StatisticsController : ControllerBase
	{
		private readonly IAnswerService _answerService;
		private readonly IMapper _mapper;

		public StatisticsController(IAnswerService answerService, IMapper mapper)
		{
			_answerService = answerService;
			_mapper = mapper;
		}

		/// <summary>
		/// Gets all answers grouped by questions in poll.
		/// </summary>
		/// <param name="pollId">Used to find necessary poll.</param>
		/// <returns>Poll with answers grouped by questions.</returns>
		[HttpGet("{pollId}")]
		[ProducesResponseType(typeof(PollViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<PollViewModel>> GetUsersAnswersByPollIdAsync(
			[NumericIdGreaterThanZero] int pollId)
		{
			var pollDTO = await _answerService.GetUsersAnswersByPollIdAsync(pollId);
			var pollViewModel = _mapper.Map<PollWithSectionsViewModel>(pollDTO);
			return Ok(pollViewModel);
		}

		/// <summary>
		/// Gets all answers of user for poll.
		/// </summary>
		/// <param name="pollId">Used to find necessary poll.</param>
		/// <param name="userId">Used to find necessary answers.</param>
		/// <returns>Poll with user's answers.</returns>
		[HttpGet("user-answers/{pollId}")]
		[ProducesResponseType(typeof(PollViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<PollViewModel>> GetUsersAnswersByPollIdAsync(
			[NumericIdGreaterThanZero] int pollId, [Required][FromQuery][GuidType] string userId)
		{
			var pollDTO = await _answerService.GetUserAnswersForPollAsync(pollId, userId);
			var pollViewModel = _mapper.Map<PollWithSectionsViewModel>(pollDTO);
			return Ok(pollViewModel);
		}
	}
}