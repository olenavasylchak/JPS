namespace JPS.API.ViewModels.ViewModels.QuestionSectionViewModels
{
	/// <summary>
	/// Model for displaying section.
	/// </summary>
	public class QuestionSectionViewModel
	{
		public int Id { get; set; }
		public int PollId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int Order { get; set; }
	}
}