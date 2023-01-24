namespace JPS.API.ViewModels.ViewModels.PollStyleViewModels
{
	/// <summary>
	/// Model for displaying poll's style.
	/// </summary>
	public class PollStyleViewModel
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
