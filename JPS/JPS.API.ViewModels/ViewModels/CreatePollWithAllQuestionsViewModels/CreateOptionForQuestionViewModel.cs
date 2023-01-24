using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.CreatePollWithAllQuestionsViewModels
{
	/// <summary>
	/// Model for creating option for question.
	/// </summary>
	public class CreateOptionForQuestionViewModel
	{
		[MaxLength(100)]
		public string Text { get; set; }

		public string ImageUrl { get; set; }

		[Required]
		[Range(1, int.MaxValue)]
		public int Order { get; set; }

		public decimal? Value { get; set; }
	}
}
