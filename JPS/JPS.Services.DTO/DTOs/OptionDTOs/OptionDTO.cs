namespace JPS.Services.DTO.DTOs.OptionDTOs
{
	/// <summary>
	/// Model that represents OptionEntity.
	/// </summary>
	public class OptionDTO
	{
		public int Id { get; set; }
		public int QuestionId { get; set; }
		public string Text { get; set; }
		public string ImageUrl { get; set; }
		public int Order { get; set; }
		public decimal? Value { get; set; }
	}
}
