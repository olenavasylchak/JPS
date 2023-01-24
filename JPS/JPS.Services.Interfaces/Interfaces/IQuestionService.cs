using JPS.Services.DTO.DTOs.QuestionDTOs;
using JPS.Services.DTO.DTOs.QuestionDTOs.UpdateDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JPS.Services.Interfaces.Interfaces
{
	/// <summary>
	/// Holds declaration of methods for working with questions.
	/// </summary>
	public interface IQuestionService
	{
		/// <summary>
		/// Gets all questions by pollId.
		/// </summary>
		/// <param name="pollId">Used to find questions that belong to the poll.</param>
		/// <returns>Questions that belong to the poll.</returns>
		Task<IEnumerable<QuestionDTO>> GetAllQuestionsByPollIdAsync(int pollId);

		/// <summary>
		/// Creates new question.
		/// </summary>
		/// <param name="questionDTO">ModelDTO with fields necessary for creating question.</param>
		/// <returns>Created question.</returns>
		Task<QuestionDTO> CreateQuestionAsync(CreateQuestionDTO questionDTO);

		/// <summary>
		/// Creates new question as a copy of existing question.
		/// </summary>
		/// <param name="id">Id of the question to be copied.</param>
		/// <returns>Created question.</returns>
		Task<QuestionDTO> CopyQuestionAsync(int id);

		/// <summary>
		/// Updates question text field.
		/// </summary>
		/// <param name="id">Used to find question to be updated.</param>
		/// <param name="questionDTO">ModelDTO with fields necessary for updating question.</param>
		/// <returns>Updated question.</returns>
		Task<QuestionDTO> UpdateQuestionTextAsync(int id, UpdateQuestionTextDTO questionDTO);

		/// <summary>
		/// Updates question isRequired field.
		/// </summary>
		/// <param name="id">Used to find question to be updated.</param>
		/// <param name="questionDTO">ModelDTO with fields necessary for updating question.</param>
		/// <returns>Updated question.</returns>
		Task<QuestionDTO> UpdateQuestionIsRequiredAsync(int id, UpdateQuestionIsRequiredDTO questionDTO);

		/// <summary>
		/// Updates question CanHaveOtherOption field.
		/// </summary>
		/// <param name="id">Used to find question to be updated.</param>
		/// <param name="questionDTO">ModelDTO with fields necessary for updating question.</param>
		/// <returns>Updated question.</returns>
		Task<QuestionDTO> UpdateQuestionsFlagForOtherOptionAsync(int id, UpdateQuestionCanHaveOtherOptionDTO questionDTO);

		/// <summary>
		/// Updates question comment field.
		/// </summary>
		/// <param name="id">Used to find question to be updated.</param>
		/// <param name="questionDTO">ModelDTO with fields necessary for updating question.</param>
		/// <returns>Updated question.</returns>
		Task<QuestionDTO> UpdateQuestionCommentAsync(int id, UpdateQuestionCommentDTO questionDTO);

		/// <summary>
		/// Updates question order and section fields.
		/// </summary>
		/// <param name="questionDTO">ModelDTO with fields necessary for updating question.</param>
		/// <returns>Updated questions.</returns>
		Task<IEnumerable<QuestionDTO>> UpdateQuestionsOrderAsync(IEnumerable<UpdateQuestionOrderDTO> questionDTO);

		/// <summary>
		/// Updates question questionTypeId field.
		/// </summary>
		/// <param name="id">Used to find question to be updated.</param>
		/// <param name="questionDTO">ModelDTO with fields necessary for updating question.</param>
		/// <returns>Updated question.</returns>
		Task<QuestionDTO> UpdateQuestionTypeIdAsync(int id, UpdateQuestionTypeIdDTO questionDTO);

		/// <summary>
		/// Updates question imageId field.
		/// </summary>
		/// <param name="id">Used to find question to be updated.</param>
		/// <param name="questionDTO">ModelDTO with fields necessary for updating question.</param>
		/// <returns>Updated question.</returns>
		Task<QuestionDTO> UpdateQuestionImageUrlAsync(int id, UpdateQuestionImageUrlDTO questionDTO);

		/// <summary>
		/// Updates question videoId field.
		/// </summary>
		/// <param name="id">Used to find question to be updated.</param>
		/// <param name="questionDTO">ModelDTO with fields necessary for updating question.</param>
		/// <returns>Updated question.</returns>
		Task<QuestionDTO> UpdateQuestionVideoUrlAsync(int id, UpdateQuestionVideoUrlDTO questionDTO);

		/// <summary>
		/// Deletes question.
		/// </summary>
		/// <param name="id">Used to find question to be deleted.</param>
		Task DeleteQuestionAsync(int id);
	}
}
