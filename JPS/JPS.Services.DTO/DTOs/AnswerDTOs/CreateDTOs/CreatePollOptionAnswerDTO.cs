namespace JPS.Services.DTO.DTOs.AnswerDTOs.CreateDTOs
{
	/// <summary>
	/// Model for creating new option answer.
	/// </summary>
	public class CreatePollOptionAnswerDTO
	{
		public int OptionId { get; set; }
		public int? OptionRowId { get; set; }
	}
}
