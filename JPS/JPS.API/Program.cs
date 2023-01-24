using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NLog.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace JPS.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
					 Host.CreateDefaultBuilder(args)
						 .ConfigureLogging((hostingContext, logging) =>
						 {
							 logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
							 logging.AddDebug();
							 logging.AddNLog();
							 logging.SetMinimumLevel(LogLevel.Information);
						 })
						 .ConfigureWebHostDefaults(webBuilder =>
						 {
							 webBuilder.UseStartup<Startup>();
						 });
	}
}
