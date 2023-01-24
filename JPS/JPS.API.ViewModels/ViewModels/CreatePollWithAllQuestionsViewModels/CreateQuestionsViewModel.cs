using JPS.API.ViewModels.Enums;
using JPS.API.ViewModels.StringConstants;
using JPS.API.ViewModels.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace JPS.API.ViewModels.ViewModels.CreatePollWithAllQuestionsViewModels
{
	/// <summary>
	/// Model for creating question with options and rows.
	/// </summary>
	public class CreateQuestionsViewModel : IValidatableObject
	{
		[Required]
		public string Text { get; set; }

		[Required]
		public bool IsRequired { get; set; }
		public bool CanHaveOtherOption { get; set; }

		[MaxLength(250)]
		public string Comment { get; set; }

		[Required]
		[Range(1, int.MaxValue)]
		public int Order { get; set; }

		[Required]
		[QuestionType]
		[Range(1, int.MaxValue)]
		public int QuestionTypeId { get; set; }

		public string ImageUrl { get; set; }

		public string VideoUrl { get; set; }

		public IEnumerable<CreateOptionForQuestionViewModel> Options { get; set; }

		public IEnumerable<CreateOptionRowForQuestionViewModel> OptionRows { get; set; }

		/// <summary>
		/// Validates adding of options and option rows.
		/// </summary>
		/// <param name="validationContext">Context in which validation check is performed.</param>
		/// <returns>Results of a validation request.</returns>
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var validationResults = new List<ValidationResult>();

			switch (QuestionTypeId)
			{
				case (int)QuestionTypes.Text:
				case (int)QuestionTypes.Paragraph:
				case (int)QuestionTypes.Date:
				case (int)QuestionTypes.Time:
				case (int)QuestionTypes.FileUpload:

					if (Options != null)
					{
						validationResults.Add(new ValidationResult(ExceptionMessages.QuestionTypeWithNoOptionsMessage));
					}

					if (OptionRows != null)
					{
						validationResults.Add(new ValidationResult(ExceptionMessages.QuestionTypeWithNoRowsMessage));
					}

					break;

				case (int)QuestionTypes.CheckBoxes:
				case (int)QuestionTypes.LinearScale:
				case (int)QuestionTypes.Dropdown:
				case (int)QuestionTypes.MultipleChoice:
					if (Options == null)
					{
						validationResults.Add(new ValidationResult(ExceptionMessages.NotEnoughOptionsMessage));
					}
					else
					{
						if (QuestionTypeId == (int)QuestionTypes.LinearScale)
						{
							var hasValueDuplicates = Options
								.GroupBy(options => options.Value)
								.Any(group => group.Count() > NumberConstants.MaxGroupDuplicateNumber);

							if (hasValueDuplicates)
							{
								validationResults.Add(new ValidationResult(ExceptionMessages.OptionsHaveValueDuplicatesMessage));
							}

							var isAnyOptionWithoutValue = Options.Any(option => option.Value == null);
							if (isAnyOptionWithoutValue)
							{
								validationResults.Add(new ValidationResult(ExceptionMessages.OptionDoesntHaveValueMessage));
							}
						}
						else
						{
							if (Options.Any(option => option.Value != null))
							{
								validationResults.Add(new ValidationResult(ExceptionMessages.QuestionTypeWithNoValuesMessage));
							}
						}

						if (OptionRows?.Any() == true)
						{
							validationResults.Add(new ValidationResult(ExceptionMessages.QuestionTypeWithNoRowsMessage));
						}

						if (Options.Count() < NumberConstants.OptionsMinNumber)
						{
							validationResults.Add(new ValidationResult(ExceptionMessages.NotEnoughOptionsMessage));
						}

						var hasOrderDuplicates = Options
							.GroupBy(section => section.Order)
							.Any(group => group.Count() > NumberConstants.MaxGroupDuplicateNumber);

						if (hasOrderDuplicates)
						{
							validationResults.Add(new ValidationResult(ExceptionMessages.OptionsHaveOrderDuplicatesMessage));
						}
					}
					break;

				case (int)QuestionTypes.CheckboxGrid:
				case (int)QuestionTypes.MultipleChoiceGrid:
					if (Options == null || OptionRows == null)
					{
						validationResults.Add(new ValidationResult(ExceptionMessages.NotGivenRowsOrOptionsMessage));
					}
					else
					{
						var isAnyOptionWithValue = Options.Any(option => option.Value != null);
						if (isAnyOptionWithValue)
						{
							validationResults.Add(new ValidationResult(ExceptionMessages.OptionHaveValueMessage));
						}
						if (Options.Count() < NumberConstants.OptionsMinNumber)
						{
							validationResults.Add(new ValidationResult(ExceptionMessages.NotEnoughOptionsMessage));
						}

						if (OptionRows.Count() < NumberConstants.OptionsMinNumber)
						{
							validationResults.Add(new ValidationResult(ExceptionMessages.NotEnoughRowsMessage));
						}

						var haveGridOptionsOrderDuplicates = Options
							.GroupBy(option => option.Order)
							.Any(group => group.Count() > NumberConstants.MaxGroupDuplicateNumber);

						if (haveGridOptionsOrderDuplicates)
						{
							validationResults.Add(new ValidationResult(ExceptionMessages.OptionsHaveOrderDuplicatesMessage));
						}

						var haveRowsOrderDuplicates = OptionRows
							.GroupBy(row => row.Order)
							.Any(group => group.Count() > NumberConstants.MaxGroupDuplicateNumber);

						if (haveRowsOrderDuplicates)
						{
							validationResults.Add(new ValidationResult(ExceptionMessages.RowsHaveOrderDuplicatesMessage));
						}
					}
					break;
			}
			if (CanHaveOtherOption)
			{
				if (QuestionTypeId != (int)QuestionTypes.CheckBoxes &&
					QuestionTypeId != (int)QuestionTypes.MultipleChoice)
				{
					validationResults.Add(new ValidationResult(ExceptionMessages.QuestionCantAllowOtherOptionMessage));
				}
			}

			return validationResults;
		}
	}
}
