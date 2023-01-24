using AutoMapper;
using JPS.API.ViewModels.ValidationAttributes;
using JPS.API.ViewModels.ViewModels.OptionRowViewModels;
using JPS.API.ViewModels.ViewModels.OptionRowViewModels.UpdateViewModels;
using JPS.Services.DTO.DTOs.OptionRowDTOs;
using JPS.Services.DTO.DTOs.OptionRowDTOs.UpdateDTOs;
using JPS.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace JPS.API.Areas.PollManagement.Controllers
{
	/// <summary>
	/// This controller allows create and update  rows.
	/// </summary>
	[Area("poll-management")]
	[Route("api/[area]/option-rows")]
	public class OptionRowsController : ControllerBase
	{
		private IOptionRowService _optionRowService;
		private IMapper _mapper;

		public OptionRowsController(IOptionRowService optionRowService, IMapper mapper)
		{
			_optionRowService = optionRowService;
			_mapper = mapper;
		}

		/// <summary>
		/// Creates new row.
		/// </summary>
		/// <param name="createOptionRowViewModel">Model with fields necessary for creating new category.</param>
		/// <returns>Created category.</returns>
		[HttpPost]
		[ProducesResponseType(typeof(OptionRowViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<OptionRowViewModel>> CreateOptionRowAsync(
			[FromBody] CreateOptionRowViewModel createOptionRowViewModel)
		{
			var createOptionRowDTO = _mapper.Map<CreateOptionRowDTO>(createOptionRowViewModel);
			var createdOptionRowDTO = await _optionRowService.CreateOptionRowAsync(createOptionRowDTO);
			var createdOptionRowViewModel = _mapper.Map<OptionRowViewModel>(createdOptionRowDTO);
			return Ok(createdOptionRowViewModel);
		}

		/// <summary>
		/// Updates rows's text by id.
		/// </summary>
		/// <param name="updateOptionRowTextViewModel">Model with fields to be updated.</param>
		/// <param name="id">Used to find necessary row.</param>
		/// <returns>Updated row.</returns>
		[HttpPut("{id}/text")]
		[ProducesResponseType(typeof(OptionRowViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<OptionRowViewModel>> UpdateOptionRowTextAsync(
			[FromBody] UpdateOptionRowTextViewModel updateOptionRowTextViewModel,
			[NumericIdGreaterThanZero] int id)
		{
			var updateOptionRowTextDTO = _mapper.Map<UpdateOptionRowTextDTO>(updateOptionRowTextViewModel);
			var updatedOptionRowDTO = await _optionRowService.UpdateOptionRowTextAsync(updateOptionRowTextDTO, id);
			var updatedOptionRowViewModel = _mapper.Map<OptionRowViewModel>(updatedOptionRowDTO);
			return Ok(updatedOptionRowViewModel);
		}

		/// <summary>
		/// Updates rows's image by id.
		/// </summary>
		/// <param name="updateOptionRowImageViewModel">Model with fields to be updated.</param>
		/// <param name="id">Used to find necessary row.</param>
		/// <returns>Updated row.</returns>
		[HttpPut("{id}/image")]
		[ProducesResponseType(typeof(OptionRowViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<OptionRowViewModel>> UpdateOptionRowImageAsync(
			[FromBody] UpdateOptionRowImageViewModel updateOptionRowImageViewModel,
			[NumericIdGreaterThanZero] int id)
		{
			var updateOptionRowImageDTO = _mapper.Map<UpdateOptionRowImageDTO>(updateOptionRowImageViewModel);
			var updatedOptionRowDTO = await _optionRowService.UpdateOptionRowImageAsync(updateOptionRowImageDTO, id);
			var updatedOptionRowViewModel = _mapper.Map<OptionRowViewModel>(updatedOptionRowDTO);
			return Ok(updatedOptionRowViewModel);
		}

		/// <summary>
		/// Updates all rows order in one question.
		/// </summary>
		/// <param name="updateOptionRowOrderViewModels">Model with fields to be updated.</param>
		/// <returns>Updated rows.</returns>
		[HttpPut("option-row-order")]
		[ProducesResponseType(typeof(IEnumerable<OptionRowViewModel>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<OptionRowViewModel>>> UpdateOptionRowsOrderAsync(
			[FromBody] IEnumerable<UpdateOptionRowOrderViewModel> updateOptionRowOrderViewModels)
		{
			var updateOptionRowsOrderDTOs = _mapper.Map<IEnumerable<UpdateOptionRowOrderDTO>>(updateOptionRowOrderViewModels);
			var updatedOptionRowDTOs = await _optionRowService.UpdateOptionRowsOrderAsync(updateOptionRowsOrderDTOs);
			var updatedOptionRowViewModels = _mapper.Map<IEnumerable<OptionRowViewModel>>(updatedOptionRowDTOs);
			return Ok(updatedOptionRowViewModels);
		}

		/// <summary>
		/// Deletes a row by id.
		/// </summary>
		/// <param name="id">Used to find necessary row.</param>
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteAsync([NumericIdGreaterThanZero] int id)
		{
			await _optionRowService.DeleteOptionRowAsync(id);
			return NoContent();
		}
	}
}