using JPS.API.ViewModels.ValidationAttributes;
using JPS.API.ViewModels.ViewModels.PollStyleViewModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.PollViewModels
{
	/// <summary>
	/// Model for creating new poll.
	/// </summary>
	public class CreatePollViewModel
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
		public CreatePollStyleViewModel PollStyle { get; set; }
	}
}
