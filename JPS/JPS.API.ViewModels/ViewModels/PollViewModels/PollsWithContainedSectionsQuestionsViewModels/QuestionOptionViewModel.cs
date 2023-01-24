namespace JPS.API.ViewModels.ViewModels.PollViewModels.PollsWithContainedSectionsQuestionsViewModels
{
	/// <summary>
	/// Model for displaying question option.
	/// </summary>
	public class QuestionOptionViewModel
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public string ImageUrl { get; set; }
		public int Order { get; set; }
		public decimal? Value { get; set; }
	}
}
