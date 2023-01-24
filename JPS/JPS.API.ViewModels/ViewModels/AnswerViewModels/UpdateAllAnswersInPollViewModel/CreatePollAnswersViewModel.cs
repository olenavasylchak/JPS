using JPS.API.ViewModels.StringConstants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace JPS.API.ViewModels.ViewModels.AnswerViewModels.UpdateAllAnswersInPollViewModel
{
	/// <summary>
	/// Base model for creating new answers for poll in database.
	/// </summary>
	public class CreatePollAnswersViewModel : IValidatableObject
	{
		[Range(1, int.MaxValue)]
		[Required]
		public int PollId { get; set; }

		public IEnumerable<PollAnswersViewModel> Answers { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var results = new List<ValidationResult>();
			if (Answers.GroupBy(x => x.QuestionId).Any(g => g.Count() > 1))
			{
				results.Add(new ValidationResult(ExceptionMessages.OneQuestionAnsweredTwiceMessage));
			}

			return results;
		}
	}
}
