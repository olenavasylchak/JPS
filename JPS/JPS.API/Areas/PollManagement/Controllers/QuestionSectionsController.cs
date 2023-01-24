using AutoMapper;
using JPS.API.ViewModels.ValidationAttributes;
using JPS.API.ViewModels.ViewModels.QuestionSectionViewModels;
using JPS.API.ViewModels.ViewModels.QuestionSectionViewModels.UpdateViewModels;
using JPS.Services.DTO.DTOs.QuestionSectionDTOs;
using JPS.Services.DTO.DTOs.QuestionSectionDTOs.UpdateDTOs;
using JPS.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace JPS.API.Areas.PollManagement.Controllers
{
	/// <summary>
	/// QuestionSectionsController provides methods that respond 
	/// to HTTP requests related to working with question sections.
	/// </summary>
	[Area("poll-management")]
	[Route("api/[area]/questionSections")]
	public class QuestionSectionsController : ControllerBase
	{
		private readonly IQuestionSectionService _questionSectionService;
		private readonly IMapper _mapper;

		public QuestionSectionsController(IQuestionSectionService questionSectionService, IMapper mapper)
		{
			_mapper = mapper;
			_questionSectionService = questionSectionService;
		}

		/// <summary>
		/// Gets all sections by poll id.
		/// </summary>
		/// <param name="pollId">Used to find necessary sections.</param>
		/// <returns>Collection of sections.</returns>
		[HttpGet("{pollId}")]
		[ProducesResponseType(typeof(IEnumerable<QuestionSectionViewModel>), (int)HttpStatusCode.OK)]

		public async Task<ActionResult<IEnumerable<QuestionSectionViewModel>>> GetAllSectionsInPollAsync(
			[Required][NumericIdGreaterThanZero] int pollId)
		{
			var questionSectionDTOs = await _questionSectionService.GetAllSectionsByPollIdAsync(pollId);

			var questionSections = _mapper.Map<IEnumerable<QuestionSectionViewModel>>(questionSectionDTOs);
			return Ok(questionSections);
		}

		/// <summary>
		/// Gets all sections with questions by poll id.
		/// </summary>
		/// <param name="pollId">Used to find necessary sections.</param>
		/// <returns>Collection of sections with questions.</returns>
		[HttpGet("with-questions/{pollId}")]
		[ProducesResponseType(typeof(IEnumerable<QuestionSectionWithQuestionsViewModel>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<QuestionSectionWithQuestionsViewModel>>> 
			GetAllSectionsWithQuestionsByPollIdAsync([Required][NumericIdGreaterThanZero] int pollId)
		{
			var questionSectionDTOs = await _questionSectionService.GetAllSectionsWithQuestionsByPollIdAsync(pollId);

			var questionSections = _mapper.Map<IEnumerable<QuestionSectionWithQuestionsViewModel>>(questionSectionDTOs);
			return Ok(questionSections);
		}

		/// <summary>
		/// Creates section.
		/// </summary>
		/// <param name="questionSection">ViewModel with fields necessary for creating new section.</param>
		/// <returns>Created section.</returns>
		[HttpPost]
		[ProducesResponseType(typeof(QuestionSectionViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<QuestionSectionViewModel>> CreateQuestionSectionAsync(
			[FromBody] CreateQuestionSectionViewModel questionSection)
		{
			var questionSectionToCreateDTO = _mapper.Map<CreateQuestionSectionDTO>(questionSection);

			var createdQuestionSectionDTO = await _questionSectionService.CreateQuestionSectionAsync(questionSectionToCreateDTO);

			var createdQuestionSection = _mapper.Map<QuestionSectionViewModel>(createdQuestionSectionDTO);
			return Ok(createdQuestionSection);
		}

		/// <summary>
		/// Updates section title.
		/// </summary>
		/// <param name="sectionId">Used to find necessary section.</param>
		/// <param name="questionSectionTitle">ViewModel with fields necessary for update section title.</param>
		/// <returns>Updated section.</returns>
		[HttpPut("title/{sectionId}")]
		[ProducesResponseType(typeof(QuestionSectionViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<QuestionSectionViewModel>> UpdateQuestionSectionTitleAsync(
			[Required][NumericIdGreaterThanZero] int sectionId,
			[FromBody] UpdateQuestionSectionTitleViewModel questionSectionTitle)
		{
			var questionSectionTitleToUpdateDTO = _mapper
				.Map<UpdateQuestionSectionTitleDTO>(questionSectionTitle);

			var updatedQuestionSectionDTO = await _questionSectionService
				.UpdateQuestionSectionTitleAsync(sectionId, questionSectionTitleToUpdateDTO);

			var updatedQuestionSection = _mapper.Map<QuestionSectionViewModel>(updatedQuestionSectionDTO);
			return Ok(updatedQuestionSection);
		}

		/// <summary>
		/// Updates section description.
		/// </summary>
		/// <param name="sectionId">Used to find necessary section.</param>
		/// <param name="questionSectionDescription">ViewModel with fields necessary for update section description.</param>
		/// <returns>Updated section.</returns>
		[HttpPut("description/{sectionId}")]
		[ProducesResponseType(typeof(QuestionSectionViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<QuestionSectionViewModel>> UpdateQuestionSectionDescriptionAsync(
			[Required][NumericIdGreaterThanZero] int sectionId,
			[FromBody] UpdateQuestionSectionDescriptionViewModel questionSectionDescription)
		{
			var questionSectionDescriptionToUpdateDTO = _mapper
				.Map<UpdateQuestionSectionDescriptionDTO>(questionSectionDescription);

			var updatedQuestionSectionDTO = await _questionSectionService
				.UpdateQuestionSectionDescriptionAsync(sectionId, questionSectionDescriptionToUpdateDTO);

			var updatedQuestionSection = _mapper.Map<QuestionSectionViewModel>(updatedQuestionSectionDTO);
			return Ok(updatedQuestionSection);
		}

		/// <summary>
		/// Updates all sections order in one poll.
		/// </summary>
		/// <param name="questionSectionsOrder">ViewModel with fields necessary for update sections orders.</param>
		/// <returns>Updated sections.</returns>
		[HttpPut("order")]
		[ProducesResponseType(typeof(IEnumerable<QuestionSectionViewModel>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<QuestionSectionViewModel>>> UpdateQuestionSectionsOrderAsync(
			[FromBody] IEnumerable<UpdateQuestionSectionOrderViewModel> questionSectionsOrder)
		{
			var questionSectionsOrderToUpdateDTO = _mapper
				.Map<IEnumerable<UpdateQuestionSectionOrderDTO>>(questionSectionsOrder);

			var updatedQuestionSectionDTOs = await _questionSectionService
				.UpdateQuestionSectionOrdersAsync(questionSectionsOrderToUpdateDTO);

			var updatedQuestionSections = _mapper.Map<IEnumerable<QuestionSectionViewModel>>(updatedQuestionSectionDTOs);
			return Ok(updatedQuestionSections);
		}

		/// <summary>
		/// Deletes section.
		/// </summary>
		/// <param name="sectionId">Used to find necessary section.</param>
		[HttpDelete("{sectionId}")]
		public async Task<ActionResult> DeleteQuestionSectionAsync([Required][NumericIdGreaterThanZero] int sectionId)
		{
			await _questionSectionService.DeleteQuestionSectionAsync(sectionId);
			return NoContent();
		}
	}
}