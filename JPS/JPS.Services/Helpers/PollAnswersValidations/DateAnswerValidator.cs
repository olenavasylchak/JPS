using JPS.Domain.Entities.Entities;
using JPS.Services.Constants;
using JPS.Services.DTO.DTOs.AnswerDTOs.CreateDTOs;
using System;

namespace JPS.Services.Helpers.PollAnswersValidations
{
	/// <summary>
	/// Class for date type validation.
	/// </summary>
	public class DateAnswerValidator : AnswerValidator
	{
		protected override void ValidateRequiredQuestion(QuestionEntity question, PollAnswersDTO pollAnswerDTO)
		{
			if (pollAnswerDTO.DateAnswer == null ||
				pollAnswerDTO.DateAnswer.Date == default)
			{
				throw new ArgumentException(ExceptionMessageConstants.NotAllRequiredQuestionAnsweredMessage);
			}
		}
	}
}
