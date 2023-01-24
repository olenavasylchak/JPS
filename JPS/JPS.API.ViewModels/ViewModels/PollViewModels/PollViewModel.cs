using JPS.API.ViewModels.Helpers;
using JPS.API.ViewModels.ViewModels.PollStyleViewModels;
using JPS.Common.Enums;
using System;

namespace JPS.API.ViewModels.ViewModels.PollViewModels
{
	/// <summary>
	/// Model for displaying poll.
	/// </summary>
	public class PollViewModel
	{
		public int Id { get; set; }
		public int? CategoryId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public bool IsAnonymous { get; set; }
		public DateTimeOffset CreatedAt { get; set; }
		public DateTimeOffset? StartsAt { get; set; }
		public DateTimeOffset? FinishesAt { get; set; }
		public PollStyleViewModel PollStyle { get; set; }
		public PollStatuses Status
		{
			get
			{
				return PollStatusCalculator.CalculatePollStatus(this);
			}
		}
	}
}
