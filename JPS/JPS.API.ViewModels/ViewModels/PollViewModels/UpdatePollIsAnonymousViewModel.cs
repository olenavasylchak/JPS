using System.ComponentModel.DataAnnotations;

namespace JPS.API.ViewModels.ViewModels.PollViewModels
{
	/// <summary>
	/// Model for updating poll isAnonymous status. 
	/// </summary>
	public class UpdatePollIsAnonymousViewModel
	{
		[Required]
		public bool IsAnonymous { get; set; }
	}
}
