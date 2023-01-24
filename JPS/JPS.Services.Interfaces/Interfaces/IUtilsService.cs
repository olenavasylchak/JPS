using JPS.Services.DTO.DTOs.CreatePollWithAllQuestionsDTOs;
using JPS.Services.DTO.DTOs.PollDTOs;
using JPS.Services.DTO.DTOs.UtilsDTO;
using System.Threading.Tasks;

namespace JPS.Services.Interfaces.Interfaces
{
	/// <summary>
	/// Service interface that holds declaration of additional methods.
	/// </summary>
	public interface IUtilsService
	{
		/// <summary>
		/// Creates poll with all questions.
		/// </summary>
		/// <param name="createPollDTO">Model for creating poll.</param>
		/// <returns>Created poll.</returns>
		public Task<PollDTO> CreatePollWithQuestionsAsync(CreatePollWithQuestionSectionsDTO createPollDTO);

		/// <summary>
		/// Util, deletes all user's answers to the poll.
		/// </summary>
		/// <param name="userId">Used to find user.</param>
		/// <param name="pollId">Used to find poll.</param>
		Task DeleteUserPollAnswersAsync(string userId, int pollId);

		/// <summary>
		/// Generates SAS token to allow its bearer access Azure Blob Storage
		/// </summary>
		/// <returns>SAS token</returns>
		BlobStorageCredentialsDTO GenerateSasTokenForBlobStorage();

	}
}
