using AutoMapper;
using JPS.API.ViewModels.ValidationAttributes;
using JPS.API.ViewModels.ViewModels.QuestionViewModels;
using JPS.API.ViewModels.ViewModels.QuestionViewModels.UpdateViewModels;
using JPS.Services.DTO.DTOs.QuestionDTOs;
using JPS.Services.DTO.DTOs.QuestionDTOs.UpdateDTOs;
using JPS.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace JPS.API.Areas.PollManagement.Controllers
{
	/// <summary>
	/// QuestionsController provides methods that respond to HTTP requests related to working with questions.
	/// </summary>
	[Area("poll-management")]
	[Route("api/[area]/questions")]
	public class QuestionsController : ControllerBase
	{
		private IQuestionService _questionService;
		private IMapper _mapper;
		public QuestionsController(IQuestionService questionService, IMapper mapper)
		{
			_questionService = questionService;
			_mapper = mapper;
		}

		/// <summary>
		/// Gets all questions that belong to the poll with given id.
		/// </summary>
		/// <param name="pollId">Used to find the needed poll.</param>
		/// <returns>Questions that belong to the poll.</returns>
		[HttpGet("{pollId}")]
		[ProducesResponseType(typeof(QuestionViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<QuestionViewModel>> GetAllQuestionsByPollIdAsync(
			[Required][NumericIdGreaterThanZero] int pollId)
		{
			var questions = await _questionService.GetAllQuestionsByPollIdAsync(pollId);
			var viewModel = _mapper.Map<IEnumerable<QuestionViewModel>>(questions);
			return Ok(viewModel);
		}

		/// <summary>
		/// Creates question.
		/// </summary>
		/// <param name="questionModel">Model with fields to be created.</param>
		/// <returns>Created question.</returns>
		[HttpPost]
		[ProducesResponseType(typeof(QuestionViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<QuestionViewModel>> CreateQuestionAsync([FromBody] CreateQuestionViewModel questionModel)
		{
			var question = _mapper.Map<CreateQuestionDTO>(questionModel);
			var questionDTO = await _questionService.CreateQuestionAsync(question);
			var createdQuestionViewModel = _mapper.Map<QuestionViewModel>(questionDTO);
			return Ok(createdQuestionViewModel);
		}

		/// <summary>
		/// Creates question as a copy of existing question.
		/// </summary>
		/// <param name="id">Id of the question to be copied.</param>
		/// <returns>Created question.</returns>
		[HttpPost("{id}/copy")]
		[ProducesResponseType(typeof(QuestionViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<QuestionViewModel>> CopyQuestionAsync(
			[NumericIdGreaterThanZero] int id)
		{
			var questionDTO = await _questionService.CopyQuestionAsync(id);
			var createdQuestionViewModel = _mapper.Map<QuestionViewModel>(questionDTO);
			return Ok(createdQuestionViewModel);
		}

		/// <summary>
		/// Updates question text.
		/// </summary>
		/// <param name="id">Used to find question to be updated.</param>
		/// <param name="questionTextModel">Model with fields to be updated.</param>
		/// <returns>Updated question.</returns>
		[HttpPut("{id}/question-text")]
		[ProducesResponseType(typeof(QuestionViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<QuestionViewModel>> UpdateQuestionTextAsync(
			[Required][NumericIdGreaterThanZero] int id,
			[FromBody] UpdateQuestionTextViewModel questionTextModel)
		{
			var questionTextModelDTO = _mapper.Map<UpdateQuestionTextDTO>(questionTextModel);
			var questionDTO = await _questionService.UpdateQuestionTextAsync(id, questionTextModelDTO);
			var questionViewModel = _mapper.Map<QuestionViewModel>(questionDTO);
			return Ok(questionViewModel);
		}

		/// <summary>
		/// Updates question isRequired status.
		/// </summary>
		/// <param name="id">Used to find question to be updated.</param>
		/// <param name="questionIsRequiredModel">Model with fields to be updated.</param>
		/// <returns>Updated question.</returns>
		[HttpPut("{id}/question-is-required")]
		[ProducesResponseType(typeof(QuestionViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<QuestionViewModel>> UpdateQuestionIsRequiredAsync(
			[Required][NumericIdGreaterThanZero] int id,
			[FromBody] UpdateQuestionIsRequiredViewModel questionIsRequiredModel)
		{
			var questionIsRequiredModelDTO = _mapper.Map<UpdateQuestionIsRequiredDTO>(questionIsRequiredModel);
			var questionDTO = await _questionService.UpdateQuestionIsRequiredAsync(id, questionIsRequiredModelDTO);
			var questionViewModel = _mapper.Map<QuestionViewModel>(questionDTO);
			return Ok(questionViewModel);
		}

		/// <summary>
		/// Updates question CanHaveOtherOption status.
		/// </summary>
		/// <param name="id">Used to find question to be updated.</param>
		/// <param name="questionCanHaveOtherOptionModel">Model with fields to be updated.</param>
		/// <returns>Updated question.</returns>
		[HttpPut("{id}/question-other-option")]
		[ProducesResponseType(typeof(QuestionViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<QuestionViewModel>> UpdateQuestionCanHaveOtherOptiondAsync(
			[Required][NumericIdGreaterThanZero] int id,
			[FromBody] UpdateQuestionCanHaveOtherOptionViewModel questionCanHaveOtherOptionModel)
		{
			var questionCanHaveOtherOptionDTO = _mapper.Map<UpdateQuestionCanHaveOtherOptionDTO>(questionCanHaveOtherOptionModel);
			var questionDTO = await _questionService.UpdateQuestionsFlagForOtherOptionAsync(id, questionCanHaveOtherOptionDTO);
			var questionViewModel = _mapper.Map<QuestionViewModel>(questionDTO);
			return Ok(questionViewModel);
		}

		/// <summary>
		/// Updates question comment.
		/// </summary>
		/// <param name="id">Used to find question to be updated.</param>
		/// <param name="questionCommentModel">Model with fields to be updated.</param>
		/// <returns>Updated question.</returns>
		[HttpPut("{id}/question-comment")]
		[ProducesResponseType(typeof(QuestionViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<QuestionViewModel>> UpdateQuestionCommentAsync(
			[Required][NumericIdGreaterThanZero] int id,
			[FromBody] UpdateQuestionCommentViewModel questionCommentModel)
		{
			var questionCommentModelDTO = _mapper.Map<UpdateQuestionCommentDTO>(questionCommentModel);
			var questionDTO = await _questionService.UpdateQuestionCommentAsync(id, questionCommentModelDTO);
			var questionViewModel = _mapper.Map<QuestionViewModel>(questionDTO);
			return Ok(questionViewModel);
		}

		/// <summary>
		/// Updates the order and sections for all questions in one poll.
		/// </summary>
		/// <param name="questionsOrderModel">Model with fields to be updated.</param>
		/// <returns>Updated questions.</returns>
		[HttpPut("question-order")]
		[ProducesResponseType(typeof(IEnumerable<QuestionViewModel>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<QuestionViewModel>>> UpdateQuestionsOrderAsync(
			[FromBody] IEnumerable<UpdateQuestionOrderViewModel> questionsOrderModel)
		{
			var questionsOrderModelDTO = _mapper.Map<IEnumerable<UpdateQuestionOrderDTO>>(questionsOrderModel);
			var questions = await _questionService.UpdateQuestionsOrderAsync(questionsOrderModelDTO);
			var updatedQuestions = _mapper.Map<IEnumerable<QuestionViewModel>>(questions);
			return Ok(updatedQuestions);
		}

		/// <summary>
		/// Updates question type id.
		/// </summary>
		/// <param name="id">Used to find question to be updated.</param>
		/// <param name="questionTypeIdModel">Model with fields to be updated.</param>
		/// <returns>Updated question.</returns>
		[HttpPut("{id}/question-type-id")]
		[ProducesResponseType(typeof(QuestionViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<QuestionViewModel>> UpdateQuestionTypeIdAsync(
			[Required][NumericIdGreaterThanZero] int id,
			[FromBody] UpdateQuestionTypeIdViewModel questionTypeIdModel)
		{
			var questionTypeIdModelDTO = _mapper.Map<UpdateQuestionTypeIdDTO>(questionTypeIdModel);
			var questionDTO = await _questionService.UpdateQuestionTypeIdAsync(id, questionTypeIdModelDTO);
			var questionViewModel = _mapper.Map<QuestionViewModel>(questionDTO);
			return Ok(questionViewModel);
		}

		/// <summary>
		/// Updates question image.
		/// </summary>
		/// <param name="id">Used to find question to be updated.</param>
		/// <param name="questionImageUrlModel">Model with fields to be updated.</param>
		/// <returns>Updated question.</returns>
		[HttpPut("{id}/question-image")]
		[ProducesResponseType(typeof(QuestionViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<QuestionViewModel>> UpdateQuestionImageUrlAsync(
			[Required][NumericIdGreaterThanZero] int id,
			[FromBody] UpdateQuestionImageUrlViewModel questionImageUrlModel)
		{
			var questionImageUrlModelDTO = _mapper.Map<UpdateQuestionImageUrlDTO>(questionImageUrlModel);
			var questionDTO = await _questionService.UpdateQuestionImageUrlAsync(id, questionImageUrlModelDTO);
			var questionViewModel = _mapper.Map<QuestionViewModel>(questionDTO);
			return Ok(questionViewModel);
		}

		/// <summary>
		/// Updates question video.
		/// </summary>
		/// <param name="id">Used to find question to be updated.</param>
		/// <param name="questionVideoUrlModel">Model with fields to be updated.</param>
		/// <returns>Updated question.</returns>
		[HttpPut("{id}/question-video")]
		[ProducesResponseType(typeof(QuestionViewModel), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<QuestionViewModel>> UpdateQuestionVideoUrlAsync(
			[Required][NumericIdGreaterThanZero] int id,
			[FromBody] UpdateQuestionVideoUrlViewModel questionVideoUrlModel)
		{
			var questionVideoUrlModelDTO = _mapper.Map<UpdateQuestionVideoUrlDTO>(questionVideoUrlModel);
			var questionDTO = await _questionService.UpdateQuestionVideoUrlAsync(id, questionVideoUrlModelDTO);
			var questionViewModel = _mapper.Map<QuestionViewModel>(questionDTO);
			return Ok(questionViewModel);
		}

		/// <summary>
		/// Deletes question.
		/// </summary>
		/// <param name="id">Used to find question to be deleted.</param>
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteQuestionAsync([Required][NumericIdGreaterThanZero] int id)
		{
			await _questionService.DeleteQuestionAsync(id);
			return NoContent();
		}
	}
}