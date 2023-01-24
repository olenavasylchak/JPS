using System.Collections.Generic;

namespace JPS.API.ViewModels.ViewModels.PollViewModels.PollsWithContainedSectionsQuestionsViewModels
{
	/// <summary>
	/// Model for displaying section with questions.
	/// </summary>
	public class SectionWithQuestionsViewModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int Order { get; set; }
		public IEnumerable<QuestionWithOptionsRowsViewModel> Questions { get; set; }
	}
}
