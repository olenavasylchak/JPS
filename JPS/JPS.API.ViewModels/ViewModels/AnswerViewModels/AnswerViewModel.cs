using System.Collections.Generic;

namespace JPS.API.ViewModels.ViewModels.AnswerViewModels
{
	/// <summary>
	/// Base model for displaying answer.
	/// </summary>
	public class AnswerViewModel
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public int QuestionId { get; set; }
		public DateAnswerViewModel DateAnswer { get; set; }
		public TextAnswerViewModel TextAnswer { get; set; }
		public TimeAnswerViewModel TimeAnswer { get; set; }
		public ParagraphAnswerViewModel ParagraphAnswer { get; set; }
		public FileAnswerViewModel FileAnswer { get; set; }
		public IEnumerable<OptionAnswerViewModel> OptionAnswers { get; set; }
	}
}
