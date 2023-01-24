namespace JPS.Domain.Entities.Entities
{
	public class PollStyleEntity
	{
		public int  PollId { get; set; }
		public string Font { get; set; }
		public string ThemeColor { get; set; }
		public decimal Opacity { get; set; }
		public string ImageUrl { get; set; }
		public float? ImageXCoordinate { get; set; }
		public float? ImageYCoordinate { get; set; }
		public PollEntity Poll { get; set; }
	}
}
