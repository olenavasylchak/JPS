using JPS.API.IoC.Constants;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JPS.API.IoC.Extensions
{
	/// <summary>
	/// Extension class for configuring appsettings.
	/// </summary>
	public static class AddAppSettingsConfigurationExtension
	{
		/// <summary>
		/// Extension method for configuring AppSettings.
		/// </summary>
		/// <param name="services">Collection of services for configuring AppSettings.</param>
		/// <param name="config">API configurations.</param>
		public static void AddAppSettingsConfiguration(this IServiceCollection services, IConfiguration config)
		{
			services.Configure<AppSettings>(options =>
			{
				config.GetSection(StringConstants.AppSettingsSection).Bind(options);
				config.GetSection(StringConstants.AppSettingsSection)
					.GetSection(StringConstants.CorsOriginsSubSection)
					.Bind(options);
			});
			services.AddSingleton<AppSettings>();
		}
	}
}
