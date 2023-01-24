using JPS.Services.DTO.DTOs.PollStyleDTOs;
using JPS.Services.DTO.DTOs.PollStyleDTOs.UpdateDTOs;
using System.Threading.Tasks;

namespace JPS.Services.Interfaces.Interfaces
{
	/// <summary>
	/// Holds declaration of methods for working with poll styles.
	/// </summary>
	public interface IPollStyleService
	{
		/// <summary>
		/// Updates font.
		/// </summary>
		/// <param name="id">Used to find poll to be updated.</param>
		/// <param name="pollFontDTO">ModelDTO with fields necessary for updating poll font.</param>
		/// <returns>Updated style.</returns>
		Task<PollStyleDTO> UpdatePollFontAsync(int id, UpdatePollFontDTO pollFontDTO);

		/// <summary>
		/// Updates theme color.
		/// </summary>
		/// <param name="id">Used to find poll to be updated.</param>
		/// <param name="pollThemeColorDTO">ModelDTO with fields necessary for updating poll theme color.</param>
		/// <returns>Updated style.</returns>
		Task<PollStyleDTO> UpdatePollThemeColorAsync(int id, UpdatePollThemeColorDTO pollThemeColorDTO);

		/// <summary>
		/// Updates opacity.
		/// </summary>
		/// <param name="id">Used to find poll to be updated.</param>
		/// <param name="pollOpacityDTO">ModelDTO with fields necessary for updating opacity.</param>
		/// <returns>Updated style.</returns>
		Task<PollStyleDTO> UpdatePollOpacityAsync(int id, UpdatePollOpacityDTO pollOpacityDTO);

		/// <summary>
		/// Updates poll image url.
		/// </summary>
		/// <param name="id">Used to find poll to be updated.</param>
		/// <param name="pollImageDTO">ModelDTO with fields necessary for updating poll image url.</param>
		/// <returns>Updated style.</returns>
		Task<PollStyleDTO> UpdatePollImageAsync(int id, UpdatePollImageDTO pollImageDTO);

		/// <summary>
		/// Updates poll image coordinates.
		/// </summary>
		/// <param name="id">Used to find poll to be updated.</param>
		/// <param name="pollImageCoordinatesDTO">ModelDTO with fields necessary for updating image coordinates.</param>
		/// <returns>Updated style.</returns>
		Task<PollStyleDTO> UpdatePollImageCoordinatesAsync(int id, UpdatePollImageCoordinatesDTO pollImageCoordinatesDTO);
	}
}
