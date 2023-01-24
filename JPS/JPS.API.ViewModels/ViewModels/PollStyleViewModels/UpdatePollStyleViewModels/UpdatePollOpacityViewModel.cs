using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.PollStyleViewModels.UpdatePollStyleViewModels
{
	/// <summary>
	/// Model for updating opacity.
	/// </summary>
	public class UpdatePollOpacityViewModel
	{
		[Required]
		[Range(0, 100)]
		public decimal Opacity { get; set; }
	}
}
