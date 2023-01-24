using System.Collections.Generic;

namespace JPS.API.ViewModels.ViewModels.AnswerViewModels.GroupedAnswersViewModel
{
	/// <summary>
	/// Model for displaying grouped text answers.
	/// </summary>
	public class GroupedTextAnswerViewModel
	{
		public IEnumerable<TextAnswerViewModel> TextAnswers { get; set; }
	}
}
