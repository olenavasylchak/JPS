using JPS.Services.DTO.DTOs.PollStyleDTOs;
using JPS.Services.DTO.DTOs.QuestionSectionDTOs;
using System;
using System.Collections.Generic;

namespace JPS.Services.DTO.DTOs.PollDTOs
{
	/// <summary>
	/// Model that represents poll.
	/// </summary>
	public class PollDTO
	{
		public int Id { get; set; }
		public int? CategoryId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public bool IsAnonymous { get; set; }
		public DateTimeOffset? StartsAt { get; set; }
		public DateTimeOffset? FinishesAt { get; set; }
		public DateTimeOffset CreatedAt { get; set; }
		public IEnumerable<QuestionSectionDTO> QuestionSections { get; set; }
		public PollStyleDTO PollStyle { get; set; }
	}
}
