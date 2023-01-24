using System.Collections.Generic;

namespace JPS.Services.DTO.DTOs.AnswerDTOs.GroupedAnswerDTOs
{
	/// <summary>
	/// Model that represents grouped paragraph answers.
	/// </summary>
	public class GroupedParagraphAnswerDTO
	{
		public IEnumerable<ParagraphAnswerDTO> ParagraphAnswers { get; set; }
	}
}
