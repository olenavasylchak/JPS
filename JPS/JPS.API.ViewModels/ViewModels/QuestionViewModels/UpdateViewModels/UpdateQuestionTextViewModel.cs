using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.QuestionViewModels.UpdateViewModels
{
	/// <summary>
	/// Model for updating question text.
	/// </summary>
	public class UpdateQuestionTextViewModel
	{
		[Required]
		public string Text { get; set; }
	}
}
