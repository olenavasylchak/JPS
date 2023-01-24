using JPS.Services.DTO.DTOs.AnswerDTOs.GroupedAnswerDTOs;
using System.Collections.Generic;
using System.Linq;

namespace JPS.Services.Comparers.AnswerComparers.GroupedAnswerDTOComparers
{
	public class GroupedAnswerDTOComparer : Comparer<GroupedAnswerDTO>
	{
		public override int Compare(GroupedAnswerDTO x, GroupedAnswerDTO y)
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
				var groupedTextAnswerDTOComparer = new GroupedTextAnswerDTOComparer();
				var textAnswerDTOComparingResult = groupedTextAnswerDTOComparer.Compare(x.TextAnswers, y.TextAnswers);

				if (textAnswerDTOComparingResult != 0)
				{
					return textAnswerDTOComparingResult;
				}
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
				var groupedParagraphAnswerDTOComparer = new GroupedParagraphAnswerDTOComparer();

				var paragraphAnswerDTOComparingResult = groupedParagraphAnswerDTOComparer.Compare(x.ParagraphAnswers, y.ParagraphAnswers);

				if (paragraphAnswerDTOComparingResult != 0)
				{
					return paragraphAnswerDTOComparingResult;
				}
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
				var groupedFileAnswerDTOComparer = new GroupedFileAnswerDTOComparer();

				var fileAnswerDTOComparingResult = groupedFileAnswerDTOComparer.Compare(x.FileAnswers, y.FileAnswers);

				if (fileAnswerDTOComparingResult != 0)
				{
					return fileAnswerDTOComparingResult;
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

				var optionAnswersComparingResult = x.OptionAnswers.Zip(y.OptionAnswers,
					(first, second) => groupedOptionAnswerDTOComparer.Compare(first, second)).FirstOrDefault(result => result != 0);

				if (optionAnswersComparingResult != 0)
				{
					return optionAnswersComparingResult;
				}
			}

			if (x.DateAnswers == null && y.DateAnswers != null)
			{
				return -1;
			}

			if (x.DateAnswers != null && y.DateAnswers == null)
			{
				return 1;
			}

			if (x.DateAnswers != null && y.DateAnswers != null)
			{
				if (x.DateAnswers.Count() > y.DateAnswers.Count())
				{
					return -1;
				}

				if (x.DateAnswers.Count() < y.DateAnswers.Count())
				{
					return 1;
				}

				var groupedDateAnswerDTOComparer = new GroupedDateAnswerDTOComparer();

				var dateAnswersComparingResult = x.DateAnswers.Zip(y.DateAnswers,
					(first, second) => groupedDateAnswerDTOComparer.Compare(first, second)).FirstOrDefault(result => result != 0);

				if (dateAnswersComparingResult != 0)
				{
					return dateAnswersComparingResult;
				}
			}

			if (x.TimeAnswers == null && y.TimeAnswers != null)
			{
				return -1;
			}

			if (x.TimeAnswers != null && y.TimeAnswers == null)
			{
				return 1;
			}

			if (x.TimeAnswers != null && y.TimeAnswers != null)
			{
				if (x.TimeAnswers.Count() > y.TimeAnswers.Count())
				{
					return -1;
				}

				if (x.TimeAnswers.Count() < y.TimeAnswers.Count())
				{
					return 1;
				}

				var groupedTimeAnswerDTOComparer = new GroupedTimeAnswerDTOComparer();

				var timeAnswersComparingResult = x.TimeAnswers.Zip(y.TimeAnswers,
					(first, second) => groupedTimeAnswerDTOComparer.Compare(first, second)).FirstOrDefault(result => result != 0);

				if (timeAnswersComparingResult != 0)
				{
					return timeAnswersComparingResult;
				}
			}

			if (x.GridAnswers == null && y.GridAnswers != null)
			{
				return -1;
			}

			if (x.GridAnswers != null && y.GridAnswers == null)
			{
				return 1;
			}

			if (x.GridAnswers != null && y.GridAnswers != null)
			{
				if (x.GridAnswers.Count() > y.GridAnswers.Count())
				{
					return -1;
				}

				if (x.GridAnswers.Count() < y.GridAnswers.Count())
				{
					return 1;
				}

				var groupedGridAnswerDTOComparer = new GroupedGridAnswerDTOComparer();

				var gridAnswersComparingResult = x.GridAnswers.Zip(y.GridAnswers,
					(first, second) => groupedGridAnswerDTOComparer.Compare(first, second)).FirstOrDefault(result => result != 0);

				if (gridAnswersComparingResult != 0)
				{
					return gridAnswersComparingResult;
				}
			}

			return 0;
		}
	}
}
