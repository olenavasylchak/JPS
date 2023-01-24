using JPS.API.ViewModels.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.QuestionViewModels
{
	/// <summary>
	/// Model for creating new question.
	/// </summary>
	public class CreateQuestionViewModel
	{
		[Required]
		public string Text { get; set; }

		[Required]
		[Range(1, int.MaxValue)]
		public int QuestionSectionId { get; set; }

		[Required]
		public bool IsRequired { get; set; }
		public bool CanHaveOtherOption { get; set; }

		[MaxLength(250)]
		public string Comment { get; set; }

		[Required]
		[Range(1, int.MaxValue)]
		public int Order { get; set; }

		[Required]
		[QuestionType]
		[Range(1, int.MaxValue)]
		public int QuestionTypeId { get; set; }

		public string ImageUrl { get; set; }

		public string VideoUrl { get; set; }
	}
}
