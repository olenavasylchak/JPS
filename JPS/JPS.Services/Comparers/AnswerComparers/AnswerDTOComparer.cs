using JPS.Services.DTO.DTOs.AnswerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JPS.Services.Comparers.AnswerComparers
{
	public class AnswerDTOComparer : Comparer<AnswerDTO>
	{
		public override int Compare(AnswerDTO x, AnswerDTO y)
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

			if (x.Id.CompareTo(y.Id) != 0)
			{
				return x.Id.CompareTo(y.Id);
			}

			if (string.Compare(x.UserId, y.UserId, StringComparison.Ordinal) != 0)
			{
				return string.Compare(x.UserId, y.UserId, StringComparison.Ordinal);
			}

			if (x.QuestionId.CompareTo(y.QuestionId) != 0)
			{
				return x.QuestionId.CompareTo(y.QuestionId);
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
				var dateAnswerResult = dateAnswerDTOComparer.Compare(x.DateAnswer, y.DateAnswer);

				if (dateAnswerResult != 0)
				{
					return dateAnswerResult;
				}
			}

			if (x.TextAnswer == null && y.TextAnswer != null)
			{
				return -1;
			}

			if (x.TextAnswer != null && y.TextAnswer == null)
			{
				return 1;
			}

			if (x.TextAnswer != null && y.TextAnswer != null)
			{
				var textAnswerDTOComparer = new TextAnswerDTOComparer();

				var textAnswerResult = textAnswerDTOComparer.Compare(x.TextAnswer, y.TextAnswer);

				if (textAnswerResult != 0)
				{
					return textAnswerResult;
				}
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

				var timeAnswerResult = timeAnswerDTOComparer.Compare(x.TimeAnswer, y.TimeAnswer);

				if (timeAnswerResult != 0)
				{
					return timeAnswerResult;
				}
			}

			if (x.ParagraphAnswer == null && y.ParagraphAnswer != null)
			{
				return -1;
			}

			if (x.ParagraphAnswer != null && y.ParagraphAnswer == null)
			{
				return 1;
			}

			if (x.ParagraphAnswer != null && y.ParagraphAnswer != null)
			{
				var paragraphAnswerDTOComparer = new ParagraphAnswerDTOComparer();

				var paragraphAnswerResult = paragraphAnswerDTOComparer.Compare(x.ParagraphAnswer, y.ParagraphAnswer);

				if (paragraphAnswerResult != 0)
				{
					return paragraphAnswerResult;
				}
			}

			if (x.FileAnswer == null && y.FileAnswer != null)
			{
				return -1;
			}

			if (x.FileAnswer != null && y.FileAnswer == null)
			{
				return 1;
			}

			if (x.FileAnswer != null && y.FileAnswer != null)
			{
				var fileAnswerDTOComparer = new FileAnswerDTOComparer();

				var fileAnswerResult = fileAnswerDTOComparer.Compare(x.FileAnswer, y.FileAnswer);

				if (fileAnswerResult != 0)
				{
					return fileAnswerResult;
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

			if (x.OptionAnswers.Count() > y.OptionAnswers.Count())
			{
				return -1;
			}

			if (x.OptionAnswers.Count() < y.OptionAnswers.Count())
			{
				return 1;
			}

			var optionAnswerDTOComparer = new OptionAnswerDTOComparer();

			var optionResults = x.OptionAnswers.Zip(y.OptionAnswers,
				(first, second) => optionAnswerDTOComparer.Compare(first, second));

			return optionResults.FirstOrDefault(result => result != 0);
		}
	}
}
