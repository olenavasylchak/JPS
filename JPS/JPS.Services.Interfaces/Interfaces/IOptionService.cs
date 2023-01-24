using JPS.Services.DTO.DTOs.OptionDTOs;
using JPS.Services.DTO.DTOs.OptionDTOs.UpdateDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JPS.Services.Interfaces.Interfaces
{
	/// <summary>
	/// Holds declaration of methods for working with options.
	/// </summary>
	public interface IOptionService
	{
		/// <summary>
		/// Creates new option.
		/// </summary>
		/// <param name="optionDTO">ModelDTO with fields necessary for creating option.</param>
		/// <returns>Created option.</returns>
		Task<OptionDTO> CreateOptionAsync(CreateOptionDTO optionDTO);

		/// <summary>
		/// Updates option text field.
		/// </summary>
		/// <param name="id">Used to find option to be updated.</param>
		/// <param name="optionDTO">ModelDTO with fields necessary for updating option.</param>
		/// <returns>Updated option.</returns>
		Task<OptionDTO> UpdateOptionTextAsync(int id, UpdateOptionTextDTO optionDTO);

		/// <summary>
		/// Updates option image.
		/// </summary>
		/// <param name="id">Used to find option to be updated.</param>
		/// <param name="optionDTO">ModelDTO with fields necessary for updating option.</param>
		/// <returns>Updated option.</returns>
		Task<OptionDTO> UpdateOptionImageAsync(int id, UpdateOptionImageDTO optionDTO);

		/// <summary>
		/// Updates options order.
		/// </summary>
		/// <param name="optionDTOs"> Collection of modelDTOs with fields necessary for updating options order.</param>
		/// <returns>Updated options.</returns>
		Task<IEnumerable<OptionDTO>> UpdateOptionsOrderAsync(IEnumerable<UpdateOptionOrderDTO> optionDTOs);

		/// <summary>
		/// Updates option value.
		/// </summary>
		/// <param name="id">Used to find option to be updated.</param>
		/// <param name="optionDTO">ModelDTO with fields necessary for updating option.</param>
		/// <returns>Updated option.</returns>
		Task<OptionDTO> UpdateOptionValueAsync(int id, UpdateOptionValueDTO optionDTO);

		/// <summary>
		/// Deletes option.
		/// </summary>
		/// <param name="id">Used to find option to be deleted.</param>
		Task DeleteOptionAsync(int id);
	}
}
