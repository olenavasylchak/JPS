using System.Collections.Generic;
using JPS.API.ViewModels.ViewModels.OptionRowViewModels;

namespace JPS.API.ViewModels.ViewModels.AnswerViewModels.GroupedAnswersViewModel
{
	public class GroupedGridAnswerViewModel
	{
		public OptionRowViewModel OptionRow { get; set; }
		public IEnumerable<GroupedOptionAnswerViewModel> OptionAnswers { get; set; }
	}
}
