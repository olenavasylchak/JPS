using JPS.API.ViewModels.StringConstants;
using System;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ValidationAttributes
{
	/// <summary>
	/// Specifies that DateTime property is greater than the given DateTime
	/// </summary>
	public class IsLaterThanAttribute : ValidationAttribute
	{
		private readonly string _beginDate;

		public IsLaterThanAttribute(string beginDate)
		{
			_beginDate = beginDate;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value == null)
			{
				return ValidationResult.Success;
			}

			var endDateValue = (DateTimeOffset)value;

			var property = validationContext.ObjectType.GetProperty(_beginDate);

			if (property == null)
			{
				throw new ArgumentException(ExceptionMessages.NoPropertyFoundMessage);
			}

			var beginDateValue = (DateTimeOffset?)property.GetValue(validationContext.ObjectInstance);

			if (beginDateValue == null)
			{
				return ValidationResult.Success;
			}

			if (endDateValue < beginDateValue)
			{
				return new ValidationResult(ExceptionMessages.EndDateIsEarlierThanStartDateMessage);
			}

			return ValidationResult.Success;
		}
	}
}