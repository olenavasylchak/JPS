using JPS.Services.DTO.DTOs.AnswerDTOs;
using JPS.Services.DTO.DTOs.OptionDTOs;
using JPS.Services.DTO.DTOs.OptionRowDTOs;
using System.Collections.Generic;

namespace JPS.Services.DTO.DTOs.QuestionDTOs
{
	/// <summary>
	/// Model that represents QuestionEntity.
	/// </summary>
	public class QuestionDTO
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public int QuestionSectionId { get; set; }
		public bool CanHaveOtherOption { get; set; }
		public bool IsRequired { get; set; }
		public string Comment { get; set; }
		public int Order { get; set; }
		public int QuestionTypeId { get; set; }
		public string ImageUrl { get; set; }
		public string VideoUrl { get; set; }
		public IEnumerable<QuestionOptionDTO> Options { get; set; }
		public IEnumerable<OptionRowDTO> OptionRows { get; set; }
		public IEnumerable<AnswerDTO> Answers { get; set; }
	}
}
