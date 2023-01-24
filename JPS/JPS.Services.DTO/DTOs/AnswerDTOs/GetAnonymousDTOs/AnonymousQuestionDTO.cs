using JPS.Services.DTO.DTOs.OptionDTOs;
using System.Collections.Generic;
using JPS.Services.DTO.DTOs.OptionRowDTOs;

namespace JPS.Services.DTO.DTOs.AnswerDTOs.GetAnonymousDTOs
{
	/// <summary>
	/// Model that represents question.
	/// </summary>
	public class AnonymousQuestionDTO
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public int QuestionSectionId { get; set; }
		public bool IsRequired { get; set; }
		public string Comment { get; set; }
		public int? Order { get; set; }
		public bool CanHaveOtherOption { get; set; }
		public int QuestionTypeId { get; set; }
		public string ImageUrl { get; set; }
		public string VideoUrl { get; set; }
		public IEnumerable<QuestionOptionDTO> Options { get; set; }
		public IEnumerable<OptionRowDTO> OptionRows { get; set; }
		public IEnumerable<AnonymousAnswerDTO> Answers { get; set; }
	}
}
