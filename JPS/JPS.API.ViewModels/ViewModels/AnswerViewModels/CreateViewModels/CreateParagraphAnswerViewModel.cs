using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.AnswerViewModels.CreateViewModels
{
	/// <summary>
	/// Model for creating new paragraph answer.
	/// </summary>
	public class CreateParagraphAnswerViewModel
	{
		[Required]
		public string Text { get; set; }
	}
}
