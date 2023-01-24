using System;
using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.PollStyleViewModels
{
	/// <summary>
	/// Model for creating poll's style.
	/// </summary>
	public class CreatePollStyleViewModel
	{
		[Required]
		public string Font { get; set; }

		[Required]
		[RegularExpression(StringConstants.StringConstants.ColorRgbRegex)]
		public string ThemeColor { get; set; }

		[Required]
		[Range(0, 100)]
		public decimal Opacity { get; set; }

		public string ImageUrl { get; set; }

		[Range(0, float.MaxValue)]
		public float? ImageXCoordinate { get; set; }

		[Range(0, float.MaxValue)]
		public float? ImageYCoordinate { get; set; }
	}
}
