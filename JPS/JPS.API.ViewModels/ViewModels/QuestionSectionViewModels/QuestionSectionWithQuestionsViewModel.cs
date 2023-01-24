using JPS.API.ViewModels.ViewModels.QuestionViewModels;
using System.Collections.Generic;

namespace JPS.API.ViewModels.ViewModels.QuestionSectionViewModels
{
	/// <summary>
	/// Model for displaying section with questions information.
	/// </summary>
	public class QuestionSectionWithQuestionsViewModel
	{
		public int Id { get; set; }
		public int PollId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int Order { get; set; }
		public IEnumerable<QuestionViewModel> Questions { get; set; }
	}
}