using System;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.AnswerViewModels.CreateViewModels
{
	/// <summary>
	/// Model for creating new date answer.
	/// </summary>
	public class CreateDateAnswerViewModel
	{
		[Required]
		public DateTimeOffset Date { get; set; }
	}
}
