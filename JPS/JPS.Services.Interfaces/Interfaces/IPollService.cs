using JPS.Common;
using JPS.Services.DTO.DTOs;
using JPS.Services.DTO.DTOs.PollDTOs;
using JPS.Services.DTO.DTOs.PollDTOs.UpdateDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using JPS.Services.DTO.DTOs.PollDTOs.AnalyticsDTOs;

namespace JPS.Services.Interfaces.Interfaces
{
	/// <summary>
	/// Poll service interface. Contains all methods to interact with poll.
	/// </summary>
	public interface IPollService
	{
		/// <summary>
		/// Gets polls in the form of tree using pagination. Polls could be filtered by categoryId.
		/// </summary>
		/// <param name="paginationDTO">Used to set pagination properties.</param>
		/// <param name="categoryId">Used to get polls of concrete category.
		/// More than 0 - get polls that belong to category with setted id.
		/// 0 - get all polls.
		/// null - get polls that don't belong to any category.</param>
		/// <returns>Paged list of polls with contained sections questions and options.</returns>
		Task<PagedList<PollDTO>> GetAllPollsAsync(int? categoryId, PaginationDTO paginationDTO);

		/// <summary>
		/// Creates new poll.
		/// </summary>
		/// <param name="poll">Model with fields necessary for creating new poll.</param>
		/// <returns>Created poll.</returns>
		Task<PollDTO> CreatePollAsync(CreatePollDTO createPollDTO);

		/// <summary>
		/// Creates new poll as a copy of existing poll.
		/// </summary>
		/// <param name="id">Id of poll to be copied.</param>
		/// <returns>Created poll.</returns>
		Task<PollDTO> CopyPollAsync(int id);

		/// <summary>
		/// Updates poll category id.
		/// </summary>
		/// <param name="poll">Model with field necessary for updating poll category id.</param>
		/// <param name="id">Used to find poll to be updated.</param>
		/// <returns>Updated poll.</returns>
		Task<PollDTO> UpdatePollCategoryIdAsync(UpdatePollCategoryIdDTO updatePollDTO, int id);

		/// <summary>
		/// Updates poll title.
		/// </summary>
		/// <param name="poll">Model with field necessary for updating poll title.</param>
		/// <param name="id">Used to find poll to be updated.</param>
		/// <returns>Updated poll.</returns>
		Task<PollDTO> UpdatePollTitleAsync(UpdatePollTitleDTO updatePollDTO, int id);

		/// <summary>
		/// Updates poll description.
		/// </summary>
		/// <param name="poll">Model with field necessary for updating poll description.</param>
		/// <param name="id">Used to find poll to be updated.</param>
		/// <returns>Updated poll.</returns>
		Task<PollDTO> UpdatePollDescriptionAsync(UpdatePollDescriptionDTO updatePollDTO, int id);

		/// <summary>
		/// Updates poll start date.
		/// </summary>
		/// <param name="poll">Model with field necessary for updating poll start date.</param>
		/// <param name="id">Used to find poll to be updated.</param>
		/// <returns>Updated poll.</returns>
		Task<PollDTO> UpdatePollStartDateAsync(UpdatePollStartDateDTO updatePollDTO, int id);

		/// <summary>
		/// Update poll finish date.
		/// </summary>
		/// <param name="finishDate">Model with field necessary for updating poll finish date.</param>
		/// <param name="id">Used to find poll to be updated.</param>
		/// <returns>Updated poll.</returns>
		Task<PollDTO> UpdatePollFinishDateAsync(UpdatePollFinishDateDTO updatePollDTO, int id);

		/// <summary>
		/// Updates poll isAnonymous status.
		/// </summary>
		/// <param name="isAnonymous">Model with field necessary for updating poll isAnonymous status.</param>
		/// <param name="id">Used to find poll to be updated.</param>
		/// <returns>Updated poll.</returns>
		Task<PollDTO> UpdatePollIsAnonymousAsync(UpdatePollIsAnonymousDTO updatePollDTO, int id);

		/// <summary>
		/// Deletes existing poll.
		/// </summary>
		/// <param name="id">Used to find poll to be deleted.</param>
		Task DeletePollAsync(int id);

		/// <summary>
		/// Gets poll and everything it contains.
		/// </summary>		
		/// <param name="id">Used to find necessary poll.</param>>
		/// <return>Poll with sections, questions and options.</return>
		Task<PollDTO> GetPollByIdAsync(int id);

		/// <summary>
		/// Validate poll and publish it.
		/// </summary>
		/// <param name="id">Identifier for the poll to be published.</param>
		/// <returns>Published poll.</returns>
		Task<PollDTO> PublishPollAsync(int id);
	}
}
