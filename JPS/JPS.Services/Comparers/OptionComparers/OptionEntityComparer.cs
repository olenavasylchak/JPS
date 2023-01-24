using JPS.Domain.Entities.Entities;
using System;
using System.Collections.Generic;

namespace JPS.Services.Comparers.OptionComparers
{
	public class OptionEntityComparer : Comparer<OptionEntity>
	{
		public override int Compare(OptionEntity x, OptionEntity y)
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

			if (Nullable.Compare(x.Value, y.Value) != 0)
			{
				return Nullable.Compare(x.Value, y.Value);
			}

			if (x.Order.CompareTo(y.Order) != 0)
			{
				return x.Order.CompareTo(y.Order);
			}

			if (string.Compare(x.Text, y.Text, StringComparison.Ordinal) != 0)
			{
				return string.Compare(x.Text, y.Text, StringComparison.Ordinal);
			}

			if (string.Compare(x.ImageUrl, y.ImageUrl, StringComparison.Ordinal) != 0)
			{
				return string.Compare(x.ImageUrl, y.ImageUrl, StringComparison.Ordinal);
			}

			if (x.QuestionId.CompareTo(y.QuestionId) != 0)
			{
				return x.QuestionId.CompareTo(y.QuestionId);
			}

			return 0;
		}
	}
}
