using JPS.Services.DTO.DTOs.AnswerDTOs.GroupedAnswerDTOs;
using JPS.Services.DTO.DTOs.PollDTOs.AnalyticsDTOs;
using System.Threading.Tasks;

namespace JPS.Services.Interfaces.Interfaces
{
	/// <summary>
	/// Service interface that holds methods for analytics.
	/// </summary>
	public interface IAnalyticsService
	{
		/// <summary>
		/// Gets grouped answers by questionId.
		/// </summary>
		/// <param name="id">Used to find necessary question.</param>
		/// <returns>Grouped collection of answers.</returns>
		Task<GroupedAnswerDTO> GetGroupedAnswersByQuestionIdAsync(int id);

		/// <summary>
		/// Gets analytics for specific poll.
		/// </summary>
		/// <param name="id">Used to find necessary poll.</param>
		/// <returns></returns>
		Task<PollAnalyticsDTO> GetPollAnalyticsAsync(int id);

		/// <summary>
		/// Gets percent of users that answered the specific poll.
		/// </summary>
		/// <param name="pollId">Used to find necessary poll.</param>
		/// <returns>Percent of users.</returns>
		Task<double> GetPerсentOfUsersAnsweredThePoll(int pollId);

		/// <summary>
		/// Gets model with two analytics poll models and their grouped questions.
		/// </summary>
		/// <param name="firstPollId">Used to find first poll.</param>
		/// <param name="secondPollId">Used to find second poll.</param>
		/// <returns>Model with two analytics poll models with grouped questions.</returns>
		Task<PollComparisonDTO> GetPollsComparison(int firstPollId, int secondPollId);
	}
}
