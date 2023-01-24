using System;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.CategoryViewModels.UpdateViewModels
{
	/// <summary>
	/// Model to update category's parent
	/// </summary>
	public class UpdateCategoryParentViewModel
	{
		[Range (1,int.MaxValue)]
		public int? ParentCategoryId { get; set; }
	}
}
