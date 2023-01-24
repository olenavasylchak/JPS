using System.Collections.Generic;
using JPS.API.ViewModels.ViewModels.PollViewModels;

namespace JPS.API.ViewModels.ViewModels.CategoryViewModels
{
	/// <summary>
	/// Model that contains all categories as a tree and polls without category.
	/// </summary>
	public class CategoriesTreeAndPollsViewModel
	{
		public IEnumerable<CategoryViewModel> CategoriesTree { get; set; }
		public IEnumerable<PollViewModel> PollsWithoutCategory { get; set; }
	}
}
