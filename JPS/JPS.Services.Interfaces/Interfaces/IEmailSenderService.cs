using SendGrid;
using System.Threading.Tasks;

namespace JPS.Services.Interfaces.Interfaces
{
	/// <summary>
	/// Holds methods to send emails.
	/// </summary>
	public interface IEmailSenderService
	{
		/// <summary>
		/// Send notification about poll start.
		/// </summary>
		/// <param name="pollId">Used to get information about necessary poll.</param>
		Task<Response> NotifyAboutStartPollAsync(int pollId);

		/// <summary>
		/// Send notification about poll start on email address.
		/// </summary>
		/// <param name="pollId">Used to get information about necessary poll.</param>
		/// <param name="email">Used to send mail to appropriate email address.</param>
		Task<Response> NotifyAboutStartPollByEmailAsync(int pollId, string email);

		/// <summary>
		/// Send notification that poll has ended.
		/// </summary>
		/// <param name="pollId">Used to get information about necessary poll.</param>
		Task<Response> NotifyAboutPollEndAsync(int pollId);

		/// <summary>
		/// Send notification on email address that poll has ended.
		/// </summary>
		/// <param name="pollId">Used to get information about necessary poll.</param>
		/// <param name="email">Used to send mail to appropriate email address.</param>
		Task<Response> NotifyAboutPollEndByEmailAsync(int pollId, string email);
		
		/// <summary>
		/// Send email that reminds the user about poll.
		/// </summary>
		/// <param name="email">Used to set list of neccessary emails.</param>
		/// <param name="pollId">Used to set poll id.</param>
		Task<Response> RemindUserPollIsInProgressAsync(int pollId, string email);

		/// <summary>
		/// Call method that send email that reminds all users about poll.
		/// </summary>
		/// <param name="pollId">Used to set poll id.</param>
		Task CallReccuringPollInProgressJob(int pollId);

		/// <summary>
		/// Send email that reminds all users about poll.
		/// </summary>
		/// <param name="pollId">Used to set poll id.</param>
		Task<Response> RemindPollIsInProgressAsync(int pollId);
	}
}
