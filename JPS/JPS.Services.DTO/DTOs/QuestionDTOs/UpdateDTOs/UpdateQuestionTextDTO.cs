using System.ComponentModel.DataAnnotations;

namespace JPS.Services.DTO.DTOs.QuestionDTOs.UpdateDTOs
{
	/// <summary>
	/// Model for updating question text.
	/// </summary>
	public class UpdateQuestionTextDTO
	{
		[Required]
		public string Text { get; set; }
	}
}
