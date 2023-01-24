using JPS.Services.DTO.DTOs.PollDTOs;
using System.Collections.Generic;

namespace JPS.Services.DTO.DTOs.AnswerDTOs.GetAnonymousDTOs
{
	/// <summary>
	/// Model that represents anonymous poll.
	/// </summary>
	public class AnonymousPollDTO : PollDTO
	{
		public IEnumerable<AnonymousQuestionSectionDTO> AnonymousQuestionSections { get; set; }
	}
}
