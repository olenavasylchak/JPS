using System;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.CategoryViewModels
{
	/// <summary>
	/// Model to create new category.
	/// </summary>
	public class CreateCategoryViewModel
	{
		[Required]
		[StringLength(100)]
		public string Title { get; set; }
		[Range(1, int.MaxValue)]
		public int? ParentCategoryId { get; set; }
	}
}
