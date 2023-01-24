using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.CategoryViewModels.UpdateViewModels
{
	/// <summary>
	/// Model to update category's title
	/// </summary>
	public class UpdateCategoryTitleViewModel
	{
		[Required]
		[StringLength(100)]
		public string Title { get; set; }
	}
}
