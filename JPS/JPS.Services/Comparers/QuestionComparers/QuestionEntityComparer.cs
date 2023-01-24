using JPS.Domain.Entities.Entities;
using JPS.Services.Comparers.OptionComparers;
using JPS.Services.Comparers.OptionRowComparers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JPS.Services.Comparers.QuestionComparers
{
	public class QuestionEntityComparer : Comparer<QuestionEntity>
	{
		public override int Compare(QuestionEntity x, QuestionEntity y)
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

			if (x.QuestionTypeId.CompareTo(y.QuestionTypeId) != 0)
			{
				return x.QuestionTypeId.CompareTo(y.QuestionTypeId);
			}

			if (x.Order.CompareTo(y.Order) != 0)
			{
				return x.Order.CompareTo(y.Order);
			}

			if (x.IsRequired.CompareTo(y.IsRequired) != 0)
			{
				return x.IsRequired.CompareTo(y.IsRequired);
			}

			if (x.CanHaveOtherOption.CompareTo(y.CanHaveOtherOption) != 0)
			{
				return x.CanHaveOtherOption.CompareTo(y.CanHaveOtherOption);
			}

			if (Nullable.Compare(x.PrototypeQuestionId, y.PrototypeQuestionId) != 0)
			{
				return Nullable.Compare(x.PrototypeQuestionId, y.PrototypeQuestionId);
			}

			if (string.Compare(x.Text, y.Text, StringComparison.Ordinal) != 0)
			{
				return string.Compare(x.Text, y.Text, StringComparison.Ordinal);
			}

			if (string.Compare(x.Comment, y.Comment, StringComparison.Ordinal) != 0)
			{
				return string.Compare(x.Comment, y.Comment, StringComparison.Ordinal);
			}

			if (string.Compare(x.ImageUrl, y.ImageUrl, StringComparison.Ordinal) != 0)
			{
				return string.Compare(x.ImageUrl, y.ImageUrl, StringComparison.Ordinal);
			}

			if (string.Compare(x.VideoUrl, y.VideoUrl, StringComparison.Ordinal) != 0)
			{
				return string.Compare(x.VideoUrl, y.VideoUrl, StringComparison.Ordinal);
			}

			if (x.QuestionSectionId.CompareTo(y.QuestionSectionId) != 0)
			{
				return x.QuestionSectionId.CompareTo(y.QuestionSectionId);
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

				var optionEntityComparer = new OptionEntityComparer();

				var optionComparingResult = x.Options.Zip(y.Options,
				(first, second) => optionEntityComparer.Compare(first, second)).FirstOrDefault(result => result != 0);

				if (optionComparingResult != 0)
				{
					return optionComparingResult;
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

				var optionRowEntityComparer = new OptionRowEntityComparer();

				var optionRowComparingResult = x.OptionRows.Zip(y.OptionRows,
					(first, second) => optionRowEntityComparer.Compare(first, second)).FirstOrDefault(result => result != 0);

				if (optionRowComparingResult != 0)
				{
					return optionRowComparingResult;
				}
			}

			return 0;
		}
	}
}
