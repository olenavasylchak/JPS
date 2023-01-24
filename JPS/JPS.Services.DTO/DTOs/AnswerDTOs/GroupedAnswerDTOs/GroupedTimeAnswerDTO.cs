namespace JPS.Services.DTO.DTOs.AnswerDTOs.GroupedAnswerDTOs
{
	/// <summary>
	/// Model that represents grouped time answers.
	/// </summary>
	public class GroupedTimeAnswerDTO : DiscreteAnswerDTO
	{
		public TimeAnswerDTO TimeAnswer { get; set; }
	}
}
