using JPS.Domain.Entities.Entities;
using JPS.Services.Constants;
using JPS.Services.DTO.DTOs.AnswerDTOs.CreateDTOs;
using System;
using System.Linq;

namespace JPS.Services.Helpers.PollAnswersValidations
{
	/// <summary>
	/// Class for checkbox type validation.
	/// </summary>
	public class CheckBoxAnswerValidator : OptionableAnswerValidator
	{
		protected override void ValidateRequiredQuestion(QuestionEntity question, PollAnswersDTO pollAnswerDTO)
		{
			if (question.CanHaveOtherOption && pollAnswerDTO.TextAnswer?.Text != null)
			{
				return;
			}

			var hasOptionAnswers = pollAnswerDTO.CheckBoxAnswer != null;
			if (!hasOptionAnswers)
			{
				throw new ArgumentException(ExceptionMessageConstants.NotAllRequiredQuestionAnsweredMessage);
			}
			base.ValidateAtLeastOneOptionExist(pollAnswerDTO.CheckBoxAnswer);
		}

		protected override void ValidateDueToQuestionType(QuestionEntity question, PollAnswersDTO pollAnswerDTO)
		{
			if (pollAnswerDTO.CheckBoxAnswer != null)
			{
				base.ValidateAllOptionsAreRelatedToQuestion(question,
					pollAnswerDTO.CheckBoxAnswer.Select(optionAnswer => optionAnswer.OptionId).ToArray());
			}
		}

		protected override void ValidateDueToOtherOptionFlag(QuestionEntity question, PollAnswersDTO pollAnswerDTO)
		{
			if (!question.CanHaveOtherOption)
			{
				if (pollAnswerDTO.TextAnswer != null)
				{
					throw new ArgumentException(ExceptionMessageConstants.QuestionCannotHaveOtherOptionMessage);
				}
			}
			else
			{
				if (pollAnswerDTO.TextAnswer != null && pollAnswerDTO.TextAnswer.Text == null)
				{
					throw new ArgumentException(ExceptionMessageConstants.TextAnswerWithoutTextMessage);
				}
			}
		}
	}
}
