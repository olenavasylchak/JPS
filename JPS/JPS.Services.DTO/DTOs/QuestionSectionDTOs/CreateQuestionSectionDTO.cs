namespace JPS.Services.DTO.DTOs.QuestionSectionDTOs
{
	/// <summary>
	/// Model for creating new question section.
	/// </summary>
	public class CreateQuestionSectionDTO
	{
		public int PollId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int Order { get; set; }
	}
}