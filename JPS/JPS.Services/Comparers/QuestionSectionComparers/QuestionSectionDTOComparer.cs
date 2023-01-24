using System;
using JPS.Services.DTO.DTOs.QuestionSectionDTOs;
using System.Collections.Generic;
using System.Linq;
using JPS.Services.Comparers.QuestionComparers;

namespace JPS.Services.Comparers.QuestionSectionComparers
{
	public class QuestionSectionDTOComparer : Comparer<QuestionSectionDTO>
	{
		public override int Compare(QuestionSectionDTO x, QuestionSectionDTO y)
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

			if (x.PollId.CompareTo(y.PollId) != 0)
			{
				return x.PollId.CompareTo(y.PollId);
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

				var questionComparer = new QuestionDTOComparer();

				var results = x.Questions.Zip(y.Questions,
					(first, second) => questionComparer.Compare(first, second));

				return results.FirstOrDefault(result => result != 0);
			}

			return 0;
		}
	}
}
