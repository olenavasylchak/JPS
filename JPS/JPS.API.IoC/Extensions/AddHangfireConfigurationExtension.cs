using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace JPS.API.IoC.Extensions
{
	/// <summary>
	/// Extension class for configuring hangfire.
	/// </summary>
	public static class AddHangfireConfigurationExtension
	{
		/// <summary>
		/// Extension method for configuring hangfire. 
		/// </summary>
		/// <param name="services">Collection of services for adding swagger configuration.</param>
		/// <param name="connectionString">Database connection string.</param>
		public static void AddHangfireConfiguration(this IServiceCollection services, string connectionString)
		{
			services.AddHangfire(config => config
				.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
				.UseSimpleAssemblyNameTypeSerializer()
				.UseRecommendedSerializerSettings()
				.UseSqlServerStorage(connectionString, new SqlServerStorageOptions
				{
					CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
					SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
					QueuePollInterval = TimeSpan.Zero,
					UseRecommendedIsolationLevel = true,
					UsePageLocksOnDequeue = true,
					DisableGlobalLocks = true
				}));

			services.AddHangfireServer();
		}
	}
}
