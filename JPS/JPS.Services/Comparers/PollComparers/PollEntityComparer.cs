using JPS.Domain.Entities.Entities;
using JPS.Services.Comparers.QuestionSectionComparers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JPS.Services.Comparers.PollComparers
{
	public class PollEntityComparer : Comparer<PollEntity>
	{
		public override int Compare(PollEntity x, PollEntity y)
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

			if (Nullable.Compare(x.CategoryId, y.CategoryId) != 0)
			{
				return Nullable.Compare(x.CategoryId, y.CategoryId);
			}

			if (Nullable.Compare(x.StartsAt, y.StartsAt) != 0)
			{
				return Nullable.Compare(x.StartsAt, y.StartsAt);
			}

			if (Nullable.Compare(x.FinishesAt, y.FinishesAt) != 0)
			{
				return Nullable.Compare(x.FinishesAt, y.FinishesAt);
			}

			if (x.IsAnonymous.CompareTo(y.IsAnonymous) != 0)
			{
				return x.IsAnonymous.CompareTo(y.IsAnonymous);
			}

			if (string.Compare(x.Title, y.Title, StringComparison.Ordinal) != 0)
			{
				return string.Compare(x.Title, y.Title, StringComparison.Ordinal);
			}

			if (string.Compare(x.Description, y.Description, StringComparison.Ordinal) != 0)
			{
				return string.Compare(x.Description, y.Description, StringComparison.Ordinal);
			}

			if (x.QuestionSections == null && y.QuestionSections != null)
			{
				return -1;
			}

			if (x.QuestionSections != null && y.QuestionSections == null)
			{
				return 1;
			}

			if (x.QuestionSections != null && y.QuestionSections != null)
			{
				if (x.QuestionSections.Count() > y.QuestionSections.Count())
				{
					return -1;
				}

				if (x.QuestionSections.Count() < y.QuestionSections.Count())
				{
					return 1;
				}

				var questionSectionEntityComparer = new QuestionSectionEntityComparer();

				var questionSectionComparingResult = x.QuestionSections.Zip(y.QuestionSections,
					(first, second) => questionSectionEntityComparer.Compare(first, second)).FirstOrDefault(result => result != 0);

				if (questionSectionComparingResult != 0)
				{
					return questionSectionComparingResult;
				}
			}

			return 0;
		}
	}
}