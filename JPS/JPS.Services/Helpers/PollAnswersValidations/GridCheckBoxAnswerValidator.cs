using JPS.Domain.Entities.Entities;
using JPS.Services.Constants;
using JPS.Services.DTO.DTOs.AnswerDTOs.CreateDTOs;
using System;
using System.Linq;

namespace JPS.Services.Helpers.PollAnswersValidations
{
	/// <summary>
	/// Class for grid checkbox type validation.
	/// </summary>
	public class GridCheckBoxAnswerValidator : OptionableAnswerValidator
	{
		protected override void ValidateRequiredQuestion(QuestionEntity question, PollAnswersDTO pollAnswerDTO)
		{
			var hasOptionAnswers = pollAnswerDTO.CheckBoxGridAnswers != null;
			if (!hasOptionAnswers)
			{
				throw new ArgumentException(ExceptionMessageConstants.NotAllRequiredQuestionAnsweredMessage);
			}

			base.ValidateAllQuestionRowsAnswered(question, pollAnswerDTO.CheckBoxGridAnswers);

		}

		protected override void ValidateDueToQuestionType(QuestionEntity question, PollAnswersDTO pollAnswerDTO)
		{
			if (pollAnswerDTO.CheckBoxGridAnswers != null)
			{
				base.ValidateAllAnswersHaveRow(pollAnswerDTO.CheckBoxGridAnswers);

				base.ValidateAllRowsAreRelatedToQuestion(question,
					pollAnswerDTO.CheckBoxGridAnswers.Select(optionAnswer => optionAnswer.OptionRowId.Value).ToArray());

				base.ValidateAllOptionsAreRelatedToQuestion(question,
					pollAnswerDTO.CheckBoxGridAnswers.Select(optionAnswer => optionAnswer.OptionId).ToArray());
			}
		}
	}
}
