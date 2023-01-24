using JPS.API.ViewModels.StringConstants;
using JPS.API.ViewModels.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace JPS.API.ViewModels.ViewModels.CreatePollWithAllQuestionsViewModels
{
	/// <summary>
	/// Model for creating poll with sections.
	/// </summary>
	public class CreatePollWithQuestionSectionsViewModel : IValidatableObject
	{
		[Range(1, int.MaxValue)]
		public int? CategoryId { get; set; }

		[Required]
		[MaxLength(100)]
		public string Title { get; set; }

		public string Description { get; set; }

		[Required]
		public bool IsAnonymous { get; set; }

		[DataType(DataType.DateTime)]
		[IsLaterThanCurrentDateTime]
		public DateTimeOffset? StartsAt { get; set; }

		[DataType(DataType.DateTime)]
		[IsLaterThan("StartsAt")]
		public DateTimeOffset? FinishesAt { get; set; }
		
		[Required]
		public IEnumerable<CreateQuestionSectionWithQuestionsViewModel> QuestionSections { get; set; }

		/// <summary>
		/// Validates question sections.
		/// </summary>
		/// <param name="validationContext">Context in which validation check is performed.</param>
		/// <returns>Results of a validation request.</returns>
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var validationResults = new List<ValidationResult>();

			if (!QuestionSections.Any())
			{
				validationResults.Add(new ValidationResult(ExceptionMessages.PollHasNoSectionMessage));
			}

			var haveSectionsOrderDuplicates = QuestionSections
				.GroupBy(section => section.Order)
				.Any(group => group.Count() > NumberConstants.MaxGroupDuplicateNumber);

			if (haveSectionsOrderDuplicates)
			{
				validationResults.Add(new ValidationResult(ExceptionMessages.SectionsHaveOrderDuplicatesMessage));
			}

			return validationResults;
		}
	}
}
