namespace JPS.Services.DTO.DTOs.PollStyleDTOs
{
	/// <summary>
	/// Data transfer object that represents poll's style.
	/// </summary>
	public class PollStyleDTO
	{
		public int PollId { get; set; }
		public string Font { get; set; }
		public string ThemeColor { get; set; }
		public decimal Opacity { get; set; }
		public string ImageUrl { get; set; }
		public float? ImageXCoordinate { get; set; }
		public float? ImageYCoordinate { get; set; }
	}
}
