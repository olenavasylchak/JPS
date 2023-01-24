using JPS.Services.DTO.DTOs.PollStyleDTOs;
using System;

namespace JPS.Services.DTO.DTOs.PollDTOs
{
	/// <summary>
	/// Model for creating new poll.
	/// </summary>
	public class CreatePollDTO
	{
		public int? CategoryId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public bool IsAnonymous { get; set; }
		public DateTimeOffset? StartsAt { get; set; }
		public DateTimeOffset? FinishesAt { get; set; }
		public PollStyleDTO PollStyle { get; set; } 
	}
}
