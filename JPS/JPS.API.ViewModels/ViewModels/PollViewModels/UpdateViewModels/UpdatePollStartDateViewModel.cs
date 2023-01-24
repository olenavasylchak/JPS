using JPS.API.ViewModels.ValidationAttributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.PollViewModels.UpdateViewModels
{
	/// <summary>
	/// Model for updating poll start date.
	/// </summary>
	public class UpdatePollStartDateViewModel
	{
		[DataType(DataType.DateTime)]
		[IsLaterThanCurrentDateTime]
		public DateTimeOffset? StartsAt { get; set; }
	}
}
