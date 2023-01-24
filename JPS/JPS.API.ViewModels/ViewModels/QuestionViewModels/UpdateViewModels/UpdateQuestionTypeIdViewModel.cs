using System.ComponentModel.DataAnnotations;
using JPS.API.ViewModels.ValidationAttributes;

namespace JPS.API.ViewModels.ViewModels.QuestionViewModels.UpdateViewModels
{
	/// <summary>
	/// Model for updating question type id.
	/// </summary>
	public class UpdateQuestionTypeIdViewModel
	{
		[Required]
		[QuestionType]
		[Range(1, int.MaxValue)]
		public int QuestionTypeId { get; set; }
	}
}
