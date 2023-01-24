using JPS.Services.DTO.DTOs.AnswerDTOs;
using System;
using System.Collections.Generic;

namespace JPS.Services.Comparers.AnswerComparers
{
	public class DateAnswerDTOComparer : Comparer<DateAnswerDTO>
	{
		public override int Compare(DateAnswerDTO x, DateAnswerDTO y)
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

			if (DateTimeOffset.Compare(x.Date, y.Date) != 0)
			{
				return DateTimeOffset.Compare(x.Date, y.Date);
			}

			return 0;
		}
	}
}
