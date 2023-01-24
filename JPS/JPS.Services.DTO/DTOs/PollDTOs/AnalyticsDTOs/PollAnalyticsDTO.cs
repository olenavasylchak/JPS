using System.Collections.Generic;

namespace JPS.Services.DTO.DTOs.PollDTOs.AnalyticsDTOs
{
	/// <summary>
	/// Model that represents poll model with analytics.
	/// </summary>
	public class PollAnalyticsDTO : PollAnalyticsWithoutQuestionsDTO
	{
		public IEnumerable<QuestionAnalyticsDTO> Questions { get; set; }
	}
}
