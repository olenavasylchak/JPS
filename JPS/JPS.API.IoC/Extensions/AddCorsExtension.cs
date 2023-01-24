using JPS.API.IoC.Constants;
using Microsoft.Extensions.DependencyInjection;

namespace JPS.API.IoC.Extensions
{
	/// <summary>
	/// Extension class for adding CORS.
	/// </summary>
	public static class AddCorsExtension
	{
		/// <summary>
		/// Extension method for adding CORS configuration. 
		/// </summary>
		/// <param name="services">Collection of services for adding CORS configuration.</param>
		/// <param name="origins">Array of origins for adding to policy.</param>
		public static void AddCorsConfiguration(this IServiceCollection services, string[] origins)
		{
			services.AddCors((options =>
			{
				options.AddPolicy(StringConstants.AzurePolicy, builder => builder
				.WithOrigins(origins)
				.AllowAnyMethod()
				.AllowAnyHeader()
				.AllowCredentials()
				);
			}));
		}
	}
}
