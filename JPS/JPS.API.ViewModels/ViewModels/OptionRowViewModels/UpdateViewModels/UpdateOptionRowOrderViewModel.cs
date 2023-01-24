using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.OptionRowViewModels.UpdateViewModels
{
	/// <summary>
	/// Model to update rows's order.
	/// </summary>
	public class UpdateOptionRowOrderViewModel
	{
		[Required]
		[Range(1, int.MaxValue)]
		public int Id { get; set; }

		[Required]
		[Range(1, int.MaxValue)]
		public int Order { get; set; }
	}
}
