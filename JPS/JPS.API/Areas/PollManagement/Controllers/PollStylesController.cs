using AutoMapper;
using JPS.API.ViewModels.ValidationAttributes;
using JPS.API.ViewModels.ViewModels.PollStyleViewModels;
using JPS.API.ViewModels.ViewModels.PollStyleViewModels.UpdatePollStyleViewModels;
using JPS.Services.DTO.DTOs.PollStyleDTOs.UpdateDTOs;
using JPS.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace JPS.API.Areas.PollManagement.Controllers
{
	/// <summary>
	/// This controller allows update poll styles.
	/// </summary>
	[Area("poll-management")]
	[Route("api/[area]/poll-styles")]
	public class PollStylesController : ControllerBase
	{
		private readonly IPollStyleService _pollStyleService;
		private readonly IMapper _mapper;

		public PollStylesController(IPollStyleService pollStyleService, IMapper mapper)
		{
			_pollStyleService = pollStyleService;
			_mapper = mapper;
		}

		/// <summary>
		/// Updates poll font by id.
		/// </summary>
		/// <param name="id">Used to find necessary poll.</param>
		/// <param name="pollFontViewModel">Model with fields to be updated.</param>
		/// <returns>Updated poll style.</returns>
		[HttpPut("{id}/font")]
		[ProducesResponseType(typeof(PollStyleViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult> UpdatePollFontAsync(
			[NumericIdGreaterThanZero] int id,
			[FromBody] UpdatePollFontViewModel pollFontViewModel)
		{
			var pollFontDTO = _mapper.Map<UpdatePollFontDTO>(pollFontViewModel);
			var pollStyleDTO = await _pollStyleService.UpdatePollFontAsync(id, pollFontDTO);
			var pollStyleViewModel = _mapper.Map<PollStyleViewModel>(pollStyleDTO);
			return Ok(pollStyleViewModel);
		}

		/// <summary>
		/// Updates poll theme color by id.
		/// </summary>
		/// <param name="id">Used to find necessary poll.</param>
		/// <param name="themeColorViewModel">Model with fields to be updated.</param>
		/// <returns>Updated poll style.</returns>
		[HttpPut("{id}/theme-color")]
		[ProducesResponseType(typeof(PollStyleViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult> UpdatePollThemeColorAsync(
			[NumericIdGreaterThanZero] int id,
			[FromBody] UpdatePollThemeColorViewModel themeColorViewModel)
		{
			var pollThemeColorDTO = _mapper.Map<UpdatePollThemeColorDTO>(themeColorViewModel);
			var pollStyleDTO = await _pollStyleService.UpdatePollThemeColorAsync(id, pollThemeColorDTO);
			var pollStyleViewModel = _mapper.Map<PollStyleViewModel>(pollStyleDTO);
			return Ok(pollStyleViewModel);
		}

		/// <summary>
		/// Updates poll opacity by id.
		/// </summary>
		/// <param name="id">Used to find necessary poll.</param>
		/// <param name="opacityViewModel">Model with fields to be updated.</param>
		/// <returns>Updated poll style.</returns>
		[HttpPut("{id}/opacity")]
		[ProducesResponseType(typeof(PollStyleViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult> UpdatePollOpacityAsync(
			[NumericIdGreaterThanZero] int id,
			[FromBody] UpdatePollOpacityViewModel opacityViewModel)
		{
			var pollOpacityDTO = _mapper.Map<UpdatePollOpacityDTO>(opacityViewModel);
			var pollStyleDTO = await _pollStyleService.UpdatePollOpacityAsync(id, pollOpacityDTO);
			var pollStyleViewModel = _mapper.Map<PollStyleViewModel>(pollStyleDTO);
			return Ok(pollStyleViewModel);
		}

		/// <summary>
		/// Updates poll image url by id.
		/// </summary>
		/// <param name="id">Used to find necessary poll.</param>
		/// <param name="imageViewModel">Model with fields to be updated.</param>
		/// <returns>Updated poll style.</returns>
		[HttpPut("{id}/image-url")]
		[ProducesResponseType(typeof(PollStyleViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult> UpdatePollImageAsync(
			[NumericIdGreaterThanZero] int id,
			[FromBody] UpdatePollImageViewModel imageViewModel)
		{
			var pollImageDTO = _mapper.Map<UpdatePollImageDTO>(imageViewModel);
			var pollStyleDTO = await _pollStyleService.UpdatePollImageAsync(id, pollImageDTO);
			var pollStyleViewModel = _mapper.Map<PollStyleViewModel>(pollStyleDTO);
			return Ok(pollStyleViewModel);
		}

		/// <summary>
		/// Updates poll image coordinates by id.
		/// </summary>
		/// <param name="id">Used to find necessary poll.</param>
		/// <param name="imageCoordinatesViewModel">Model with fields to be updated.</param>
		/// <returns>Updated poll style.</returns>
		[HttpPut("{id}/image-coordinates")]
		[ProducesResponseType(typeof(PollStyleViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult> UpdatePollImageCoordinatesAsync(
			[NumericIdGreaterThanZero] int id,
			[FromBody] UpdatePollImageCoordinatesViewModel imageCoordinatesViewModel)
		{
			var pollImageCoordinatesDTO = _mapper.Map<UpdatePollImageCoordinatesDTO>(imageCoordinatesViewModel);
			var pollStyleDTO = await _pollStyleService.UpdatePollImageCoordinatesAsync(id, pollImageCoordinatesDTO);
			var pollStyleViewModel = _mapper.Map<PollStyleViewModel>(pollStyleDTO);
			return Ok(pollStyleViewModel);
		}
	}
}
