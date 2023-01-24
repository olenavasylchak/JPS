using AutoMapper;
using JPS.API.IoC.MapperProfile;
using Microsoft.Extensions.DependencyInjection;

namespace JPS.API.IoC.Extensions
{
	/// <summary>
	/// Extension class for registering mapper profiles.
	/// </summary>
	public static class RegisterMapperProfilesExtension
	{
		/// <summary>
		/// Extension method for registering mapper profiles.
		/// </summary>
		/// <param name="services">Collection of services
		/// for registering mapper profiles.</param>
		public static void RegisterMapperProfiles(this IServiceCollection services)
		{
			var configuration = new MapperConfiguration(c =>
			{
				c.AddProfile<DomainMapperProfile>();
				c.AddProfile<ServicesMapperProfile>();
				c.AddProfile<APIMapperProfile>();
			});
			services.AddTransient(s => configuration.CreateMapper());
		}
	}
}
