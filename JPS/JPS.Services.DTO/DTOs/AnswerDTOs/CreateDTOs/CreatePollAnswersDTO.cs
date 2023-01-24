using System.Collections.Generic;

namespace JPS.Services.DTO.DTOs.AnswerDTOs.CreateDTOs
{
	/// <summary>
	/// Model for creating new answers in poll.
	/// </summary>
	public class CreatePollAnswersDTO
	{
		public int PollId { get; set; }
		public IEnumerable<PollAnswersDTO> Answers { get; set; }
	}
}
