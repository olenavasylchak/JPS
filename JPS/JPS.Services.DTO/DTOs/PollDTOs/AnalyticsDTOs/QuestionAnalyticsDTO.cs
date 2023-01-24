using JPS.Services.DTO.DTOs.AnswerDTOs.GroupedAnswerDTOs;

namespace JPS.Services.DTO.DTOs.PollDTOs.AnalyticsDTOs
{
	/// <summary>
	/// Model that represents questions with analytics.
	/// </summary>
	public class QuestionAnalyticsDTO
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public int QuestionSectionId { get; set; }
		public bool CanHaveOtherOption { get; set; }
		public bool IsRequired { get; set; }
		public string Comment { get; set; }
		public int Order { get; set; }
		public int? PrototypeQuestionId { get; set; }
		public int QuestionTypeId { get; set; }
		public string ImageUrl { get; set; }
		public string VideoUrl { get; set; }
		public GroupedAnswerDTO GroupedAnswers { get; set; }
	}
}
