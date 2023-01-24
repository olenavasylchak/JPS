using System.Collections.Generic;

namespace JPS.API.ViewModels.ViewModels.PollViewModels.AnalyticsViewModels
{
	/// <summary>
	/// Poll model that represents two analytic polls with grouped questions.
	/// </summary>
	public class PollsComparisonViewModel
	{
		public PollAnalyticsWithoutQuestionsViewModel FirstPoll { get; set; }
		public PollAnalyticsWithoutQuestionsViewModel SecondPoll { get; set; }
		public IEnumerable<IEnumerable<QuestionAnalyticsViewModel>> Questions { get; set; }
	}
}
