using System;
using System.Collections.Generic;
using System.Text;
using JPS.Services.Comparers.PollComparers;
using JPS.Services.DTO.DTOs.PollDTOs.AnalyticsDTOs;

namespace JPS.Services.Comparers.AnalyticsComparers
{
	public class PollAnalyticsWithoutQuestionsDTOComparer : Comparer<PollAnalyticsWithoutQuestionsDTO>
	{
		public override int Compare (PollAnalyticsWithoutQuestionsDTO x, PollAnalyticsWithoutQuestionsDTO y)
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

			if (x.Progress.CompareTo(y.Progress) != 0)
			{
				return x.Progress.CompareTo(y.Progress);
			}

			return 0;
		}
	}
}
