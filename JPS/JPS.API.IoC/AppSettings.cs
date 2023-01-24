namespace JPS.API.IoC
{
	/// <summary>
	/// Contains configuration properties from appsettings.json.
	/// </summary>
	public class AppSettings
	{
		public string ConnectionString { get; set; }
		public string[] Origins { get; set; }
	}
}