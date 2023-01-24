using JPS.Services.DTO.DTOs.PollDTOs.AnalyticsDTOs;
using System.Collections.Generic;
using System.Linq;

namespace JPS.Services.Comparers.AnalyticsComparers
{
	public class PollAnalyticsDTOComparer : Comparer<PollAnalyticsDTO>
	{
		public override int Compare(PollAnalyticsDTO x, PollAnalyticsDTO y)
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

				var groupAnswerComparingResult = new PollAnalyticsWithoutQuestionsDTOComparer().Compare(x, y);
				if (groupAnswerComparingResult != 0)
				{
					return groupAnswerComparingResult;
				}

				var groupedOptionAnswerDTOComparer = new QuestionAnalyticsDTOComparer();

				var groupedOptionAnswersComparingResult = x.Questions.Zip(y.Questions,
					(first, second) => groupedOptionAnswerDTOComparer.Compare(first, second)).FirstOrDefault(result => result != 0);

				if (groupedOptionAnswersComparingResult != 0)
				{
					return groupedOptionAnswersComparingResult;
				}
			}
			return 0;
		}
	}
}
