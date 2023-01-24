using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.CreatePollWithAllQuestionsViewModels
{
	/// <summary>
	/// Model for creating option row for question.
	/// </summary>
	public class CreateOptionRowForQuestionViewModel
	{
		[StringLength(100)]
		public string Text { get; set; }

		public string ImageUrl { get; set; }

		[Required]
		[Range(1, int.MaxValue)]
		public int Order { get; set; }
	}
}
