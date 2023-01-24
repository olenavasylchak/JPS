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
	public class ChoiceAnswerValidator : OptionableAnswerValidator
	{
		protected override void ValidateRequiredQuestion(QuestionEntity question, PollAnswersDTO pollAnswerDTO)
		{
			if (question.CanHaveOtherOption && pollAnswerDTO.TextAnswer?.Text != null)
			{
				return;
			}

			var hasOptionAnswers = pollAnswerDTO.ChoiceAnswer != null;
			if (!hasOptionAnswers)
			{
				throw new ArgumentException(ExceptionMessageConstants.NotAllRequiredQuestionAnsweredMessage);
			}
			base.ValidateAtLeastOneOptionExist(pollAnswerDTO.ChoiceAnswer);
		}

		protected override void ValidateDueToQuestionType(QuestionEntity question, PollAnswersDTO pollAnswerDTO)
		{
			if (pollAnswerDTO.ChoiceAnswer != null)
			{
				base.ValidateNotMoreThanOneOptionChecked(pollAnswerDTO.ChoiceAnswer);
				base.ValidateAllOptionsAreRelatedToQuestion(question,
					pollAnswerDTO.ChoiceAnswer.Select(optionAnswer => optionAnswer.OptionId).ToArray());
			}
		}

		protected override void ValidateDueToOtherOptionFlag(QuestionEntity question, PollAnswersDTO pollAnswerDTO)
		{
			if (question.CanHaveOtherOption)
			{
				if (pollAnswerDTO.TextAnswer != null && pollAnswerDTO.ChoiceAnswer?.Any() == true)
				{
					throw new ArgumentException(ExceptionMessageConstants.QuestionCannotHaveOptionAndTextAnswersMessage);
				}
			}
			else
			{
				if (pollAnswerDTO.TextAnswer != null)
				{
					throw new ArgumentException(ExceptionMessageConstants.QuestionCannotHaveOtherOptionMessage);
				}
			}
		}
	}
}
