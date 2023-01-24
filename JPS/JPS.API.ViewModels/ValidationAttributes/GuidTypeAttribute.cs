using JPS.API.ViewModels.StringConstants;
using System;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ValidationAttributes
{
	public class GuidTypeAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (!Guid.TryParse(value.ToString(), out Guid inputValue))
			{
				return new ValidationResult(ExceptionMessages.InvalidGuidTypeInputMessage);
			}
			return ValidationResult.Success;
		}
	}
}
