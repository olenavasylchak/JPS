using System;

namespace JPS.Services.DTO.DTOs.PollDTOs.UpdateDTOs
{
	/// <summary>
	/// Model for updating poll start date.
	/// </summary>
	public class UpdatePollStartDateDTO
	{
		public DateTimeOffset? StartsAt { get; set; }
	}
}
