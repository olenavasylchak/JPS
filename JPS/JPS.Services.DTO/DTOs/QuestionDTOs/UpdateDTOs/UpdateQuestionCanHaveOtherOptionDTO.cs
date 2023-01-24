using System;
using System.Collections.Generic;
using System.Text;

namespace JPS.Services.DTO.DTOs.QuestionDTOs.UpdateDTOs
{
	/// <summary>
	/// Model for updating question flag that indicates ability to have other option.
	/// </summary>
	public class UpdateQuestionCanHaveOtherOptionDTO
	{
		public bool CanHaveOtherOption { get; set; }
	}
}
