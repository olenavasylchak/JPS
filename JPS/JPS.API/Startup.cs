using Hangfire;
using JPS.API.IoC;
using JPS.API.IoC.Constants;
using JPS.API.IoC.Extensions;
using JPS.API.IoC.SettingsModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace JPS.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddAppSettingsConfiguration(Configuration);

			var appSettings = services.BuildServiceProvider().GetService<IOptions<AppSettings>>().Value;

			services.AddDatabaseContext(appSettings.ConnectionString);

			services.RegisterMapperProfiles();

			services.RegisterServices(Configuration);

			services.AddControllers();

			services.AddCorsConfiguration(appSettings.Origins);

			services.AddHttpContextAccessor();

			services.AddFiltersConfigurations();

			services.AddSwaggerAuthConfiguration(Configuration);

			services.AddSwaggerXmlConfiguration();

			services.AddAuthenticationConfiguration(Configuration);

			services.AddHangfireConfiguration(appSettings.ConnectionString);

			services.AddSingleton(Configuration);

			services.AddSendGridConfiguration(Configuration);
		}


		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			SwaggerAdOptions options = new SwaggerAdOptions();
			Configuration.Bind(StringConstants.SwaggerAdSection, options);

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "JPS API V1");
				c.RoutePrefix = string.Empty;
				c.OAuthClientId(options.ClientId);
				c.OAuthScopeSeparator(" ");
			});

			app.UseHangfireDashboard();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors(StringConstants.AzurePolicy);

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
		}
	}
}
