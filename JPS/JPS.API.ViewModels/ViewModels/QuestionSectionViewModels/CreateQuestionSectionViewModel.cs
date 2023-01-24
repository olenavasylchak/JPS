using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.QuestionSectionViewModels
{
	/// <summary>
	/// Model for creation new section.
	/// </summary>
	public class CreateQuestionSectionViewModel
	{
		[Required]
		[Range(1, int.MaxValue)]
		public int PollId { get; set; }

		[MaxLength(100)]
		public string Title { get; set; }

		public string Description { get; set; }

		[Required]
		[Range(1, int.MaxValue)]
		public int Order { get; set; }
	}
}