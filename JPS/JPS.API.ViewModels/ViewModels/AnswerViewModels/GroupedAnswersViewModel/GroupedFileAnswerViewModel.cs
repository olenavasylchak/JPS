using System.Collections.Generic;

namespace JPS.API.ViewModels.ViewModels.AnswerViewModels.GroupedAnswersViewModel
{
	/// <summary>
	/// Model for displaying grouped file answers.
	/// </summary>
	public class GroupedFileAnswerViewModel
	{
		public IEnumerable<FileAnswerViewModel> FileAnswers { get; set; }
	}
}
