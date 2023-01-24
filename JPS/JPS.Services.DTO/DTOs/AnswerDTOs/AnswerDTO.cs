using System.Collections.Generic;

namespace JPS.Services.DTO.DTOs.AnswerDTOs
{
	/// <summary>
	/// Model that hold all types of answers and than can be changed into necessary viewModel.
	/// </summary>
	public class AnswerDTO
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public int QuestionId { get; set; }
		public DateAnswerDTO DateAnswer { get; set; }
		public TextAnswerDTO TextAnswer { get; set; }
		public TimeAnswerDTO TimeAnswer { get; set; }
		public ParagraphAnswerDTO ParagraphAnswer { get; set; }
		public FileAnswerDTO FileAnswer { get; set; }
		public IEnumerable<OptionAnswerDTO> OptionAnswers { get; set; }
	}
}