using JPS.Domain.Entities.Entities;
using JPS.Services.Constants;
using JPS.Services.DTO.DTOs.AnswerDTOs.CreateDTOs;
using System;
using System.Linq;

namespace JPS.Services.Helpers.PollAnswersValidations
{
	/// <summary>
	/// Class for choice type validation.
	/// </summary>
	public class DropDownAnswerValidator : OptionableAnswerValidator
	{
		protected override void ValidateRequiredQuestion(QuestionEntity question, PollAnswersDTO pollAnswerDTO)
		{
			var hasOptionAnswers = pollAnswerDTO.DropdownAnswer != null;
			if (!hasOptionAnswers)
			{
				throw new ArgumentException(ExceptionMessageConstants.NotAllRequiredQuestionAnsweredMessage);
			}
			base.ValidateAtLeastOneOptionExist(pollAnswerDTO.DropdownAnswer);
		}

		protected override void ValidateDueToQuestionType(QuestionEntity question, PollAnswersDTO pollAnswerDTO)
		{
			if (pollAnswerDTO.DropdownAnswer != null)
			{
				base.ValidateNotMoreThanOneOptionChecked(pollAnswerDTO.DropdownAnswer);
				base.ValidateAllOptionsAreRelatedToQuestion(question,
					pollAnswerDTO.DropdownAnswer.Select(optionAnswer => optionAnswer.OptionId).ToArray());
			}
		}
	}
}
