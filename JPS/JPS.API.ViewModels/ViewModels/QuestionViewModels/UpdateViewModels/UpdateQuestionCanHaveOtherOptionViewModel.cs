using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.QuestionViewModels.UpdateViewModels
{
	/// <summary>
	/// Model for updating question flag that indicates ability to have other option.
	/// </summary>
	public class UpdateQuestionCanHaveOtherOptionViewModel
	{
		[Required]
		public bool CanHaveOtherOption { get; set; }
	}
}
