using System;

namespace JPS.Services.DTO.DTOs.PollDTOs.AnalyticsDTOs
{
	/// <summary>
	/// Model that represents analytics poll dto without questions.
	/// </summary>
	public class PollAnalyticsWithoutQuestionsDTO
	{
		public int Id { get; set; }
		public int? CategoryId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public bool IsAnonymous { get; set; }
		public DateTimeOffset? StartsAt { get; set; }
		public DateTimeOffset? FinishesAt { get; set; }
		public DateTimeOffset CreatedAt { get; set; }
		public double Progress { get; set; }
	}
}
