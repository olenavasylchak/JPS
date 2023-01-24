using JPS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace JPS.API.IoC.Extensions
{
    /// <summary>
    /// Extension class for registering database context.
    /// </summary>
    public static class AddDatabaseContextExtension
    {
        /// <summary>
        /// Extension method for registering database context.
        /// </summary>
        /// <param name="services">Collection of services for registering database context.</param>
        /// <param name="connectionString">Database connection string.</param>
        public static void AddDatabaseContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<JPSContext>(options => options
                .UseSqlServer(connectionString,
                    ob => ob.MigrationsAssembly(ContextConstants.JpsMigrationAssembly)));
        }
    }
}
