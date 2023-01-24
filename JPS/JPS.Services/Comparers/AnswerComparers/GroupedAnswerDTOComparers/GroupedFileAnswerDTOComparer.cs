using JPS.Services.DTO.DTOs.AnswerDTOs.GroupedAnswerDTOs;
using System.Collections.Generic;
using System.Linq;

namespace JPS.Services.Comparers.AnswerComparers.GroupedAnswerDTOComparers
{
	public class GroupedFileAnswerDTOComparer : Comparer<GroupedFileAnswerDTO>
	{
		public override int Compare(GroupedFileAnswerDTO x, GroupedFileAnswerDTO y)
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

			if (x.FileAnswers == null && y.FileAnswers != null)
			{
				return -1;
			}

			if (x.FileAnswers != null && y.FileAnswers == null)
			{
				return 1;
			}

			if (x.FileAnswers != null && y.FileAnswers != null)
			{
				if (x.FileAnswers.Count() > y.FileAnswers.Count())
				{
					return -1;
				}


				if (x.FileAnswers.Count() < y.FileAnswers.Count())
				{
					return 1;
				}

				var fileAnswerDTOComparer = new FileAnswerDTOComparer();

				var fileAnswersComparingResult = x.FileAnswers.Zip(y.FileAnswers,
					(first, second) => fileAnswerDTOComparer.Compare(first, second)).FirstOrDefault(result => result != 0);

				if (fileAnswersComparingResult != 0)
				{
					return fileAnswersComparingResult;
				}
			}

			return 0;
		}
	}
}
