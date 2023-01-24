using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.QuestionViewModels.UpdateViewModels
{
	/// <summary>
	/// Model for updating question section id.
	/// </summary>
	public class UpdateQuestionSectionIdViewModel
	{
		[Required]
		[Range(1, int.MaxValue)]
		public int QuestionSectionId { get; set; }
	}
}
