using JPS.API.ViewModels.Enums;
using JPS.API.ViewModels.StringConstants;
using System;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ValidationAttributes
{
	/// <summary>
	/// Specifies that question type exists.
	/// </summary>
	public class QuestionTypeAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (int.TryParse(value.ToString(), out int inputValue))
			{
				var doesQuestionTypeExist = Enum.IsDefined(typeof(QuestionTypes), inputValue);

				if (!doesQuestionTypeExist)
				{
					return new ValidationResult(ExceptionMessages.InvalidQuestionTypeMessage);
				}
			}
			return ValidationResult.Success;
		}
	}
}

