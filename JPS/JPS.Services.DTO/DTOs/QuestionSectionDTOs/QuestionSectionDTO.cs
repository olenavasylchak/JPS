using JPS.Services.DTO.DTOs.QuestionDTOs;
using System.Collections.Generic;

namespace JPS.Services.DTO.DTOs.QuestionSectionDTOs
{
	/// <summary>
	/// Model that represents QuestionSectionEntity.
	/// </summary>
	public class QuestionSectionDTO
	{
		public int Id { get; set; }
		public int PollId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int Order { get; set; }
		public IEnumerable<QuestionDTO> Questions { get; set; }
	}
}
