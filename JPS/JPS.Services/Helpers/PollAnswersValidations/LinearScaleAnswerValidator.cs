using JPS.Domain.Entities.Entities;
using JPS.Services.Constants;
using JPS.Services.DTO.DTOs.AnswerDTOs.CreateDTOs;
using System;
using System.Linq;

namespace JPS.Services.Helpers.PollAnswersValidations
{
	public class LinearScaleAnswerValidator : OptionableAnswerValidator
	{
		protected override void ValidateRequiredQuestion(QuestionEntity question, PollAnswersDTO pollAnswerDTO)
		{
			var hasOptionAnswers = pollAnswerDTO.LinearScaleAnswer != null;
			if (!hasOptionAnswers)
			{
				throw new ArgumentException(ExceptionMessageConstants.NotAllRequiredQuestionAnsweredMessage);
			}
			base.ValidateAtLeastOneOptionExist(pollAnswerDTO.LinearScaleAnswer);
		}

		protected override void ValidateDueToQuestionType(QuestionEntity question, PollAnswersDTO pollAnswerDTO)
		{
			if (pollAnswerDTO.LinearScaleAnswer != null)
			{
				base.ValidateNotMoreThanOneOptionChecked(pollAnswerDTO.LinearScaleAnswer);
				base.ValidateAllOptionsAreRelatedToQuestion(question,
					pollAnswerDTO.LinearScaleAnswer.Select(optionAnswer => optionAnswer.OptionId).ToArray());
			}
		}
	}
}
