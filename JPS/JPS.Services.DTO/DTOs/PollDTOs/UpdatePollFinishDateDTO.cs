using System;

namespace JPS.Services.DTO.DTOs.PollDTOs
{
	/// <summary>
	/// Model for updating poll finish date.
	/// </summary>
	public class UpdatePollFinishDateDTO
	{
		public DateTimeOffset? FinishesAt { get; set; }
	}
}
