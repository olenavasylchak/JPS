using JPS.Services.DTO.DTOs.OptionRowDTOs;
using JPS.Services.DTO.DTOs.OptionRowDTOs.UpdateDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JPS.Services.Interfaces.Interfaces
{
	/// <summary>
	/// Row service interface, holds methods that creates, updates and gets rows.
	/// </summary>
	public interface IOptionRowService
	{
		/// <summary>
		/// Create new row.
		/// </summary>
		/// <param name="createOptionRowDTO">Gives a model of row to method.</param>
		/// <returns>Created row. </returns>
		Task<OptionRowDTO> CreateOptionRowAsync(CreateOptionRowDTO createOptionRowDTO);

		/// <summary>
		/// Updates row's text.
		/// </summary>
		/// <param name="updateOptionRowTextDTO">Model with field necessary for updating row text by id.</param>
		/// <param name="id">Used to find necessary poll.</param>
		/// <returns>Updated row.</returns>
		Task<OptionRowDTO> UpdateOptionRowTextAsync(UpdateOptionRowTextDTO updateOptionRowTextDTO, int id);

		/// <summary>
		/// Updates row's image.
		/// </summary>
		/// <param name="updateOptionRowImageUrlDTO">Model with field necessary for updating row image.</param>
		/// <param name="id">Used to find necessary poll.</param>
		/// <returns>Updated row. </returns>
		Task<OptionRowDTO> UpdateOptionRowImageAsync(UpdateOptionRowImageDTO updateOptionRowImageUrlDTO, int id);

		/// <summary>
		/// Updates rows order.
		/// </summary>
		/// <param name="optionRowDTOs">Model with field necessary for updating rows order.</param>
		/// <returns>Updated rows.</returns>
		Task<IEnumerable<OptionRowDTO>> UpdateOptionRowsOrderAsync(IEnumerable<UpdateOptionRowOrderDTO> optionRowDTOs);

		/// <summary>
		///  Deletes existing row.
		/// </summary>
		/// <param name="id">Used to find necessary poll.</param>
		Task DeleteOptionRowAsync(int id);
	}
}
