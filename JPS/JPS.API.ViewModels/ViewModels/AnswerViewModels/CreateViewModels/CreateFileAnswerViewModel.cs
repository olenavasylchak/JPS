using System;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.AnswerViewModels.CreateViewModels
{
	public class CreateFileAnswerViewModel
	{
		[Required]
		public string FileUrl { get; set; }
	}
}
