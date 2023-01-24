using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.PollViewModels.UpdateViewModels
{
	/// <summary>
	/// Model for updating poll category id
	/// </summary>
	public class UpdatePollCategoryIdViewModel
	{
		[Range(1, int.MaxValue)]
		public int? CategoryId { get; set; }
	}
}
