using System;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.QuestionSectionViewModels.UpdateViewModels
{
	/// <summary>
	/// Model for updating section order.
	/// </summary>
	public class UpdateQuestionSectionOrderViewModel
	{
		[Required]
		[Range(1, int.MaxValue)]
		public int Id { get; set; }

		[Required]
		[Range(1, int.MaxValue)]
		public int Order { get; set; }
	}
}
