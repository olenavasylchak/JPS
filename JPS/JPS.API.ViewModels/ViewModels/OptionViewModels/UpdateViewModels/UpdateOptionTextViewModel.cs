using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.OptionViewModels.UpdateViewModels
{
	/// <summary>
	/// Model for updating option text.
	/// </summary>
	public class UpdateOptionTextViewModel
	{
		[MaxLength(100)]
		public string Text { get; set; }
	}
}
