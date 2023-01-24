using System.Collections.Generic;

namespace JPS.Services.DTO.DTOs.AnswerDTOs.GetAnonymousDTOs
{
	/// <summary>
	/// Model that represents section.
	/// </summary>
	public class AnonymousQuestionSectionDTO
	{
		public int Id { get; set; }
		public int PollId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int? Order { get; set; }
		public IEnumerable<AnonymousQuestionDTO> Questions { get; set; }
	}
}
