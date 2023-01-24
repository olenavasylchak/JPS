using AutoMapper;
using JPS.API.ViewModels.ValidationAttributes;
using JPS.API.ViewModels.ViewModels.OptionViewModels;
using JPS.API.ViewModels.ViewModels.OptionViewModels.UpdateViewModels;
using JPS.Services.DTO.DTOs.OptionDTOs;
using JPS.Services.DTO.DTOs.OptionDTOs.UpdateDTOs;
using JPS.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace JPS.API.Areas.PollManagement.Controllers
{
	/// <summary>
	/// OptionsController provides methods that respond to HTTP requests related to working with options.
	/// </summary>
	[Area("poll-management")]
	[Route("api/[area]/options")]
	public class OptionsController : ControllerBase
	{
		private readonly IOptionService _optionService;
		private readonly IMapper _mapper;
		public OptionsController(IOptionService optionService, IMapper mapper)
		{
			_optionService = optionService;
			_mapper = mapper;
		}

		/// <summary>
		/// Creates option.
		/// </summary>
		/// <param name="optionViewModel">Option model.</param>
		/// <returns>Created option.</returns>
		[HttpPost]
		[ProducesResponseType(typeof(OptionViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<OptionViewModel>> CreateOptionAsync([FromBody] CreateOptionViewModel optionViewModel)
		{
			var optionDTO = _mapper.Map<CreateOptionDTO>(optionViewModel);
			var createdOptionDTO = await _optionService.CreateOptionAsync(optionDTO);
			var createdOptionViewModel = _mapper.Map<OptionViewModel>(createdOptionDTO);
			return Ok(createdOptionViewModel);
		}

		/// <summary>
		/// Updates option text.
		/// </summary>
		/// <param name="id">Used to find option to be updated.</param>
		/// <param name="optionTextViewModel">Model with fields necessary for updating option.</param>
		/// <returns>Updated option.</returns>
		[HttpPut("{id}/option-text")]
		[ProducesResponseType(typeof(OptionViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<OptionViewModel>> UpdateOptionTextAsync(
			[Required][NumericIdGreaterThanZero] int id,
			[FromBody] UpdateOptionTextViewModel optionTextViewModel)
		{
			var optionTextDTO = _mapper.Map<UpdateOptionTextDTO>(optionTextViewModel);
			var optionDTO = await _optionService.UpdateOptionTextAsync(id, optionTextDTO);
			var optionViewModel = _mapper.Map<OptionViewModel>(optionDTO);
			return Ok(optionViewModel);
		}

		/// <summary>
		/// Updates option image.
		/// </summary>
		/// <param name="id">Used to find option to be updated.</param>
		/// <param name="optionImageViewModel">Model with fields necessary for updating option.</param>
		/// <returns>Updated option.</returns>
		[HttpPut("{id}/option-image")]
		[ProducesResponseType(typeof(OptionViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<OptionViewModel>> UpdateOptionImageAsync(
			[Required][NumericIdGreaterThanZero] int id,
			[FromBody] UpdateOptionImageViewModel optionImageViewModel)
		{
			var optionImageDTO = _mapper.Map<UpdateOptionImageDTO>(optionImageViewModel);
			var optionDTO = await _optionService.UpdateOptionImageAsync(id, optionImageDTO);
			var optionViewModel = _mapper.Map<OptionViewModel>(optionDTO);
			return Ok(optionViewModel);
		}

		/// <summary>
		/// Updates all options order in one question.
		/// </summary>
		/// <param name="optionsOrderViewModel">Collection of models with fields necessary for updating options.</param>
		/// <returns>Updated options.</returns>
		[HttpPut("option-order")]
		[ProducesResponseType(typeof(IEnumerable<OptionViewModel>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<OptionViewModel>>> UpdateOptionsOrderAsync(
			[FromBody] IEnumerable<UpdateOptionOrderViewModel> optionsOrderViewModel)
		{
			var optionOrderDTO = _mapper.Map<IEnumerable<UpdateOptionOrderDTO>>(optionsOrderViewModel);
			var optionDTO = await _optionService.UpdateOptionsOrderAsync(optionOrderDTO);
			var optionViewModel = _mapper.Map<IEnumerable<OptionViewModel>>(optionDTO);
			return Ok(optionViewModel);
		}

		/// <summary>
		/// Updates option value.
		/// </summary>
		/// <param name="id">Used to find option to be updated.</param>
		/// <param name="optionValueViewModel">Model with fields necessary for updating option.</param>
		/// <returns>Updated option.</returns>
		[HttpPut("{id}/option-value")]
		[ProducesResponseType(typeof(OptionViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<OptionViewModel>> UpdateOptionValueAsync(
			[Required][NumericIdGreaterThanZero] int id,
			[FromBody] UpdateOptionValueViewModel optionValueViewModel)
		{
			var optionValueDTO = _mapper.Map<UpdateOptionValueDTO>(optionValueViewModel);
			var optionDTO = await _optionService.UpdateOptionValueAsync(id, optionValueDTO);
			var optionViewModel = _mapper.Map<OptionViewModel>(optionDTO);
			return Ok(optionViewModel);
		}

		/// <summary>
		/// Deletes option.
		/// </summary>
		/// <param name="id">Used to find option to be deleted.</param>
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteOptionAsync([Required][NumericIdGreaterThanZero] int id)
		{
			await _optionService.DeleteOptionAsync(id);
			return NoContent();
		}
	}
}