using JPS.API.ViewModels.ValidationAttributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.PollViewModels
{
	/// <summary>
	/// Model for updating poll finish date.
	/// </summary>
	public class UpdatePollFinishDateViewModel
	{
		[DataType(DataType.DateTime)]
		[IsLaterThanCurrentDateTime]
		public DateTimeOffset? FinishesAt { get; set; }
	}
}
