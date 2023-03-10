using JPS.Services.DTO.DTOs.OptionDTOs;
using System;
using System.Collections.Generic;

namespace JPS.Services.Comparers.OptionComparers
{
	public class QuestionOptionDTOComparer:Comparer<QuestionOptionDTO>
	{
		public override int Compare(QuestionOptionDTO x, QuestionOptionDTO y)
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

			if (Nullable.Compare(x.Value, y.Value) != 0)
			{
				Nullable.Compare(x.Value, y.Value);
			}

			return 0;
		}
	}
}
