using JPS.Services.Comparers.AnswerComparers.GroupedAnswerDTOComparers;
using JPS.Services.DTO.DTOs.PollDTOs.AnalyticsDTOs;
using System;
using System.Collections.Generic;

namespace JPS.Services.Comparers.AnalyticsComparers
{
	public class QuestionAnalyticsDTOComparer : Comparer<QuestionAnalyticsDTO>
	{
		public override int Compare(QuestionAnalyticsDTO x, QuestionAnalyticsDTO y)
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

			var groupAnswerComparingResult = new GroupedAnswerDTOComparer().Compare(x.GroupedAnswers, y.GroupedAnswers);
			if (groupAnswerComparingResult != 0)
			{
				return groupAnswerComparingResult;
			}

			return 0;
		}
	}
}
