namespace JPS.Services.DTO.DTOs.CreatePollWithAllQuestionsDTOs
{
	/// <summary>
	/// Model for creating option for question.
	/// </summary>
	public class CreateOptionForQuestionDTO
	{
		public string Text { get; set; }
		public string ImageUrl { get; set; }
		public int Order { get; set; }
		public decimal? Value { get; set; }
	}
}
