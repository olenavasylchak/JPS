using JPS.Services.DTO.DTOs.QuestionSectionDTOs;
using JPS.Services.DTO.DTOs.QuestionSectionDTOs.UpdateDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JPS.Services.Interfaces.Interfaces
{
	/// <summary>
	/// Holds declaration of methods for working with question sections.
	/// </summary>
	public interface IQuestionSectionService
	{
		/// <summary>
		/// Gets all question sections by pollId.
		/// </summary>
		/// <param name="pollId">Used to find necessary poll.</param>
		/// <returns>List of sections.</returns>
		Task<IEnumerable<QuestionSectionDTO>> GetAllSectionsByPollIdAsync(int pollId);

		/// <summary>
		/// Gets all question sections with questions by pollId.
		/// </summary>
		/// <param name="pollId">Used to find necessary poll.</param>
		/// <returns>List of sections with questions.</returns>
		Task<IEnumerable<QuestionSectionDTO>> GetAllSectionsWithQuestionsByPollIdAsync(int pollId);

		/// <summary>Deletes section with given id.</summary>
		/// <param name="sectionId">Id of section that should be deleted.</param>
		Task DeleteQuestionSectionAsync(int sectionId);

		/// <summary>
		/// Creates new question section in poll.
		/// </summary>
		/// <param name="createQuestionSectionDTO">ModelDTO with fields necessary for creating section.</param>
		/// <returns>Created section.</returns>
		Task<QuestionSectionDTO> CreateQuestionSectionAsync(CreateQuestionSectionDTO createQuestionSectionDTO);

		/// <summary>
		/// Updates section title of section with given id.
		/// </summary>
		/// <param name="sectionId">Id of section that should be updated.</param>
		/// <param name="updateQuestionSectionDTO">ModelDTO with field necessary for update section title.</param>
		/// <returns>Updated section.</returns>
		Task<QuestionSectionDTO> UpdateQuestionSectionTitleAsync(int sectionId,
			UpdateQuestionSectionTitleDTO updateQuestionSectionDTO);

		/// <summary>
		/// Updates description of section with given id.
		/// </summary>
		/// <param name="sectionId">Id of section that should be updated.</param>
		/// <param name="updateQuestionSectionDTO">ModelDTO with fields necessary
		/// for update section description.</param>
		/// <returns>Updated section.</returns>
		Task<QuestionSectionDTO> UpdateQuestionSectionDescriptionAsync(int sectionId,
			UpdateQuestionSectionDescriptionDTO updateQuestionSectionDTO);

		/// <summary>
		/// Updates sections orders.
		/// </summary>
		/// <param name="updateQuestionSectionDTOs">ModelDTO with fields necessary
		/// for update sections order.</param>
		/// <returns>Updated sections.</returns>
		Task<IEnumerable<QuestionSectionDTO>> UpdateQuestionSectionOrdersAsync(
			IEnumerable<UpdateQuestionSectionOrderDTO> updateQuestionSectionDTOs);
	}
}
