using JPS.Services.DTO.DTOs.OptionDTOs;

namespace JPS.Services.DTO.DTOs.AnswerDTOs.GroupedAnswerDTOs
{
	/// <summary>
	/// Model that represents grouped option answers.
	/// </summary>
	public class GroupedOptionAnswerDTO : DiscreteAnswerDTO
	{
		public OptionDTO OptionAnswer { get; set; }
	}
}
