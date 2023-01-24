using JPS.Services.DTO.DTOs.PollDTOs.AnalyticsDTOs;
using System.Collections.Generic;
using System.Linq;

namespace JPS.Services.Comparers.AnalyticsComparers
{
	public class PollComparisonDTOComparer : Comparer<PollComparisonDTO>
	{
		public override int Compare(PollComparisonDTO x, PollComparisonDTO y)
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

			var firstPollComparingResult = new PollAnalyticsWithoutQuestionsDTOComparer().Compare(x.FirstPoll, y.FirstPoll);
			if (firstPollComparingResult != 0)
			{
				return firstPollComparingResult;
			}

			var secondPollComparingResult = new PollAnalyticsWithoutQuestionsDTOComparer().Compare(x.SecondPoll, y.SecondPoll);
			if (secondPollComparingResult != 0)
			{
				return secondPollComparingResult;
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

				using var xQuestionEnumerator = x.Questions.GetEnumerator();
				using var yQuestionEnumerator = y.Questions.GetEnumerator();
				while (xQuestionEnumerator.MoveNext() && yQuestionEnumerator.MoveNext())
				{
					if (xQuestionEnumerator.Current == null && yQuestionEnumerator.Current != null)
					{
						return -1;
					}

					if (xQuestionEnumerator.Current != null && yQuestionEnumerator.Current == null)
					{
						return 1;
					}

					if (xQuestionEnumerator.Current != null && yQuestionEnumerator.Current != null)
					{
						if (xQuestionEnumerator.Current.Count() > yQuestionEnumerator.Current.Count())
						{
							return -1;
						}

						if (xQuestionEnumerator.Current.Count() < yQuestionEnumerator.Current.Count())
						{
							return 1;
						}

						var questionAnalyticsComparer = new QuestionAnalyticsDTOComparer();

						var questionComparingResult = xQuestionEnumerator.Current.Zip(yQuestionEnumerator.Current,
							(first, second) => questionAnalyticsComparer.Compare(first, second)).FirstOrDefault(result => result != 0);

						if (questionComparingResult != 0)
						{
							return questionComparingResult;
						}
					}
				}
			}
			return 0;
		}
	}
}
