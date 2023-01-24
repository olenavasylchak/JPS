using JPS.Services.DTO.DTOs.AnswerDTOs.GroupedAnswerDTOs;
using System.Collections.Generic;
using System.Linq;

namespace JPS.Services.Comparers.AnswerComparers.GroupedAnswerDTOComparers
{
	public class GroupedParagraphAnswerDTOComparer : Comparer<GroupedParagraphAnswerDTO>
	{
		public override int Compare(GroupedParagraphAnswerDTO x, GroupedParagraphAnswerDTO y)
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

			if (x.ParagraphAnswers == null && y.ParagraphAnswers != null)
			{
				return -1;
			}

			if (x.ParagraphAnswers != null && y.ParagraphAnswers == null)
			{
				return 1;
			}

			if (x.ParagraphAnswers != null && y.ParagraphAnswers != null)
			{
				if (x.ParagraphAnswers.Count() > y.ParagraphAnswers.Count())
				{
					return -1;
				}

				if (x.ParagraphAnswers.Count() < y.ParagraphAnswers.Count())
				{
					return 1;
				}

				var paragraphAnswerDTOComparer = new ParagraphAnswerDTOComparer();

				var paragraphAnswersComparingResult = x.ParagraphAnswers.Zip(y.ParagraphAnswers,
					(first, second) => paragraphAnswerDTOComparer.Compare(first, second)).FirstOrDefault(result => result != 0);

				if (paragraphAnswersComparingResult != 0)
				{
					return paragraphAnswersComparingResult;
				}
			}

			return 0;
		}
	}
}
