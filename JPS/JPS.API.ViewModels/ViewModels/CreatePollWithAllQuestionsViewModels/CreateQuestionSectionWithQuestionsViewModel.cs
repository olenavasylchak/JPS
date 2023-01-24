using JPS.API.ViewModels.StringConstants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace JPS.API.ViewModels.ViewModels.CreatePollWithAllQuestionsViewModels
{
	/// <summary>
	/// Model for creating section with questions.
	/// </summary>
	public class CreateQuestionSectionWithQuestionsViewModel : IValidatableObject
	{
		[MaxLength(100)]
		public string Title { get; set; }

		public string Description { get; set; }

		[Required]
		[Range(1, int.MaxValue)]
		public int Order { get; set; }

		[Required]
		public IEnumerable<CreateQuestionsViewModel> Questions { get; set; }

		/// <summary>
		/// Validates questions.
		/// </summary>
		/// <param name="validationContext">Context in which validation check is performed.</param>
		/// <returns>Results of a validation request.</returns>
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var validationResults = new List<ValidationResult>();

			if (!Questions.Any())
			{
				validationResults.Add(new ValidationResult(ExceptionMessages.PollHasNoQuestionMessage));
			}

			var haveQuestionsOrderDuplicates = Questions
				.GroupBy(section => section.Order)
				.Any(group => group.Count() > NumberConstants.MaxGroupDuplicateNumber);

			if (haveQuestionsOrderDuplicates)
			{
				validationResults.Add(new ValidationResult(ExceptionMessages.QuestionsHaveOrderDuplicatesMessage));
			}

			return validationResults;
		}
	}
}
