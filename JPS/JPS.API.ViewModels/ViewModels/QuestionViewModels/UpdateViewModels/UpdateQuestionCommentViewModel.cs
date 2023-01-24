using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.QuestionViewModels.UpdateViewModels
{
	/// <summary>
	/// Model for updating question comment.
	/// </summary>
	public class UpdateQuestionCommentViewModel
	{
		[MaxLength(250)]
		public string Comment { get; set; }
	}
}
