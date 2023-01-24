using System.Collections.Generic;
using JPS.Services.DTO.DTOs.OptionRowDTOs;

namespace JPS.Services.DTO.DTOs.AnswerDTOs.GroupedAnswerDTOs
{
	public class GroupedGridAnswerDTO
	{
		public OptionRowDTO OptionRow { get; set; }
		public IEnumerable<GroupedOptionAnswerDTO> OptionAnswers { get; set; }
	}
}
