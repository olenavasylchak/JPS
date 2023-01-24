using JPS.Services.DTO.DTOs.AnswerDTOs;
using System;
using System.Collections.Generic;

namespace JPS.Services.Comparers.AnswerComparers
{
	public class OptionAnswerDTOComparer : Comparer<OptionAnswerDTO>
	{
		public override int Compare(OptionAnswerDTO x, OptionAnswerDTO y)
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

			if (x.AnswerId.CompareTo(y.AnswerId) != 0)
			{
				return x.AnswerId.CompareTo(y.AnswerId);
			}

			if (x.OptionId.CompareTo(y.OptionId) != 0)
			{
				return x.OptionId.CompareTo(y.OptionId);
			}

			if (Nullable.Compare(x.OptionRowId, y.OptionRowId) != 0)
			{
				Nullable.Compare(x.OptionRowId, y.OptionRowId);
			}

			return 0;
		}
	}
}
