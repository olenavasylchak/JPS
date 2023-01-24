using System.Collections.Generic;

namespace JPS.API.ViewModels.ViewModels.AnswerViewModels.GroupedAnswersViewModel
{
	/// <summary>
	/// Model for displaying grouped answers.
	/// </summary>
	public class GroupedAnswerViewModel
	{
		public GroupedTextAnswerViewModel TextAnswers { get; set; }
		public GroupedParagraphAnswerViewModel ParagraphAnswers { get; set; }
		public GroupedFileAnswerViewModel FileAnswers { get; set; }
		public IEnumerable<GroupedOptionAnswerViewModel> OptionAnswers { get; set; }
		public IEnumerable<GroupedDateAnswerViewModel> DateAnswers { get; set; }
		public IEnumerable<GroupedTimeAnswerViewModel> TimeAnswers { get; set; }
		public IEnumerable<GroupedGridAnswerViewModel> GridAnswers { get; set; }
	}
}
