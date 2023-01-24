using JPS.Services.ModelInterfaces;

namespace JPS.API.IoC.SettingsModels
{
	/// <summary>
	/// SendGrid options model, holds the properties for sendGrid options.
	/// </summary>
	public class SendGridOptions : ISendGridOptions
	{
		public string SendGridUser { get; set; }
		public string SendGridKey { get; set; }
		public string EmailSender { get; set; }
	}
}
