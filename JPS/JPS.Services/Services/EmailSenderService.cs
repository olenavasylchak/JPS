using Hangfire;
using JPS.Domain.Entities.Entities;
using JPS.Infrastructure.Context;
using JPS.Services.Constants;
using JPS.Services.DTO.DTOs.UserDTOs;
using JPS.Services.Helpers;
using JPS.Services.Interfaces.Interfaces;
using JPS.Services.ModelInterfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JPS.Services.Services
{
	/// <inheritdoc/>
	public class EmailSenderService : IEmailSenderService
	{
		private readonly JPSContext _jpsContext;
		private readonly SendGridClient _sendGridClient;
		private readonly EmailAddress _sender;
		private readonly IGraphService _graphService;

		public EmailSenderService(ISendGridOptions sendGridOptions,
			JPSContext jpsContext, IGraphService graphService)
		{
			_jpsContext = jpsContext;
			_graphService = graphService;

			_sendGridClient = new SendGridClient(sendGridOptions.SendGridKey);

			_sender = new EmailAddress(sendGridOptions.EmailSender,
				sendGridOptions.SendGridUser);
		}

		/// <inheritdoc/>
		public async Task<Response> NotifyAboutStartPollByEmailAsync(int pollId, string email)
		{
			var poll = _jpsContext.Polls.SingleOrDefault(poll => poll.Id == pollId);
			ValidationHelper.ValidateDoesItemExist(poll, ExceptionMessageConstants.PollNotFoundMessage);

			var message = await BuildMessageAsync(poll, ServiceConstants.StartPollEmailViewPath);

			var response = await SendEmailsAsync(poll.Title, message, email);
			return response;
		}

		/// <inheritdoc/>
		public async Task<Response> NotifyAboutStartPollAsync(int pollId)
		{
			var poll = _jpsContext.Polls.SingleOrDefault(poll => poll.Id == pollId);
			ValidationHelper.ValidateDoesItemExist(poll, ExceptionMessageConstants.PollNotFoundMessage);

			var users = await _graphService.GetListOfUsersAsync();
			var emails = users.Select(user => user.Mail);

			var buildedMessage = await BuildMessageAsync(poll, ServiceConstants.StartPollEmailViewPath);

			var response = await SendEmailsAsync(poll.Title, buildedMessage, emails.ToArray());
			return response;
		}

		/// <inheritdoc/>
		public async Task<Response> NotifyAboutPollEndByEmailAsync(int pollId, string email)
		{
			var poll = _jpsContext.Polls.SingleOrDefault(poll => poll.Id == pollId);

			ValidationHelper.ValidateDoesItemExist(poll, ExceptionMessageConstants.PollNotFoundMessage);

			var message = await BuildMessageAsync(poll, ServiceConstants.EndPollEmailViewPath);

			var response = await SendEmailsAsync(poll.Title, message, email);
			return response;
		}

		/// <inheritdoc/>
		public async Task<Response> NotifyAboutPollEndAsync(int pollId)
		{
			var poll = _jpsContext.Polls.SingleOrDefault(poll => poll.Id == pollId);

			ValidationHelper.ValidateDoesItemExist(poll, ExceptionMessageConstants.PollNotFoundMessage);

			var users = await _graphService.GetListOfUsersAsync();
			var emails = users.Select(user => user.Mail).ToArray();

			var message = await BuildMessageAsync(poll, ServiceConstants.EndPollEmailViewPath);

			var response = await SendEmailsAsync(poll.Title, message, emails);

			poll.EndPollJobId = null;
			await _jpsContext.SaveChangesAsync();

			return response;
		}

		/// <inheritdoc/>
		public async Task<Response> RemindUserPollIsInProgressAsync(int pollId, string email)
		{
			var poll = _jpsContext.Polls.SingleOrDefault(poll => poll.Id == pollId);
			ValidationHelper.ValidateDoesItemExist(poll, ExceptionMessageConstants.PollNotFoundMessage);

			var buildedMessage = await BuildMessageAsync(poll, ServiceConstants.PollInProgressEmailViewPath);

			var response = await SendEmailsAsync(poll.Title, buildedMessage, email);
			return response;
		}

		/// <inheritdoc/>
		public async Task CallReccuringPollInProgressJob(int pollId)
		{
			RecurringJob.AddOrUpdate(RecurringJobsHelper.GetPollInProgressJobId(pollId),
			  () => RemindPollIsInProgressAsync(pollId), ServiceConstants.CronExpressionPollReminder);
		}

		/// <inheritdoc/>
		public async Task<Response> RemindPollIsInProgressAsync(int pollId)
		{
			var poll = _jpsContext.Polls.SingleOrDefault(poll => poll.Id == pollId);
			ValidationHelper.ValidateDoesItemExist(poll, ExceptionMessageConstants.PollNotFoundMessage);

			if (poll.FinishesAt != null)
			{
				if (poll.FinishesAt < DateTimeOffset.Now)
				{
					RecurringJob.RemoveIfExists(RecurringJobsHelper.GetPollInProgressJobId(poll.Id));
					return null;
				}
			}

			var allUsers = await _graphService.GetListOfUsersAsync();
			var filteredUsers = FilterUsersThatHaveNotAnswered(pollId, allUsers, poll.IsAnonymous);
			var emails = filteredUsers.Select(user => user.Mail);

			var buildedMessage = await BuildMessageAsync(poll, ServiceConstants.PollInProgressEmailViewPath);

			var response = await SendEmailsAsync(poll.Title, buildedMessage, emails.ToArray());
			return response;
		}

		private async Task<string> BuildMessageAsync(PollEntity poll, string htmlPath)
		{
			var message = await GetHtmlView(string.Concat(Path.GetDirectoryName(
			   System.Reflection.Assembly.GetExecutingAssembly().Location),
			   htmlPath));

			var pollFinishesAt = poll.FinishesAt?.DateTime;
			var pollStartsAt = poll.StartsAt?.DateTime;

			return string.Format(
				message, poll.Title, poll.Description, pollStartsAt, pollFinishesAt, string.Empty);
		}

		private async Task<Response> SendEmailsAsync(string subject, string message, params string[] emails)
		{
			var sendGridMessage = new SendGridMessage()
			{
				From = _sender,
				Subject = subject,
				PlainTextContent = message,
				HtmlContent = message
			};

			foreach (var email in emails)
			{
				sendGridMessage.AddTo(new EmailAddress(email));
			}

			var response = await _sendGridClient.SendEmailAsync(sendGridMessage);
			return response;
		}

		private IEnumerable<UserDTO> FilterUsersThatHaveNotAnswered(int pollId, IEnumerable<UserDTO> users, bool isPollAnonymous)
		{
			if (isPollAnonymous)
			{
				return users;
			}
			var answeredUsersIds = _jpsContext.Answers.Where(answer => answer.Question.QuestionSection.PollId == pollId)
				.Select(answer => answer.UserId).Distinct().AsEnumerable();
			var notAsweredUsers = users.Where(user => !answeredUsersIds.Any(x => x == user.Id));

			return notAsweredUsers;
		}

		private async Task<string> GetHtmlView(string filepath)
		{
			return await File.ReadAllTextAsync(filepath);
		}
	}
}
