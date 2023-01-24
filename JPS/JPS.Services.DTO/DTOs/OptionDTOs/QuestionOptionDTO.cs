namespace JPS.Services.DTO.DTOs.OptionDTOs
{
	/// <summary>
	/// Data container for moving question options data between layers.
	/// </summary>
	public class QuestionOptionDTO
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public string ImageUrl { get; set; }
		public int Order { get; set; }
		public decimal? Value { get; set; }
	}
}
