using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.PollStyleViewModels.UpdatePollStyleViewModels
{
	/// <summary>
	/// Model for updating poll font.
	/// </summary>
	public class UpdatePollFontViewModel
	{
		[Required]
		public string Font { get; set; }
	}
}
