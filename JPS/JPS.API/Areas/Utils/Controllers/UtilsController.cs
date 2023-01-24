using AutoMapper;
using JPS.API.ViewModels.ValidationAttributes;
using JPS.API.ViewModels.ViewModels.CreatePollWithAllQuestionsViewModels;
using JPS.API.ViewModels.ViewModels.PollViewModels;
using JPS.Services.DTO.DTOs.CreatePollWithAllQuestionsDTOs;
using JPS.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace JPS.API.Areas.Utils.Controllers
{
	/// <summary>
	/// This controller contains additional methods.
	/// Allows to create polls with question sections and questions of all possible types.
	/// Allows to get user's name.
	/// </summary>
	[Authorize]
	[Area("utils")]
	[Route("api/[area]/utils")]
	public class UtilsController : ControllerBase
	{
		private readonly IUtilsService _utilsService;
		private readonly IUsersClaimsAccessorService _usersClaimsAccessorService;
		private readonly IEmailSenderService _emailSenderService;
		private readonly IMapper _mapper;
		private readonly IGraphService _graphService;

		public UtilsController(IUtilsService service,
			IUsersClaimsAccessorService usersClaimsAccessorService, IMapper mapper,
			IGraphService graphService, IEmailSenderService emailSenderService)
		{
			_utilsService = service;
			_usersClaimsAccessorService = usersClaimsAccessorService;
			_mapper = mapper;
			_graphService = graphService;
			_emailSenderService = emailSenderService;
		}

		/// <summary>
		/// Creates poll with all questions.
		/// </summary>
		/// <param name="createPollViewModel">Model with fields to be created.</param>
		/// <returns>Action result.</returns>
		[HttpPost("polls/insert")]
		public async Task<ActionResult> CreatePollAsync([FromBody] CreatePollWithQuestionSectionsViewModel createPollViewModel)
		{
			var createPollDTO = _mapper.Map<CreatePollWithQuestionSectionsDTO>(createPollViewModel);
			var pollDTO = await _utilsService.CreatePollWithQuestionsAsync(createPollDTO);
			var pollViewModel = _mapper.Map<PollViewModel>(pollDTO);
			return Ok(pollViewModel);
		}

		/// <summary>
		/// Deletes all user's answers to the poll.
		/// </summary>
		/// <param name="userId">Used to find necessary user.</param>
		/// <param name="pollId">Used to find necessary poll.</param>
		[HttpDelete("polls/{pollId}/answers")]
		public async Task<ActionResult> DeleteUserAnswersAsync([Required] [FromQuery] [GuidType] string userId,
			[Required] [NumericIdGreaterThanZero] int pollId)
		{
			await _utilsService.DeleteUserPollAnswersAsync(userId, pollId);
			return NoContent();
		}

		/// <summary>
		/// Gets name of logged-in user.
		/// </summary>
		/// <returns>User's name.</returns>
		[HttpGet("users/name")]
		public ActionResult GetLoggedInUserName()
		{
			var username = _usersClaimsAccessorService.Name;
			return Ok(username);
		}

		/// <summary>
		/// Gets number of users.
		/// </summary>
		/// <returns>Number of users.</returns>
		[HttpGet("users/count")]
		public async Task<ActionResult> GetNumberOfUsersAsync()
		{
			var numberOfUsers = await _graphService.GetNumberOfUsersAsync();

			return Ok(numberOfUsers);
		}

		/// <summary>
		/// Send mail about poll start on appropriate email address.
		/// </summary>
		/// <param name="email">Used to send mail to appropriate email address.</param>
		/// <param name="pollId">Used to get information about neccessary poll.</param>
		[HttpPost("test-poll-starting-mail/{pollId}")]
		public async Task<ActionResult> NotifyUserAboutStartPollingAsync(
			[Required] [NumericIdGreaterThanZero] int pollId,
			[Required] [EmailAddress] [FromBody] string email)
		{
			await _emailSenderService.NotifyAboutStartPollByEmailAsync(pollId, email);

			return Ok();
		}

		/// <summary>
		/// Send mail about poll start to all users.
		/// </summary>
		/// <param name="pollId">Used to get information about necessary poll.</param>
		[HttpPost("poll-starting/{pollId}")]
		public async Task<ActionResult> NotifyUserAboutStartPollingAsync(
			[Required] [NumericIdGreaterThanZero] int pollId)
		{
			await _emailSenderService.NotifyAboutStartPollAsync(pollId);

			return Ok();
		}

		/// <summary>
		/// Send mail that poll has ended on appropriate email address.
		/// </summary>
		/// <param name="email">Used to send mail to appropriate email address.</param>
		/// <param name="pollId">Used to get information about necessary poll.</param>
		[HttpPost("test-poll-ended-mail/{pollId}")]
		public async Task<ActionResult> NotifyUserAboutPollEndAsync(
			[Required] [NumericIdGreaterThanZero] int pollId,
			[Required] [EmailAddress] [FromBody] string email)
		{
			await _emailSenderService.NotifyAboutPollEndByEmailAsync(pollId, email);

			return Ok();
		}

		/// <summary>
		/// Send mail to all users that poll has ended.
		/// </summary>
		/// <param name="pollId">Used to get information about necessary poll.</param>
		[HttpPost("poll-ended/{pollId}")]
		public async Task<ActionResult> NotifyUserAboutPollEndAsync(
			[Required] [NumericIdGreaterThanZero] int pollId)
		{
			await _emailSenderService.NotifyAboutPollEndAsync(pollId);

			return Ok();
		}

		/// <summary>
		/// Send remind mail to user  that poll is in progress.
		/// </summary>
		[HttpPost("test-poll-in-progress-mail/{pollId}")]
		public async Task<ActionResult> RemindUserPollIsInProgressAsync(
			[Required] [NumericIdGreaterThanZero] int pollId,
			[Required] [EmailAddress] [FromBody] string email)
		{
			await _emailSenderService.RemindUserPollIsInProgressAsync(pollId, email);

			return Ok();
		}

		/// <summary>
		/// Send remind mail to users that poll is in progress.
		/// </summary>
		[HttpPost("poll-in-progress-mail/{pollId}")]
		public async Task<ActionResult> RemindPollIsInProgressAsync(
			[Required] [NumericIdGreaterThanZero] int pollId)
		{
			await _emailSenderService.RemindPollIsInProgressAsync(pollId);

			return Ok();
		}

		/// <summary>
		/// Generates SAS-token for blob storage access.
		/// </summary>
		/// <returns>SAS token.</returns>
		[HttpGet("sas-token")]
		public ActionResult GetSasToken()
		{
			var token = _utilsService.GenerateSasTokenForBlobStorage();
			return Ok(token);
		}

	}
}