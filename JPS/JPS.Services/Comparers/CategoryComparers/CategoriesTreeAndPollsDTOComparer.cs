using JPS.Services.Comparers.PollComparers;
using JPS.Services.DTO.DTOs.CategoryDTOs;
using System.Collections.Generic;
using System.Linq;

namespace JPS.Services.Comparers.CategoryComparers
{
	public class CategoriesTreeAndPollsDTOComparer : Comparer<CategoriesTreeAndPollsDTO>
	{
		public override int Compare(CategoriesTreeAndPollsDTO x, CategoriesTreeAndPollsDTO y)
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

			if (x.CategoriesTree == null && y.CategoriesTree != null)
			{
				return -1;
			}

			if (x.CategoriesTree != null && y.CategoriesTree == null)
			{
				return 1;
			}

			if (x.CategoriesTree != null && y.CategoriesTree != null)
			{

				if (x.CategoriesTree.Count() > y.CategoriesTree.Count())
				{
					return -1;
				}

				if (x.CategoriesTree.Count() < y.CategoriesTree.Count())
				{
					return 1;
				}

				var categoryComparer = new CategoryDTOComparer();

				var results = x.CategoriesTree.Zip(y.CategoriesTree,
					(first, second) => categoryComparer.Compare(first, second));

				return results.FirstOrDefault(result => result != 0);
			}

			if (x.PollsWithoutCategory == null && y.PollsWithoutCategory != null)
			{
				return -1;
			}

			if (x.PollsWithoutCategory != null && y.PollsWithoutCategory == null)
			{
				return 1;
			}

			if (x.PollsWithoutCategory != null && y.PollsWithoutCategory != null)
			{

				if (x.PollsWithoutCategory.Count() > y.PollsWithoutCategory.Count())
				{
					return -1;
				}

				if (x.PollsWithoutCategory.Count() < y.PollsWithoutCategory.Count())
				{
					return 1;
				}


				var pollComparer = new PollDTOComparer();

				var results = x.PollsWithoutCategory.Zip(y.PollsWithoutCategory,
					(first, second) => pollComparer.Compare(first, second));

				return results.FirstOrDefault(result => result != 0);
			}
			return 0;
		}
	}
}
