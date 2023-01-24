using JPS.Domain.Entities.Entities;
using JPS.Services.Constants;
using JPS.Services.DTO.DTOs.AnswerDTOs.CreateDTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JPS.Services.Helpers.PollAnswersValidations
{
	/// <summary>
	/// Abstract class contains all needed validation for questions with options.
	/// </summary>
	public abstract class OptionableAnswerValidator : AnswerValidator
	{
		protected void ValidateAtLeastOneOptionPerRowExist(IEnumerable<CreatePollOptionAnswerDTO> rowOptionAnswer)
		{
			var isNotOptionPerRow = rowOptionAnswer.GroupBy(row => row.OptionRowId.Value).Any(group => group.Count() == 0);
			if (isNotOptionPerRow)
			{
				throw new ArgumentException(ExceptionMessageConstants.NotAllRequiredRowsAnsweredMessage);
			}
		}

		protected void ValidateAllAnswersHaveRow(IEnumerable<CreatePollOptionAnswerDTO> rowOptionAnswer)
		{
			var hasNullRow = rowOptionAnswer.Any(row => !row.OptionRowId.HasValue);
			if (hasNullRow)
			{
				throw new ArgumentException(ExceptionMessageConstants.NotEveryAnswerHaveRowInGridQuestionMessage);
			}
		}

		protected void ValidateAtLeastOneOptionExist(IEnumerable<CreatePollOptionAnswerDTO> optionAnswer)
		{
			var isOptionAnswered = optionAnswer.Any();
			if (!isOptionAnswered)
			{
				throw new ArgumentException(ExceptionMessageConstants.OptionInRequiredQuestionWasntSelectedMessage);
			}
		}
		protected void ValidateNotMoreThanOneOptionChecked(IEnumerable<CreatePollOptionAnswerDTO> rowOptionAnswer)
		{
			var optionAnswers = rowOptionAnswer.Count();
			if (optionAnswers > 1)
			{
				throw new ArgumentException(ExceptionMessageConstants.MoreThanOneOptionSelectedMessage);
			}
		}

		protected void ValidateNotMoreThanOneOptionPerRowChecked(IEnumerable<CreatePollOptionAnswerDTO> rowOptionAnswer)
		{
			var rowsOptionAnswers = rowOptionAnswer.GroupBy(row => row.OptionRowId.Value).Any(group => group.Count() > 1);
			if (rowsOptionAnswers)
			{
				throw new ArgumentException(ExceptionMessageConstants.MoreThanOneOptionSelectedMessage);
			}
		}

		protected void ValidateAllQuestionRowsAnswered(QuestionEntity question,
			IEnumerable<CreatePollOptionAnswerDTO> rowOptionAnswer)
		{
			var areAllRowsAnswered = question.OptionRows.All(rowId => rowOptionAnswer
			.Any(row => row.OptionRowId.HasValue && row.OptionRowId.Value == rowId.Id));
			if (!areAllRowsAnswered)
			{
				throw new ArgumentException(ExceptionMessageConstants.NotAllRequiredRowsAnsweredMessage);
			}
		}

		protected void ValidateAllRowsAreRelatedToQuestion(QuestionEntity question, params int[] rowsId)
		{
			var areAllRowsValid = rowsId.All(rowId => question.OptionRows.Any(row => row.Id == rowId));
			if (!areAllRowsValid)
			{
				throw new ArgumentException(ExceptionMessageConstants.QuestionDoesntHaveRowMessage);
			}
		}

		protected void ValidateAllOptionsAreRelatedToQuestion(QuestionEntity question, params int[] OptionsId)
		{
			var areAllOptionsValid = OptionsId.All(optionId => question.Options.Any(option => option.Id == optionId));
			if (!areAllOptionsValid)
			{
				throw new ArgumentException(ExceptionMessageConstants.QuestionDoesntHaveOptionMessage);
			}
		}

	}
}
