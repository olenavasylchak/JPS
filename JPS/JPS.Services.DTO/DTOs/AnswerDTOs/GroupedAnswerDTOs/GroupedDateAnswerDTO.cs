namespace JPS.Services.DTO.DTOs.AnswerDTOs.GroupedAnswerDTOs
{
	/// <summary>
	/// Model that represents grouped date answers.
	/// </summary>
	public class GroupedDateAnswerDTO : DiscreteAnswerDTO
	{
		public DateAnswerDTO DateAnswer { get; set; }
	}
}
