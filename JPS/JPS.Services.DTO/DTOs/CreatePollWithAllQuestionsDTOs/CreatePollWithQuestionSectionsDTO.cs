using System;
using System.Collections.Generic;

namespace JPS.Services.DTO.DTOs.CreatePollWithAllQuestionsDTOs
{
	/// <summary>
	/// Model for creating poll with sections.
	/// </summary>
	public class CreatePollWithQuestionSectionsDTO
	{
		public int? CategoryId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public bool IsAnonymous { get; set; }
		public DateTimeOffset? StartsAt { get; set; }
		public DateTimeOffset? FinishesAt { get; set; }
		public IEnumerable<CreateQuestionSectionWithQuestionsDTO> QuestionSections { get; set; }
	}
}
