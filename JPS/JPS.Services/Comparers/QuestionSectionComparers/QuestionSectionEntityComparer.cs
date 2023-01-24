using JPS.Domain.Entities.Entities;
using JPS.Services.Comparers.QuestionComparers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JPS.Services.Comparers.QuestionSectionComparers
{
	public class QuestionSectionEntityComparer : Comparer<QuestionSectionEntity>
	{
		public override int Compare(QuestionSectionEntity x, QuestionSectionEntity y)
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

			if (x.Order.CompareTo(y.Order) != 0)
			{
				return x.Order.CompareTo(y.Order);
			}

			if (string.Compare(x.Title, y.Title, StringComparison.Ordinal) != 0)
			{
				return string.Compare(x.Title, y.Title, StringComparison.Ordinal);
			}

			if (string.Compare(x.Description, y.Description, StringComparison.Ordinal) != 0)
			{
				return string.Compare(x.Description, y.Description, StringComparison.Ordinal);
			}

			if (x.PollId.CompareTo(y.PollId) != 0)
			{
				return x.PollId.CompareTo(y.PollId);
			}

			if (x.Questions == null && y.Questions != null)
			{
				return -1;
			}

			if (x.Questions != null && y.Questions == null)
			{
				return 1;
			}

			if (x.Questions != null && y.Questions != null)
			{
				if (x.Questions.Count() > y.Questions.Count())
				{
					return -1;
				}

				if (x.Questions.Count() < y.Questions.Count())
				{
					return 1;
				}

				var questionEntityComparer = new QuestionEntityComparer();

				var questionComparingResult = x.Questions.Zip(y.Questions,
				(first, second) => questionEntityComparer.Compare(first, second)).FirstOrDefault(result => result != 0);

				if (questionComparingResult != 0)
				{
					return questionComparingResult;
				}
			}

			return 0;
		}
	}
}