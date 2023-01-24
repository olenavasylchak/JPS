using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.QuestionViewModels.UpdateViewModels
{
	/// <summary>
	/// Model for updating question order and section.
	/// </summary>
	public class UpdateQuestionOrderViewModel
	{
		[Required]
		[Range(1, int.MaxValue)]
		public int Id { get; set; }

		[Required]
		[Range(1, int.MaxValue)]
		public int Order { get; set; }

		[Required]
		[Range(1, int.MaxValue)]
		public int SectionId { get; set; }
	}
}
