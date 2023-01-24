using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.PollStyleViewModels.UpdatePollStyleViewModels
{
	/// <summary>
	/// Model for updating poll theme color.
	/// </summary>
	public class UpdatePollThemeColorViewModel
	{
		[Required]
		[RegularExpression(StringConstants.StringConstants.ColorRgbRegex)]
		public string ThemeColor { get; set; }
	}
}
