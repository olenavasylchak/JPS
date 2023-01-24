using JPS.Services.DTO.DTOs.AnswerDTOs.GroupedAnswerDTOs;
using System.Collections.Generic;

namespace JPS.Services.Comparers.AnswerComparers.GroupedAnswerDTOComparers
{
	public class GroupedTimeAnswerDTOComparer : Comparer<GroupedTimeAnswerDTO>
	{
		public override int Compare(GroupedTimeAnswerDTO x, GroupedTimeAnswerDTO y)
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

			if (x.Count.CompareTo(y.Count) != 0)
			{
				return x.Count.CompareTo(y.Count);
			}

			if (x.PercentageToAll.CompareTo(y.PercentageToAll) != 0)
			{
				return x.PercentageToAll.CompareTo(y.PercentageToAll);
			}

			if (x.PercentageToAlreadyAnswered.CompareTo(y.PercentageToAlreadyAnswered) != 0)
			{
				return x.PercentageToAll.CompareTo(y.PercentageToAlreadyAnswered);
			}

			if (x.TimeAnswer == null && y.TimeAnswer != null)
			{
				return -1;
			}

			if (x.TimeAnswer != null && y.TimeAnswer == null)
			{
				return 1;
			}

			if (x.TimeAnswer != null && y.TimeAnswer != null)
			{
				var timeAnswerDTOComparer = new TimeAnswerDTOComparer();

				var timeAnswerDTOComparingResult = timeAnswerDTOComparer.Compare(x.TimeAnswer, y.TimeAnswer);

				if (timeAnswerDTOComparingResult != 0)
				{
					return timeAnswerDTOComparingResult;
				}
			}

			return 0;
		}
	}
}
