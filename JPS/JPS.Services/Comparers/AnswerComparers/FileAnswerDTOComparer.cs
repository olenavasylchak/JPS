using JPS.Services.DTO.DTOs.AnswerDTOs;
using System;
using System.Collections.Generic;

namespace JPS.Services.Comparers.AnswerComparers
{
	public class FileAnswerDTOComparer : Comparer<FileAnswerDTO>
	{
		public override int Compare(FileAnswerDTO x, FileAnswerDTO y)
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

			if (string.Compare(x.FileUrl, y.FileUrl, StringComparison.Ordinal) != 0)
			{
				return string.Compare(x.FileUrl, y.FileUrl, StringComparison.Ordinal);
			}

			return 0;
		}
	}
}
