using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.OptionViewModels.UpdateViewModels
{
	/// <summary>
	/// Model for updating option order.
	/// </summary>
	public class UpdateOptionOrderViewModel
	{
		[Required]
		[Range(1, int.MaxValue)]
		public int Id { get; set; }

		[Required]
		[Range(1, int.MaxValue)]
		public int Order { get; set; }
	}
}
