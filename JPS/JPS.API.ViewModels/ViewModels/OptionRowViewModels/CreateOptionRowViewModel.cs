using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.OptionRowViewModels
{
	/// <summary>
	/// Model for creating new row.
	/// </summary>
	public class CreateOptionRowViewModel
	{
		[Required]
		[Range(1, int.MaxValue)]
		public int QuestionId { get; set; }
		[StringLength(100)]
		public string Text { get; set; }

		public string ImageUrl { get; set; }

		[Required]
		[Range(1, int.MaxValue)]
		public int Order { get; set; }
	}
}
