using System.Collections.Generic;

namespace JPS.API.ViewModels.ViewModels.PollViewModels.AnalyticsViewModels
{
	/// <summary>
	/// Model for displaying poll with analytics.
	/// </summary>
	public class PollAnalyticsViewModel : PollAnalyticsWithoutQuestionsViewModel
	{
		public IEnumerable<QuestionAnalyticsViewModel> Questions { get; set; }
	}
}
