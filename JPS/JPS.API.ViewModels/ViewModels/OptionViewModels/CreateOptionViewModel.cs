using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.OptionViewModels
{
	/// <summary>
	/// Model for creating new option.
	/// </summary>
	public class CreateOptionViewModel
	{
		[Required]
		[Range(1, int.MaxValue)]
		public int QuestionId { get; set; }

		[MaxLength(100)]
		public string Text { get; set; }

		public string ImageUrl { get; set; }

		[Required]
		[Range(1, int.MaxValue)]
		public int Order { get; set; }

		public decimal? Value { get; set; }
	}
}
