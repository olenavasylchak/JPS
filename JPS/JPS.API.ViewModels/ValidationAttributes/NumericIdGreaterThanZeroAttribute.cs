using JPS.API.ViewModels.StringConstants;
using System;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ValidationAttributes
{
	/// <summary>
	/// Specifies id target is greater than zero.
	/// </summary>
	[AttributeUsage(AttributeTargets.All)]
	public class NumericIdGreaterThanZeroAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (int.TryParse(value.ToString(), out int inputValue))
			{
				if (inputValue <= 0)
				{
					return new ValidationResult(ExceptionMessages.IdLowerThanOneMessage);
				}
			}
			else
			{
				return new ValidationResult(ExceptionMessages.BadIdTypeMessage);
			}
			return ValidationResult.Success;
		}
	}
}
