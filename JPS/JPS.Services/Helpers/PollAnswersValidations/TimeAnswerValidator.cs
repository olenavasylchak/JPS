using JPS.Domain.Entities.Entities;
using JPS.Services.Constants;
using JPS.Services.DTO.DTOs.AnswerDTOs.CreateDTOs;
using System;

namespace JPS.Services.Helpers.PollAnswersValidations
{
	/// <summary>
	/// Class for the time type validation.
	/// </summary>
	public class TimeAnswerValidator : AnswerValidator
	{
		protected override void ValidateRequiredQuestion(QuestionEntity question, PollAnswersDTO pollAnswerDTO)
		{
			if (pollAnswerDTO.TimeAnswer == null ||
				pollAnswerDTO.TimeAnswer.Time == default)
			{
				throw new ArgumentException(ExceptionMessageConstants.NotAllRequiredQuestionAnsweredMessage);
			}
		}
	}
}
