namespace JPS.API.ViewModels.ViewModels.OptionViewModels
{
	/// <summary>
	/// Model for displaying option.
	/// </summary>
	public class OptionViewModel
	{
		public int Id { get; set; }
		public int QuestionId { get; set; }
		public string Text { get; set; }
		public string ImageUrl { get; set; }
		public int Order { get; set; }
		public decimal? Value { get; set; }
	}
}
