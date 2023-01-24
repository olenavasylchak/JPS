using JPS.Services.DTO.DTOs.AnswerDTOs.GroupedAnswerDTOs;
using System.Collections.Generic;
using System.Linq;

namespace JPS.Services.Comparers.AnswerComparers.GroupedAnswerDTOComparers
{
	public class GroupedTextAnswerDTOComparer : Comparer<GroupedTextAnswerDTO>
	{
		public override int Compare(GroupedTextAnswerDTO x, GroupedTextAnswerDTO y)
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

			if (x.TextAnswers == null && y.TextAnswers != null)
			{
				return -1;
			}

			if (x.TextAnswers != null && y.TextAnswers == null)
			{
				return 1;
			}

			if (x.TextAnswers != null && y.TextAnswers != null)
			{
				if (x.TextAnswers.Count() > y.TextAnswers.Count())
				{
					return -1;
				}

				if (x.TextAnswers.Count() < y.TextAnswers.Count())
				{
					return 1;
				}

				var textAnswerDTOComparer = new TextAnswerDTOComparer();

				var textAnswersComparingResult = x.TextAnswers.Zip(y.TextAnswers,
					(first, second) => textAnswerDTOComparer.Compare(first, second)).FirstOrDefault(result => result != 0);

				if (textAnswersComparingResult != 0)
				{
					return textAnswersComparingResult;
				}
			}

			return 0;
		}
	}
}
