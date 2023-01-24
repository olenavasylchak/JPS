namespace JPS.API.ViewModels.ViewModels.PollViewModels.PollsWithContainedSectionsQuestionsViewModels
{
	/// <summary>
	/// Model for displaying all rows in question.
	/// </summary>
	public class QuestionRowViewModel
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public string ImageUrl { get; set; }
		public int Order { get; set; }
	}
}
