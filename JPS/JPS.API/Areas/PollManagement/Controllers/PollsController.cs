using AutoMapper;
using JPS.API.ViewModels.ValidationAttributes;
using JPS.API.ViewModels.ViewModels.PollViewModels;
using JPS.API.ViewModels.ViewModels.PollViewModels.PollsWithContainedSectionsQuestionsViewModels;
using JPS.API.ViewModels.ViewModels.PollViewModels.UpdateViewModels;
using JPS.Common;
using JPS.Services.DTO.DTOs;
using JPS.Services.DTO.DTOs.PollDTOs;
using JPS.Services.DTO.DTOs.PollDTOs.UpdateDTOs;
using JPS.Services.Interfaces.Interfaces;
using JPS.Services.Services._Utils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace JPS.API.Areas.PollManagement.Controllers
{
	/// <summary>
	/// This controller allows get, create, update and delete polls.
	/// </summary>
	[Area("poll-management")]
	[Route("api/[area]/polls")]
	public class PollsController : ControllerBase
	{
		private readonly IPollService _pollService;
		private readonly IMapper _mapper;

		public PollsController(IPollService service, IMapper mapper)
		{
			_pollService = service;
			_mapper = mapper;
		}

		/// <summary>
		/// Gets polls in the form of tree using pagination. Polls could be filtered by categoryId.
		/// </summary>
		/// <param name="paginationQuery">Used to set pagination properties.</param>
		/// <param name="categoryId">Used to get polls of concrete category.
		/// More than 0 - get polls that belong to category with setted id.
		/// 0 - get all polls.
		/// null - get polls that don't belong to any category.</param>
		/// <returns>Paged list of polls with contained sections questions and options.</returns>
		[HttpGet]
		[ProducesResponseType(typeof(PagedList<PollWithSectionsViewModel>), (int)HttpStatusCode.OK)]
		public async Task<PagedList<PollWithSectionsViewModel>> GetAllPollsAsync(
			[FromQuery] PaginationQuery paginationQuery,
			[Range(0,int.MaxValue)] [FromQuery] int? categoryId = null)
		{
			var paginationQueryDTO = _mapper.Map<PaginationDTO>(paginationQuery);
			var pagedListOfPollDTOs = await _pollService.GetAllPollsAsync(categoryId, paginationQueryDTO);
			var pagedListOfPollViewModels = _mapper.Map<PagedList<PollWithSectionsViewModel>>(pagedListOfPollDTOs);
			return pagedListOfPollViewModels;
		}

		/// <summary>
		/// Gets poll with sections, questions and options by poll id.
		/// </summary>
		/// <param name="id">Used to find necessary poll.</param>
		/// <return>Poll with contained sections questions and options.</return>
		[HttpGet("{id}")]
		[ProducesResponseType(typeof(PollWithSectionsViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<PollWithSectionsViewModel>> GetPollByIdAsync(
			[NumericIdGreaterThanZero] int id)
		{
			var pollDTO = await _pollService.GetPollByIdAsync(id);
			var pollViewModel = _mapper.Map<PollWithSectionsViewModel>(pollDTO);
			return Ok(pollViewModel);
		}

		/// <summary>
		/// Creates new poll.
		/// </summary>
		/// <param name="createPollViewModel">Model with fields necessary for creating new poll.</param>
		/// <returns>Created poll.</returns>
		[HttpPost]
		[ProducesResponseType(typeof(PollViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult> CreatePollAsync([FromBody] CreatePollViewModel createPollViewModel)
		{
			var poll = _mapper.Map<CreatePollDTO>(createPollViewModel);
			var pollDTO = await _pollService.CreatePollAsync(poll);
			var pollViewModel = _mapper.Map<PollViewModel>(pollDTO);
			return Ok(pollViewModel);
		}

		/// <summary>
		/// Creates poll as a copy of existing poll.
		/// </summary>
		/// <param name="id">Id of poll to be copied.</param>
		/// <returns>Created poll.</returns>
		[HttpPost("{id}/copy")]
		[ProducesResponseType(typeof(PollViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<PollViewModel>> CopyPollAsync(
			[NumericIdGreaterThanZero] int id)
		{
			var pollDTO = await _pollService.CopyPollAsync(id);
			var createdPollViewModel = _mapper.Map<PollViewModel>(pollDTO);
			return Ok(createdPollViewModel);
		}

		/// <summary>
		/// Validate poll and publish it.
		/// </summary>
		/// <param name="id">Identifier for the poll to be published.</param>
		/// <returns>Published poll.</returns>
		[HttpPost("{id}/publish")]
		[ProducesResponseType(typeof(ActionResult<PollViewModel>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult> PublishPollAsync(
			[NumericIdGreaterThanZero] int id)
		{
			var publishedPollDTO = await _pollService.PublishPollAsync(id);
			var publishedPollViewModel = _mapper.Map<PollViewModel>(publishedPollDTO);
			return Ok(publishedPollViewModel);
		}

		/// <summary>
		/// Updates poll category by id.
		/// </summary>
		/// <param name="id">Used to find necessary poll.</param>
		/// <param name="pollCategoryId">Model with fields to be updated.</param>
		/// <returns>Updated poll.</returns>
		[HttpPut("{id}/category-id")]
		[ProducesResponseType(typeof(PollViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult> UpdatePollCategoryIdAsync(
			[NumericIdGreaterThanZero] int id,
			[FromBody] UpdatePollCategoryIdViewModel pollCategoryId)
		{
			var poll = _mapper.Map<UpdatePollCategoryIdDTO>(pollCategoryId);
			var pollDTO = await _pollService.UpdatePollCategoryIdAsync(poll, id);
			var pollViewModel = _mapper.Map<PollViewModel>(pollDTO);
			return Ok(pollViewModel);
		}

		/// <summary>
		/// Updates poll title by id.
		/// </summary>
		/// <param name="id">Used to find necessary poll.</param>
		/// <param name="pollTitle">Model with fields to be updated.</param>
		/// <returns>Updated poll.</returns>
		[HttpPut("{id}/title")]
		[ProducesResponseType(typeof(PollViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult> UpdatePollTitleAsync(
			[NumericIdGreaterThanZero] int id,
			[FromBody] UpdatePollTitleViewModel pollTitle)
		{
			var poll = _mapper.Map<UpdatePollTitleDTO>(pollTitle);
			var pollDTO = await _pollService.UpdatePollTitleAsync(poll, id);
			var pollViewModel = _mapper.Map<PollViewModel>(pollDTO);
			return Ok(pollViewModel);
		}

		/// <summary>
		/// Updates poll description by id.
		/// </summary>
		/// <param name="id">Used to find necessary poll.</param>
		/// <param name="pollDescription">Model with fields to be updated.</param>
		/// <returns>Updated poll.</returns>
		[HttpPut("{id}/description")]
		[ProducesResponseType(typeof(PollViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult> UpdatePollDescriptionAsync(
			[NumericIdGreaterThanZero] int id,
			[FromBody] UpdatePollDescriptionViewModel pollDescription)
		{
			var poll = _mapper.Map<UpdatePollDescriptionDTO>(pollDescription);
			var pollDTO = await _pollService.UpdatePollDescriptionAsync(poll, id);
			var pollViewModel = _mapper.Map<PollViewModel>(pollDTO);
			return Ok(pollViewModel);
		}

		/// <summary>
		/// Updates poll start date by id.
		/// </summary>
		/// <param name="id">Used to find necessary poll.</param>
		/// <param name="pollStartDate">Model with fields to be updated.</param>
		/// <returns>Updated poll.</returns>
		[HttpPut("{id}/start-date")]
		[ProducesResponseType(typeof(PollViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult> UpdatePollStartDateAsync(
			[NumericIdGreaterThanZero] int id,
			[FromBody] UpdatePollStartDateViewModel pollStartDate)
		{
			var poll = _mapper.Map<UpdatePollStartDateDTO>(pollStartDate);
			var pollDTO = await _pollService.UpdatePollStartDateAsync(poll, id);
			var pollViewModel = _mapper.Map<PollViewModel>(pollDTO);
			return Ok(pollViewModel);
		}

		/// <summary>
		/// Updates poll finish date by id. 
		/// </summary>
		/// <param name="id">Used to find necessary poll.</param>
		/// <param name="pollFinishDate">Model with fields to be updated.</param>
		/// <returns>Updated poll.</returns>
		[HttpPut("{id}/finish-date")]
		[ProducesResponseType(typeof(PollViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult> UpdateFinishDateAsync(
			[NumericIdGreaterThanZero] int id,
			[FromBody] UpdatePollFinishDateViewModel pollFinishDate)
		{
			var poll = _mapper.Map<UpdatePollFinishDateDTO>(pollFinishDate);
			var pollDTO = await _pollService.UpdatePollFinishDateAsync(poll, id);
			var pollViewModel = _mapper.Map<PollViewModel>(pollDTO);
			return Ok(pollViewModel);
		}

		/// <summary>
		/// Updates poll isAnonymous status by id.
		/// </summary>
		/// <param name="id">Used to find necessary poll.</param>
		/// <param name="pollIsAnonymous">Model with fields to be updated.</param>
		/// <returns>Updated poll.</returns>
		[HttpPut("{id}/anonymous-status")]
		[ProducesResponseType(typeof(PollViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult> UpdateIsAnonymousStatusAsync(
			[NumericIdGreaterThanZero] int id,
			[FromBody] UpdatePollIsAnonymousViewModel pollIsAnonymous)
		{
			var poll = _mapper.Map<UpdatePollIsAnonymousDTO>(pollIsAnonymous);
			var pollDTO = await _pollService.UpdatePollIsAnonymousAsync(poll, id);
			var pollViewModel = _mapper.Map<PollViewModel>(pollDTO);
			return Ok(pollViewModel);
		}

		/// <summary>
		/// Deletes poll by id.
		/// </summary>
		/// <param name="id">Used to find necessary poll.</param>
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeletePollAsync([NumericIdGreaterThanZero] int id)
		{
			await _pollService.DeletePollAsync(id);
			return NoContent();
		}
	}
}