using System.Collections.Generic;

namespace JPS.Services.DTO.DTOs.AnswerDTOs.GroupedAnswerDTOs
{
	/// <summary>
	/// Model that represents grouped answers.
	/// </summary>
	public class GroupedAnswerDTO
	{
		public GroupedTextAnswerDTO TextAnswers { get; set; }
		public GroupedParagraphAnswerDTO ParagraphAnswers { get; set; }
		public GroupedFileAnswerDTO FileAnswers { get; set; }
		public IEnumerable<GroupedOptionAnswerDTO> OptionAnswers { get; set; }
		public IEnumerable<GroupedDateAnswerDTO> DateAnswers { get; set; }
		public IEnumerable<GroupedTimeAnswerDTO> TimeAnswers { get; set; }
		public IEnumerable<GroupedGridAnswerDTO> GridAnswers { get; set; }
	}
}
