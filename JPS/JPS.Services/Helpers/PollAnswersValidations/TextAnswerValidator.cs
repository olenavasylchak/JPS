using JPS.Domain.Entities.Entities;
using JPS.Services.Constants;
using JPS.Services.DTO.DTOs.AnswerDTOs.CreateDTOs;
using System;

namespace JPS.Services.Helpers.PollAnswersValidations
{
	/// <summary>
	/// Class for the text type validation.
	/// </summary>
	public class TextAnswerValidator : AnswerValidator
	{
		protected override void ValidateRequiredQuestion(QuestionEntity question, PollAnswersDTO pollAnswerDTO)
		{
			if (pollAnswerDTO.TextAnswer == null ||
				string.IsNullOrEmpty(pollAnswerDTO.TextAnswer.Text))
			{
				throw new ArgumentException(ExceptionMessageConstants.NotAllRequiredQuestionAnsweredMessage);
			}
		}
	}
}
