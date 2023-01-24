using JPS.API.ViewModels.ViewModels.OptionViewModels;

namespace JPS.API.ViewModels.ViewModels.AnswerViewModels.GroupedAnswersViewModel
{
	/// <summary>
	/// Model for displaying grouped option answers.
	/// </summary>
	public class GroupedOptionAnswerViewModel:DiscreteAnswerViewModel
	{
		public OptionViewModel OptionAnswer { get; set; }
	}
}
