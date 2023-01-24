using JPS.API.ViewModels.StringConstants;
using JPS.API.ViewModels.ViewModels.AnswerViewModels.CreateViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace JPS.API.ViewModels.ViewModels.AnswerViewModels.UpdateAllAnswersInPollViewModel
{
	/// <summary>
	/// Base model to contain answer.
	/// </summary>
	public class PollAnswersViewModel : IValidatableObject
	{
		[Range(1, int.MaxValue)]
		[Required]
		public int QuestionId { get; set; }
		public CreateTimeAnswerViewModel TimeAnswer { get; set; }
		public CreateDateAnswerViewModel DateAnswer { get; set; }
		public CreateParagraphAnswerViewModel ParagraphAnswer { get; set; }
		public CreateTextAnswerViewModel TextAnswer { get; set; }
		public CreateFileAnswerViewModel FileAnswer { get; set; }
		public IEnumerable<CreateOptionAnswerViewModel> LinearScaleAnswer { get; set; }
		public IEnumerable<CreateOptionAnswerViewModel> CheckBoxAnswer { get; set; }
		public IEnumerable<CreateOptionAnswerViewModel> ChoiceAnswer { get; set; }
		public IEnumerable<CreateOptionAnswerViewModel> DropdownAnswer { get; set; }
		public IEnumerable<CreateGridOptionAnswerViewModel> CheckBoxGridAnswers { get; set; }
		public IEnumerable<CreateGridOptionAnswerViewModel> ChoiceGridAnswer { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var results = new List<ValidationResult>();		
			if (LinearScaleAnswer != null)
			{
				if (LinearScaleAnswer.GroupBy(answer => answer.OptionId).Any(g => g.Count() > 1))
				{
					results.Add(new ValidationResult(ExceptionMessages.OneOptionSelectedTwiceMessage));
				}
			}
			if (DropdownAnswer != null)
			{
				if (DropdownAnswer.GroupBy(answer => answer.OptionId).Any(g => g.Count() > 1))
				{
					results.Add(new ValidationResult(ExceptionMessages.OneOptionSelectedTwiceMessage));
				}
			}
			if (ChoiceAnswer != null)
			{
				if (ChoiceAnswer.GroupBy(answer => answer.OptionId).Any(g => g.Count() > 1))
				{
					results.Add(new ValidationResult(ExceptionMessages.OneOptionSelectedTwiceMessage));
				}
			}
			if (CheckBoxAnswer != null)
			{
				if (CheckBoxAnswer.GroupBy(answer => answer.OptionId).Any(g => g.Count() > 1))
				{
					results.Add(new ValidationResult(ExceptionMessages.OneOptionSelectedTwiceMessage));
				}
			}
			if (CheckBoxGridAnswers != null)
			{
				if (CheckBoxGridAnswers.GroupBy(answer => new { answer.OptionId, answer.OptionRowId.Value }).Any(g => g.Count() > 1))
				{
					results.Add(new ValidationResult(ExceptionMessages.OneOptionSelectedTwiceMessage));
				}
			}
			if (ChoiceGridAnswer != null)
			{
				if (ChoiceGridAnswer.GroupBy(answer => new { answer.OptionId, answer.OptionRowId.Value }).Any(g => g.Count() > 1))
				{
					results.Add(new ValidationResult(ExceptionMessages.OneOptionSelectedTwiceMessage));
				}
			}
			return results;

		}
	}
}