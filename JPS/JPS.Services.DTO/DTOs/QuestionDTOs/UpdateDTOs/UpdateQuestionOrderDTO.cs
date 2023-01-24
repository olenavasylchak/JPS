namespace JPS.Services.DTO.DTOs.QuestionDTOs.UpdateDTOs
{
	/// <summary>
	/// Model for updating question order and section.
	/// </summary>
	public class UpdateQuestionOrderDTO
	{
		public int Id { get; set; }
		public int Order { get; set; }
		public int SectionId { get; set; }
	}
}
