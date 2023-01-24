using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.OptionRowViewModels.UpdateViewModels
{
	/// <summary>
	/// Model to update rows's text.
	/// </summary>
	public class UpdateOptionRowTextViewModel
	{
		[StringLength(100)]
		public string Text { get; set; }
	}
}
