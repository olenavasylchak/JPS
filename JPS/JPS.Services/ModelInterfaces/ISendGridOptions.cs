namespace JPS.Services.ModelInterfaces
{
	/// <summary>
	/// SendGrid options interface, holds the properties for options.
	/// </summary>
	public interface ISendGridOptions
	{
		public string SendGridUser { get; set; }
		public string SendGridKey { get; set; }
		public string EmailSender { get; set; }
	}

}
