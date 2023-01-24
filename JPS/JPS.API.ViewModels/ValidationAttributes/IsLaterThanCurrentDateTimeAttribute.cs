using JPS.API.ViewModels.StringConstants;
using System;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ValidationAttributes
{
	/// <summary>
	/// Specifies that DateTime property is greater than current DateTime
	/// </summary>
	public class IsLaterThanCurrentDateTimeAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value == null)
			{
				return ValidationResult.Success;
			}

			DateTimeOffset inputValue = (DateTimeOffset)value;

			if (inputValue < DateTimeOffset.Now)
			{
				return new ValidationResult(ExceptionMessages.DateIsEarlierThanCurrentDateMessage);
			}

			return ValidationResult.Success;
		}
	}
}
