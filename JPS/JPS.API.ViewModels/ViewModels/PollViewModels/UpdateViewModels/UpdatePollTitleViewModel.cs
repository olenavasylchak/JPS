using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.PollViewModels.UpdateViewModels
{
	/// <summary>
	/// Model for updating poll title.
	/// </summary>
	public class UpdatePollTitleViewModel
	{
		[Required]
		[MaxLength(100)]
		public string Title { get; set; }
	}
}
