using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.AnswerViewModels.CreateViewModels
{
	/// <summary>
	/// Model for creating new text answer.
	/// </summary>
	public class CreateTextAnswerViewModel
	{
		[Required]
		[MaxLength(250)]
		public string Text { get; set; }
	}
}
