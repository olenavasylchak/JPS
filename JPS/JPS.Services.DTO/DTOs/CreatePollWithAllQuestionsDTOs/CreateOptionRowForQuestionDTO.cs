namespace JPS.Services.DTO.DTOs.CreatePollWithAllQuestionsDTOs
{
	/// <summary>
	/// Model for creating option row for question.
	/// </summary>
	public class CreateOptionRowForQuestionDTO
	{
		public string Text { get; set; }
		public string ImageUrl { get; set; }
		public int Order { get; set; }
	}
}
