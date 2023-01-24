using JPS.Services.Comparers.AnswerComparers;
using JPS.Services.Comparers.OptionComparers;
using JPS.Services.Comparers.OptionRowComparers;
using JPS.Services.DTO.DTOs.QuestionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JPS.Services.Comparers.QuestionComparers
{
	public class QuestionDTOComparer : Comparer<QuestionDTO>
	{
		public override int Compare(QuestionDTO x, QuestionDTO y)
		{
			if (x == null && y == null)
			{
				return 0;
			}

			if (x == null)
			{
				return -1;
			}

			if (y == null)
			{
				return 1;
			}

			if (x.Id.CompareTo(y.Id) != 0)
			{
				return x.Id.CompareTo(y.Id);
			}

			if (string.Compare(x.Text, y.Text, StringComparison.Ordinal) != 0)
			{
				return string.Compare(x.Text, y.Text, StringComparison.Ordinal);
			}

			if (x.QuestionSectionId.CompareTo(y.QuestionSectionId) != 0)
			{
				return x.QuestionSectionId.CompareTo(y.QuestionSectionId);
			}

			if (x.CanHaveOtherOption.CompareTo(y.CanHaveOtherOption) != 0)
			{
				return x.CanHaveOtherOption.CompareTo(y.CanHaveOtherOption);
			}

			if (x.IsRequired.CompareTo(y.IsRequired) != 0)
			{
				return x.IsRequired.CompareTo(y.IsRequired);
			}

			if (string.Compare(x.Comment, y.Comment, StringComparison.Ordinal) != 0)
			{
				return string.Compare(x.Comment, y.Comment, StringComparison.Ordinal);
			}

			if (x.Order.CompareTo(y.Order) != 0)
			{
				return x.Order.CompareTo(y.Order);
			}

			if (x.QuestionTypeId.CompareTo(y.QuestionTypeId) != 0)
			{
				return x.QuestionTypeId.CompareTo(y.QuestionTypeId);
			}

			if (string.Compare(x.ImageUrl, y.ImageUrl, StringComparison.Ordinal) != 0)
			{
				return string.Compare(x.ImageUrl, y.ImageUrl, StringComparison.Ordinal);
			}

			if (string.Compare(x.VideoUrl, y.VideoUrl, StringComparison.Ordinal) != 0)
			{
				return string.Compare(x.VideoUrl, y.VideoUrl, StringComparison.Ordinal);
			}

			if (x.Options == null && y.Options != null)
			{
				return -1;
			}

			if (x.Options != null && y.Options == null)
			{
				return 1;
			}

			if (x.Options != null && y.Options != null)
			{
				if (x.Options.Count() > y.Options.Count())
				{
					return -1;
				}

				if (x.Options.Count() < y.Options.Count())
				{
					return 1;
				}

				var questionOptionDTOComparer = new QuestionOptionDTOComparer();

				var optionResults = x.Options.Zip(y.Options,
					(first, second) => questionOptionDTOComparer.Compare(first, second));

				var hasNotZeroResult = optionResults.Any(result => result != 0);
				if (hasNotZeroResult)
				{
					return optionResults.First(result => result != 0);
				}
			}

			if (x.Answers == null && y.Answers != null)
			{
				return -1;
			}

			if (x.Answers != null && y.Answers == null)
			{
				return 1;
			}

			if (x.Answers != null && y.Answers != null)
			{

				if (x.Answers.Count() > y.Answers.Count())
				{
					return -1;
				}

				if (x.Answers.Count() < y.Answers.Count())
				{
					return 1;
				}

				var answerDTOComparer = new AnswerDTOComparer();

				var answerResults = x.Answers.Zip(y.Answers,
					(first, second) => answerDTOComparer.Compare(first, second));

				var hasNotZeroResult = answerResults.Any(result => result != 0);
				if (hasNotZeroResult)
				{
					return answerResults.First(result => result != 0);
				}
			}

			if (x.OptionRows == null && y.OptionRows != null)
			{
				return -1;
			}

			if (x.OptionRows != null && y.OptionRows == null)
			{
				return 1;
			}

			if (x.OptionRows != null && y.OptionRows != null)
			{

				if (x.OptionRows.Count() > y.OptionRows.Count())
				{
					return -1;
				}

				if (x.OptionRows.Count() < y.OptionRows.Count())
				{
					return 1;
				}

				var optionRowDTOComparer = new OptionRowDTOComparer();

				var optionRowResults = x.OptionRows.Zip(y.OptionRows,
					(first, second) => optionRowDTOComparer.Compare(first, second));

				var hasNotZeroResult = optionRowResults.Any(result => result != 0);
				if (hasNotZeroResult)
				{
					return optionRowResults.First(result => result != 0);
				}
			}

			return 0;
		}
	}
}
