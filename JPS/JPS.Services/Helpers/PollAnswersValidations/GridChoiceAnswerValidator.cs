using JPS.Domain.Entities.Entities;
using JPS.Services.Constants;
using JPS.Services.DTO.DTOs.AnswerDTOs.CreateDTOs;
using System;
using System.Linq;

namespace JPS.Services.Helpers.PollAnswersValidations
{
	/// <summary>
	/// Class for the grid choice type validation.
	/// </summary>
	public class GridChoiceAnswerValidator : OptionableAnswerValidator
	{
		protected override void ValidateRequiredQuestion(QuestionEntity question, PollAnswersDTO pollAnswerDTO)
		{
			var hasOptionAnswers = pollAnswerDTO.ChoiceGridAnswer != null;
			if (!hasOptionAnswers)
			{
				throw new ArgumentException(ExceptionMessageConstants.NotAllRequiredQuestionAnsweredMessage);
			}

			base.ValidateAllQuestionRowsAnswered(question, pollAnswerDTO.ChoiceGridAnswer);
		}

		protected override void ValidateDueToQuestionType(QuestionEntity question, PollAnswersDTO pollAnswerDTO)
		{
			if (pollAnswerDTO.ChoiceGridAnswer != null)
			{
				base.ValidateAllAnswersHaveRow(pollAnswerDTO.ChoiceGridAnswer);

				base.ValidateNotMoreThanOneOptionPerRowChecked(pollAnswerDTO.ChoiceGridAnswer);

				base.ValidateAllRowsAreRelatedToQuestion(question,
					pollAnswerDTO.ChoiceGridAnswer.Select(optionAnswer => optionAnswer.OptionRowId.Value).ToArray());

				base.ValidateAllOptionsAreRelatedToQuestion(question,
					pollAnswerDTO.ChoiceGridAnswer.Select(optionAnswer => optionAnswer.OptionId).ToArray());
			}
		}
	}
}
