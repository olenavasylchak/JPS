namespace JPS.Services.DTO.DTOs.OptionDTOs
{
	/// <summary>
	/// Model for creating new option.
	/// </summary>
	public class CreateOptionDTO
	{
		public int QuestionId { get; set; }
		public string Text { get; set; }
		public string ImageUrl { get; set; }
		public int Order { get; set; }
		public decimal? Value { get; set; }
	}
}
