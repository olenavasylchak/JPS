using JPS.Services.Comparers.OptionComparers;
using JPS.Services.DTO.DTOs.AnswerDTOs.GroupedAnswerDTOs;
using System.Collections.Generic;

namespace JPS.Services.Comparers.AnswerComparers.GroupedAnswerDTOComparers
{
	public class GroupedOptionAnswerDTOComparer : Comparer<GroupedOptionAnswerDTO>
	{
		public override int Compare(GroupedOptionAnswerDTO x, GroupedOptionAnswerDTO y)
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

			if (x.OptionAnswer == null && y.OptionAnswer != null)
			{
				return -1;
			}

			if (x.OptionAnswer != null && y.OptionAnswer == null)
			{
				return 1;
			}

			if (x.OptionAnswer != null && y.OptionAnswer != null)
			{
				var optionAnswerDTOComparer = new OptionDTOComparer();

				var optionAnswerDTOComparingResult = optionAnswerDTOComparer.Compare(x.OptionAnswer, y.OptionAnswer);

				if (optionAnswerDTOComparingResult != 0)
				{
					return optionAnswerDTOComparingResult;
				}
			}

			return 0;
		}
	}
}
