using System.Collections.Generic;

namespace JPS.Services.DTO.DTOs.PollDTOs.AnalyticsDTOs
{
	/// <summary>
	/// Poll model that represents two analytic polls with grouped questions.
	/// </summary>
	public class PollComparisonDTO
	{
		public PollAnalyticsWithoutQuestionsDTO FirstPoll { get; set; }
		public PollAnalyticsWithoutQuestionsDTO SecondPoll { get; set; }
		public IEnumerable<IEnumerable<QuestionAnalyticsDTO>> Questions { get; set; }
	}
}
