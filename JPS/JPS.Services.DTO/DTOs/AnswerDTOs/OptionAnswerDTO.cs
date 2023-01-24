using System.Collections.Generic;
using JPS.Services.DTO.DTOs.OptionDTOs;
using JPS.Services.DTO.DTOs.OptionRowDTOs;

namespace JPS.Services.DTO.DTOs.AnswerDTOs
{
	/// <summary>
	/// Model that represents OptionAnswerEntity.
	/// Used in AnswerDTO.
	/// </summary>
	public class OptionAnswerDTO
	{
		public int Id { get; set; }
		public int AnswerId { get; set; }
		public int OptionId { get; set; }
		public int? OptionRowId { get; set; }
		public OptionDTO Option { get; set; }
		public OptionRowDTO OptionRow { get; set; }
	}
}
