using JPS.Services.Comparers.QuestionSectionComparers;
using JPS.Services.DTO.DTOs.PollDTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JPS.Services.Comparers.PollComparers
{
	public class PollDTOComparer : Comparer<PollDTO>
	{
		public override int Compare(PollDTO x, PollDTO y)
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
				Nullable.Compare(x.CategoryId, y.CategoryId);
			}

			if (Nullable.Compare(x.FinishesAt, y.FinishesAt) != 0)
			{
				Nullable.Compare(x.FinishesAt, y.FinishesAt);
			}

			if (Nullable.Compare(x.StartsAt, y.StartsAt) != 0)
			{
				Nullable.Compare(x.StartsAt, y.StartsAt);
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


				var questionSectionComparer = new QuestionSectionDTOComparer();

				var results = x.QuestionSections.Zip(y.QuestionSections,
					(first, second) => questionSectionComparer.Compare(first, second));

				return results.FirstOrDefault(result => result != 0);
			}

			return 0;
		}
	}
}
