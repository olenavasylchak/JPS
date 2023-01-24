using System.Collections.Generic;

namespace JPS.Services.DTO.DTOs.CreatePollWithAllQuestionsDTOs
{
	/// <summary>
	/// Model for creating section with questions.
	/// </summary>
	public class CreateQuestionSectionWithQuestionsDTO
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public int Order { get; set; }
		public IEnumerable<CreateQuestionsDTO> Questions { get; set; }
	}
}
