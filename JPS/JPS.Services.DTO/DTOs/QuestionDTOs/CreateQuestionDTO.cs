namespace JPS.Services.DTO.DTOs.QuestionDTOs
{
	/// <summary>
	/// Model for creating new question.
	/// </summary>
	public class CreateQuestionDTO
	{
		public string Text { get; set; }
		public int QuestionSectionId { get; set; }
		public bool IsRequired { get; set; }
		public bool CanHaveOtherOption { get; set; }
		public string Comment { get; set; }
		public int Order { get; set; }
		public int QuestionTypeId { get; set; }
		public string ImageUrl { get; set; }
		public string VideoUrl { get; set; }
	}
}
