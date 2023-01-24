namespace JPS.API.ViewModels.ViewModels.OptionRowViewModels
{
	/// <summary>
	/// Model for displaying row.
	/// </summary>
	public class OptionRowViewModel
	{
		public int Id { get; set; }
		public int QuestionId { get; set; }
		public string Text { get; set; }
		public string ImageUrl { get; set; }
		public int Order { get; set; }
	}
}
