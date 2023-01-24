using System.Collections.Generic;
namespace JPS.Services.DTO.DTOs.CreatePollWithAllQuestionsDTOs
{
	/// <summary>
	/// Model for creating question with options and rows.
	/// </summary>
	public class CreateQuestionsDTO
	{
		public string Text { get; set; }
		public bool IsRequired { get; set; }
		public bool CanHaveOtherOption { get; set; }
		public string Comment { get; set; }
		public int Order { get; set; }
		public int QuestionTypeId { get; set; }
		public string ImageUrl { get; set; }
		public string VideoUrl { get; set; }
		public IEnumerable<CreateOptionForQuestionDTO> Options { get; set; }
		public IEnumerable<CreateOptionRowForQuestionDTO> OptionRows { get; set; }
	}
}
