using JPS.Services.DTO.DTOs.AnswerDTOs;
using System;
using System.Collections.Generic;

namespace JPS.Services.Comparers.AnswerComparers
{
	public class TimeAnswerDTOComparer : Comparer<TimeAnswerDTO>
	{
		public override int Compare(TimeAnswerDTO x, TimeAnswerDTO y)
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

			if (TimeSpan.Compare(x.Time, y.Time) != 0)
			{
				return TimeSpan.Compare(x.Time, y.Time);
			}

			return 0;
		}
	}
}
