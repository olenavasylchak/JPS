namespace JPS.Services.DTO.DTOs.OptionRowDTOs
{
	/// <summary>
	/// Data container for moving question rows data between layers.
	/// </summary>
	public class OptionRowDTO
	{
		public int Id { get; set; }
		public int QuestionId { get; set; }
		public string Text { get; set; }
		public string ImageUrl { get; set; }
		public int Order { get; set; }
	}
}
