using System.Collections.Generic;

namespace JPS.Services.DTO.DTOs.AnswerDTOs.GroupedAnswerDTOs
{
	/// <summary>
	/// Model that represents grouped text answers.
	/// </summary>
	public class GroupedTextAnswerDTO
	{
		public IEnumerable<TextAnswerDTO> TextAnswers { get; set; }
	}
}
