using JPS.API.IoC.Constants;
using JPS.API.IoC.Filters;
using JPS.API.IoC.SettingsModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace JPS.API.IoC.Extensions
{
	/// <summary>
	/// Extension class for configuring swagger.
	/// </summary>
	public static class AddSwaggerConfigurationExtension
	{
		/// <summary>
		/// Extension method for swagger authorization configurations. 
		/// </summary>
		/// <param name="services">Collection of services for adding swagger configuration.</param>
		/// <param name="configuration">Used to take configuration options of the project.</param>
		public static void AddSwaggerAuthConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			var options = new AzureAdOptions();
			configuration.Bind(StringConstants.AzureAdSection, options);

			services.AddSwaggerGen(c =>
			{
				c.AddSecurityDefinition(StringConstants.TokenName, new OpenApiSecurityScheme
				{
					Type = SecuritySchemeType.OAuth2,
					Flows = new OpenApiOAuthFlows
					{
						Implicit = new OpenApiOAuthFlow
						{
							TokenUrl = new Uri($"{options.Instance}/{options.TenantId}/oauth2/v2.0/token"),
							AuthorizationUrl = new Uri($"{options.Instance}/{options.TenantId}/oauth2/v2.0/authorize"),
							Scopes = { { options.Scope, options.ScopeDescription } }
						}
					}
				});

				c.AddSecurityDefinition(StringConstants.BearerString, new OpenApiSecurityScheme
				{
					Description = StringConstants.BearerAuthorizationDescription,
					Name = StringConstants.SecurityDefinitionName,
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey,
					Scheme = StringConstants.BearerString
				});

				c.OperationFilter<AuthorizeCheckOperationFilter>();
			});
		}

		/// <summary>
		/// Extension method for swagger xml configurations.
		/// </summary>
		/// <param name="services">Collection of services for adding swagger configuration.</param>
		public static void AddSwaggerXmlConfiguration(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc(StringConstants.ApiVersion, new OpenApiInfo { Title = StringConstants.ApplicationTitle, Version = StringConstants.ApiVersion });

				var xmlPath = Path.Combine(AppContext.BaseDirectory, StringConstants.XmlFileName);
				c.IncludeXmlComments(xmlPath);
			});
		}
	}
}
