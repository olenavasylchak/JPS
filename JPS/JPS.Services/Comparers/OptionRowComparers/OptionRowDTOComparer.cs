using JPS.Services.DTO.DTOs.OptionRowDTOs;
using System;
using System.Collections.Generic;

namespace JPS.Services.Comparers.OptionRowComparers
{
	public class OptionRowDTOComparer : Comparer<OptionRowDTO>
	{
		public override int Compare(OptionRowDTO x, OptionRowDTO y)
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

			if (x.QuestionId.CompareTo(y.QuestionId) != 0)
			{
				return x.QuestionId.CompareTo(y.QuestionId);
			}

			if (string.Compare(x.Text, y.Text, StringComparison.Ordinal) != 0)
			{
				return string.Compare(x.Text, y.Text, StringComparison.Ordinal);
			}

			if (x.Order.CompareTo(y.Order) != 0)
			{
				return x.Order.CompareTo(y.Order);
			}

			if (string.Compare(x.ImageUrl, y.ImageUrl, StringComparison.Ordinal) != 0)
			{
				return string.Compare(x.ImageUrl, y.ImageUrl, StringComparison.Ordinal);
			}

			return 0;
		}
	}
}