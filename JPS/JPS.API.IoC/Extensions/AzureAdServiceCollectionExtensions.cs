using JPS.API.IoC.Constants;
using JPS.API.IoC.SettingsModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace JPS.API.IoC.Extensions
{
	/// <summary>
	/// Extension class for configuring Azure AD service.
	/// </summary>
	public static class AzureAdServiceCollectionExtensions
	{
		public static AuthenticationBuilder AddAzureAdBearer(this AuthenticationBuilder builder)
				   => builder.AddAzureAdBearer(_ => { });

		public static AuthenticationBuilder AddAzureAdBearer(this AuthenticationBuilder builder, Action<AzureAdOptions> configureOptions)
		{
			builder.Services.Configure(configureOptions);
			builder.Services.AddSingleton<IConfigureOptions<JwtBearerOptions>, ConfigureAzureOptions>();
			builder.AddJwtBearer();
			return builder;
		}

		/// <summary>
		/// Extension method for authentication configurations.
		/// </summary>
		/// <param name="services">Collection of services for adding authentication configuration.</param>
		/// <param name="configuration">Used to take configuration options of the project.</param>
		public static void AddAuthenticationConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddAuthentication(sharedOptions =>
			{
				sharedOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddAzureAdBearer(options => configuration.Bind(StringConstants.AzureAdSection, options));
		}

		/// <summary>
		/// Contains methods for adding Azure configuration. 
		/// </summary>
		private class ConfigureAzureOptions : IConfigureNamedOptions<JwtBearerOptions>
		{
			private readonly AzureAdOptions _azureOptions;

			public ConfigureAzureOptions(IOptions<AzureAdOptions> azureOptions)
			{
				_azureOptions = azureOptions.Value;
			}

			public void Configure(string name, JwtBearerOptions options)
			{
				options.Audience = _azureOptions.ClientId;
				options.Authority = $"{_azureOptions.Instance}{_azureOptions.TenantId}";
				options.TokenValidationParameters.ValidateIssuer = false;
			}

			public void Configure(JwtBearerOptions options)
			{
				Configure(Options.DefaultName, options);
			}
		}
	}
}
