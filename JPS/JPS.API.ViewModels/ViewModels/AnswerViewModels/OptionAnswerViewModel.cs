using JPS.API.ViewModels.ViewModels.OptionRowViewModels;
using JPS.API.ViewModels.ViewModels.OptionViewModels;

namespace JPS.API.ViewModels.ViewModels.AnswerViewModels
{
	/// <summary>
	/// Model for displaying option answer.
	/// </summary>
	public class OptionAnswerViewModel
	{
		public int OptionId { get; set; }
		public int? OptionRowId { get; set; }
		public OptionViewModel Option { get; set; }
		public OptionRowViewModel OptionRow { get; set; }
	}
}