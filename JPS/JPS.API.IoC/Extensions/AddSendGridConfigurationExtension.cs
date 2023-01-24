using JPS.API.IoC.Constants;
using JPS.API.IoC.SettingsModels;
using JPS.Services.ModelInterfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JPS.API.IoC.Extensions
{
	/// <summary>
	/// Extension class for configuring sendgrid.
	/// </summary>
	public static class AddSendGridConfigurationExtension
	{
		/// <summary>
		/// Extension method for configuring hangfire. 
		/// </summary>
		/// <param name="services">Collection of services for adding swagger configuration.</param>
		/// <param name="configuration">Used to take configuration options of the project.</param>
		public static void AddSendGridConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddTransient<ISendGridOptions, SendGridOptions>((serviceProvider) =>
			{
				var options = new SendGridOptions();
				configuration.Bind(StringConstants.EmailAuthOptions, options);
   				return options;
			});
		}
	}
}
