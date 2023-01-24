using JPS.Services.DTO.DTOs.AnswerDTOs.GroupedAnswerDTOs;
using System.Collections.Generic;

namespace JPS.Services.Comparers.AnswerComparers.GroupedAnswerDTOComparers
{
	public class GroupedDateAnswerDTOComparer : Comparer<GroupedDateAnswerDTO>
	{
		public override int Compare(GroupedDateAnswerDTO x, GroupedDateAnswerDTO y)
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

			if (x.DateAnswer == null && y.DateAnswer != null)
			{
				return -1;
			}

			if (x.DateAnswer != null && y.DateAnswer == null)
			{
				return 1;
			}

			if (x.DateAnswer != null && y.DateAnswer != null)
			{
				var dateAnswerDTOComparer = new DateAnswerDTOComparer();

				var dateAnswerDTOComparingResult = dateAnswerDTOComparer.Compare(x.DateAnswer, y.DateAnswer);

				if (dateAnswerDTOComparingResult != 0)
				{
					return dateAnswerDTOComparingResult;
				}
			}

			return 0;
		}
	}
}
