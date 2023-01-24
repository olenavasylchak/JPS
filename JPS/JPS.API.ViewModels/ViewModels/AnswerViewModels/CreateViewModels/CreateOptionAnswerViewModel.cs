using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.AnswerViewModels.CreateViewModels
{
	/// <summary>
	/// Model for creating new option answer.
	/// </summary>
	public class CreateOptionAnswerViewModel
	{
		[Required]
		[Range(1, int.MaxValue)]
		public int OptionId { get; set; }
	}
}
