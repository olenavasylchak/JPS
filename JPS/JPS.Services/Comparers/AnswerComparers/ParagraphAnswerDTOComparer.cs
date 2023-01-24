using JPS.Services.DTO.DTOs.AnswerDTOs;
using System;
using System.Collections.Generic;

namespace JPS.Services.Comparers.AnswerComparers
{
	public class ParagraphAnswerDTOComparer : Comparer<ParagraphAnswerDTO>
	{
		public override int Compare(ParagraphAnswerDTO x, ParagraphAnswerDTO y)
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

			if (string.Compare(x.Text, y.Text, StringComparison.Ordinal) != 0)
			{
				return string.Compare(x.Text, y.Text, StringComparison.Ordinal);
			}

			return 0;
		}
	}
}
