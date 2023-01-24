using JPS.API.IoC.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace JPS.API.IoC.Extensions
{
	/// <summary>
	/// Extension class for adding filters configurations.
	/// </summary>
	public static class AddFiltersConfigurationsExtension
	{
		/// <summary>
		/// Extension method for adding filters configuration. 
		/// </summary>
		/// <param name="services">Collection of services for configuring filters.</param>
		public static void AddFiltersConfigurations(this IServiceCollection services)
		{
			services.AddMvc().AddMvcOptions(options =>
			{
				var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
				options.Filters.Add(new AuthorizeFilter(policy));
				options.Filters.AddService(typeof(ValidateModelAttribute));
				options.Filters.AddService(typeof(ExceptionFilter));
			});
		}
	}
}
