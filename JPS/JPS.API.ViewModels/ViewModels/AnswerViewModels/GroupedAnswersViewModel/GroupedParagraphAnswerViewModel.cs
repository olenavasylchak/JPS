using System.Collections.Generic;

namespace JPS.API.ViewModels.ViewModels.AnswerViewModels.GroupedAnswersViewModel
{
	/// <summary>
	/// Model for displaying grouped paragraph answers.
	/// </summary>
	public class GroupedParagraphAnswerViewModel
	{
		public IEnumerable<ParagraphAnswerViewModel> ParagraphAnswers { get; set; }
	}
}
