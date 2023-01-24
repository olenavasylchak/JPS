using JPS.Services.Comparers.OptionRowComparers;
using JPS.Services.DTO.DTOs.AnswerDTOs.GroupedAnswerDTOs;
using System.Collections.Generic;
using System.Linq;

namespace JPS.Services.Comparers.AnswerComparers.GroupedAnswerDTOComparers
{
	public class GroupedGridAnswerDTOComparer : Comparer<GroupedGridAnswerDTO>
	{
		public override int Compare(GroupedGridAnswerDTO x, GroupedGridAnswerDTO y)
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

			if (x.OptionRow == null && y.OptionRow != null)
			{
				return -1;
			}

			if (x.OptionRow != null && y.OptionRow == null)
			{
				return 1;
			}

			if (x.OptionRow != null && y.OptionRow != null)
			{
				var optionAnswerDTOComparer = new OptionRowDTOComparer();

				var optionAnswerDTOComparingResult = optionAnswerDTOComparer.Compare(x.OptionRow, y.OptionRow);

				if (optionAnswerDTOComparingResult != 0)
				{
					return optionAnswerDTOComparingResult;
				}
			}

			if (x.OptionAnswers == null && y.OptionAnswers != null)
			{
				return -1;
			}

			if (x.OptionAnswers != null && y.OptionAnswers == null)
			{
				return 1;
			}

			if (x.OptionAnswers != null && y.OptionAnswers != null)
			{
				if (x.OptionAnswers.Count() > y.OptionAnswers.Count())
				{
					return -1;
				}

				if (x.OptionAnswers.Count() < y.OptionAnswers.Count())
				{
					return 1;
				}

				var groupedOptionAnswerDTOComparer = new GroupedOptionAnswerDTOComparer();

				var groupedOptionAnswersComparingResult = x.OptionAnswers.Zip(y.OptionAnswers,
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
