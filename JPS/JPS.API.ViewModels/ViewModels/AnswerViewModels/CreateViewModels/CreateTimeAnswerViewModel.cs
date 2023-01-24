using System;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.AnswerViewModels.CreateViewModels
{
	/// <summary>
	/// Model for creating new time answer.
	/// </summary>
	public class CreateTimeAnswerViewModel
	{
		[Required]
		public TimeSpan Time { get; set; }

	}
}
