using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.AnswerViewModels.CreateViewModels
{
	/// <summary>
	/// Model for creating new grid option answer.
	/// </summary>
	public class CreateGridOptionAnswerViewModel
	{
		[Required]
		[Range(1, int.MaxValue)]
		public int OptionId { get; set; }

		[Required]
		[Range(1, int.MaxValue)]
		public int? OptionRowId { get; set; }
	}
}