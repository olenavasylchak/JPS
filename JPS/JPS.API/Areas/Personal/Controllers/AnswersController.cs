using AutoMapper;
using JPS.API.ViewModels.ValidationAttributes;
using JPS.API.ViewModels.ViewModels.AnswerViewModels;
using JPS.API.ViewModels.ViewModels.AnswerViewModels.UpdateAllAnswersInPollViewModel;
using JPS.Services.DTO.DTOs.AnswerDTOs.CreateDTOs;
using JPS.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace JPS.API.Areas.Personal.Controllers
{
	/// <summary>
	/// This controller allows create, update and get all types of answers.
	/// </summary>
	[Area("personal")]
	[Route("api/[area]/answers")]
	public class AnswersController : ControllerBase
	{
		private readonly IAnswerService _answerService;
		private readonly IUsersClaimsAccessorService _usersClaimsAccessor;
		private readonly IMapper _mapper;

		public AnswersController(IAnswerService answerService, IUsersClaimsAccessorService usersClaimsAccessor, IMapper mapper)
		{
			_answerService = answerService;
			_usersClaimsAccessor = usersClaimsAccessor;
			_mapper = mapper;
		}

		/// <summary>
		/// Gets all answers by question id.
		/// </summary>
		/// <param name="questionId">Used to find necessary answers.</param>
		/// <returns>Collection of answers.</returns>
		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<AnswerViewModel>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<AnswerViewModel>>> GetAnswersByQuestionIdAsync(
			[Required] [FromQuery] [NumericIdGreaterThanZero]
			int questionId)
		{
			var answerDTOs = await _answerService.GetAnswersByQuestionIdAsync(questionId);
			IEnumerable<AnswerViewModel> answerViewModels = _mapper.Map<IEnumerable<AnswerViewModel>>(answerDTOs);
			return Ok(answerViewModels);
		}

		/// <summary>
		/// Creates answers in poll.
		/// </summary>
		/// <param name="allAnswersInPoll">ViewModel with fields necessary for creating new answer.</param>
		/// <returns>Created answers</returns>
		[ProducesResponseType(typeof(CreatePollAnswersViewModel), (int)HttpStatusCode.OK)]
		[HttpPost("answers-poll")]
		public async Task<ActionResult<CreatePollAnswersViewModel>> CreateAnswersForPollAsync(
			[FromBody] CreatePollAnswersViewModel allAnswersInPoll)
		{
			var pollAnswersDTO = _mapper.Map<CreatePollAnswersDTO>(allAnswersInPoll);
			await _answerService.CreatePollAnswersAsync(pollAnswersDTO, _usersClaimsAccessor);
			return Ok(allAnswersInPoll);
		}
	}
}