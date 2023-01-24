using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.QuestionSectionViewModels.UpdateViewModels
{
	/// <summary>
	/// Model for updating section title.
	/// </summary>
	public class UpdateQuestionSectionTitleViewModel
	{
		[MaxLength(100)]
		public string Title { get; set; }
	}
}
