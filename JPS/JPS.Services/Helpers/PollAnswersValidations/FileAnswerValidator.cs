using JPS.Domain.Entities.Entities;
using JPS.Services.Constants;
using JPS.Services.DTO.DTOs.AnswerDTOs.CreateDTOs;
using System;

namespace JPS.Services.Helpers.PollAnswersValidations
{
	public class FileAnswerValidator : AnswerValidator
	{
		protected override void ValidateRequiredQuestion(QuestionEntity question, PollAnswersDTO pollAnswerDTO)
		{
			if (pollAnswerDTO.FileAnswer == null ||
				pollAnswerDTO.FileAnswer.FileUrl == string.Empty)
			{
				throw new ArgumentException(ExceptionMessageConstants.NotAllRequiredQuestionAnsweredMessage);
			}
		}
	}
}
