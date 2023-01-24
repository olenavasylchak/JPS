using System.Collections.Generic;

namespace JPS.Services.DTO.DTOs.AnswerDTOs.GetAnonymousDTOs
{
	/// <summary>
	/// Model that holds all types of anonymous answers.
	/// </summary>
	public class AnonymousAnswerDTO
	{
		public int Id { get; set; }
		public int QuestionId { get; set; }
		public DateAnswerDTO DateAnswer { get; set; }
		public TextAnswerDTO TextAnswer { get; set; }
		public TimeAnswerDTO TimeAnswer { get; set; }
		public ParagraphAnswerDTO ParagraphAnswer { get; set; }
		public FileAnswerDTO FileAnswer { get; set; }
		public IEnumerable<OptionAnswerDTO> OptionAnswers { get; set; }
	}
}