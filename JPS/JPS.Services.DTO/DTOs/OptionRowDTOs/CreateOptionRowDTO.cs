namespace JPS.Services.DTO.DTOs.OptionRowDTOs
{
	/// <summary>
	/// DTO to transfer information about created row.
	/// </summary>
	public class CreateOptionRowDTO
	{
		public int QuestionId { get; set; }
		public string Text { get; set; }
		public string ImageUrl { get; set; }
		public int Order { get; set; }
	}
}
