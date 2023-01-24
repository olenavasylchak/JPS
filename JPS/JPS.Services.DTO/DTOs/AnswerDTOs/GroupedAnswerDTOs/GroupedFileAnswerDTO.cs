using System.Collections.Generic;

namespace JPS.Services.DTO.DTOs.AnswerDTOs.GroupedAnswerDTOs
{
	/// <summary>
	/// Model that represents grouped file answers.
	/// </summary>
	public class GroupedFileAnswerDTO
	{
		public IEnumerable<FileAnswerDTO> FileAnswers { get; set; }
	}
}
