using System;
using System.Collections.Generic;
using JPS.Domain.Entities.Entities;

namespace JPS.Services.Comparers.OptionRowComparers
{
	public class OptionRowEntityComparer : Comparer<OptionRowEntity>
	{
		public override int Compare(OptionRowEntity x, OptionRowEntity y)
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
