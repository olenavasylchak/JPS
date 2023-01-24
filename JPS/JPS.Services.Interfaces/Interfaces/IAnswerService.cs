using JPS.Services.DTO.DTOs.AnswerDTOs;
using JPS.Services.DTO.DTOs.AnswerDTOs.CreateDTOs;
using JPS.Services.DTO.DTOs.PollDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JPS.Services.Interfaces.Interfaces
{
	/// <summary>
	/// Answer service interface, holds methods that creates, updates and gets answers.
	/// </summary>
	public interface IAnswerService
	{
		/// <summary>
		/// Gets all answers by pollId grouped by questions.
		/// </summary>
		/// <param name="pollId">Used to find necessary poll.</param>
		/// <returns>Poll with answers grouped by questions.</returns>
		Task<PollDTO> GetUsersAnswersByPollIdAsync(int pollId);

		/// <summary>
		/// Gets all answers by questionId.
		/// </summary>
		/// <param name="id">Used to find necessary question.</param>
		/// <returns>Collection of answers.</returns>
		Task<IEnumerable<AnswerDTO>> GetAnswersByQuestionIdAsync(int id);

		/// <summary>
		/// Sets all poll answers and validate them.
		///</summary>
		/// <param name="answers">ModelDTO with fields necessary for updating checkbox.</param>
		/// <param name="usersClaimsAccessor">Used to get neccessary user claims.</param>
		/// <returns>Created answers.</returns>
		Task CreatePollAnswersAsync(CreatePollAnswersDTO answers, IUsersClaimsAccessorService usersClaimsAccessor);

		/// <summary>
		/// Gets all answers of user for poll.
		/// </summary>
		/// <param name="pollId">Used to find necessary poll.</param>
		/// <param name="userId">Used to find necessary answers.</param>
		/// <returns>Poll with user's answers.</returns>
		Task<PollDTO> GetUserAnswersForPollAsync(int pollId, string userId);
	}
}