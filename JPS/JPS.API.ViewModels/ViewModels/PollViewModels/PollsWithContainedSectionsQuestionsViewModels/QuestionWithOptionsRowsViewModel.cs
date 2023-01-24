using JPS.API.ViewModels.ViewModels.AnswerViewModels;
using System.Collections.Generic;

namespace JPS.API.ViewModels.ViewModels.PollViewModels.PollsWithContainedSectionsQuestionsViewModels
{
	/// <summary>
	/// Model for displaying question with rows and options.
	/// </summary>
	public class QuestionWithOptionsRowsViewModel
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public bool IsRequired { get; set; }
		public int QuestionTypeId { get; set; }
		public string Comment { get; set; }
		public int Order { get; set; }
		public string ImageUrl { get; set; }
		public bool CanHaveOtherOption { get; set; }
		public string VideoUrl { get; set; }
		public IEnumerable<QuestionOptionViewModel> Options { get; set; }
		public IEnumerable<QuestionRowViewModel> OptionRows { get; set; }
		public IEnumerable<AnswerViewModel> Answers { get; set; }
	}
}
