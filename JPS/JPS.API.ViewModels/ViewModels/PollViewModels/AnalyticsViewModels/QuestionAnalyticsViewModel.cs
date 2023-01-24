using JPS.API.ViewModels.ViewModels.AnswerViewModels.GroupedAnswersViewModel;
using JPS.API.ViewModels.ViewModels.OptionRowViewModels;
using JPS.API.ViewModels.ViewModels.OptionViewModels;
using System.Collections.Generic;

namespace JPS.API.ViewModels.ViewModels.PollViewModels.AnalyticsViewModels
{
	/// <summary>
	/// Model for displaying question with analytics.
	/// </summary>
	public class QuestionAnalyticsViewModel
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public int QuestionSectionId { get; set; }
		public bool CanHaveOtherOption { get; set; }
		public bool IsRequired { get; set; }
		public string Comment { get; set; }
		public int Order { get; set; }
		public int QuestionTypeId { get; set; }
		public string ImageUrl { get; set; }
		public string VideoUrl { get; set; }
		public GroupedAnswerViewModel GroupedAnswers { get; set; }
	}
}
