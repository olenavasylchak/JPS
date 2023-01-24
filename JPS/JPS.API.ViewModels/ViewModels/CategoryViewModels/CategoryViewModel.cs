using System;
using System.Collections.Generic;
using JPS.API.ViewModels.ViewModels.PollViewModels;

namespace JPS.API.ViewModels.ViewModels.CategoryViewModels
{
	/// <summary>
	/// Model for displaying categories as a tree.
	/// </summary>
	public class CategoryViewModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public DateTimeOffset CreatedAt { get; set; }
		public IEnumerable<CategoryViewModel> Children { get; set; }
		public IEnumerable<PollViewModel> Polls { get; set; }
	}
}
