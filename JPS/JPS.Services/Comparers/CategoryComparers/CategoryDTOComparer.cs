using JPS.Services.Comparers.PollComparers;
using JPS.Services.DTO.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JPS.Services.Comparers.CategoryComparers
{
	public class CategoryDTOComparer : Comparer<CategoryDTO>
	{
		public override int Compare(CategoryDTO x, CategoryDTO y)
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

			if (Nullable.Compare(x.ParentCategoryId, y.ParentCategoryId) != 0)
			{
				Nullable.Compare(x.ParentCategoryId, y.ParentCategoryId);
			}

			if (string.Compare(x.Title, y.Title, StringComparison.Ordinal) != 0)
			{
				return string.Compare(x.Title, y.Title, StringComparison.Ordinal);
			}

			if (DateTimeOffset.Compare(x.CreatedAt, y.CreatedAt) != 0)
			{
				return DateTimeOffset.Compare(x.CreatedAt, y.CreatedAt);
			}

			if (x.Polls == null && y.Polls != null)
			{
				return -1;
			}

			if (x.Polls != null && y.Polls == null)
			{
				return 1;
			}

			if (x.Polls != null && y.Polls != null)
			{

				if (x.Polls.Count() > y.Polls.Count())
				{
					return -1;
				}

				if (x.Polls.Count() < y.Polls.Count())
				{
					return 1;
				}

				var pollDTOComparer = new PollDTOComparer();

				var results = x.Polls.Zip(y.Polls,
					(first, second) => pollDTOComparer.Compare(first, second));

				return results.FirstOrDefault(result => result != 0);
			}

			return 0;
		}
	}
}
