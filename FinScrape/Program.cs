using System;
using Serilog;
using Serilog.Events;

namespace FinScrape
{
	class Program
	{
		static void Main(string[] args)
		{
			args = new[] { "wmt" }; // FOR DEBUGGING
			ConfigureLogger();

			Log.Debug("Arguments passed in: {args}", args);
			Scraper.Start(args);

			Log.Debug("Program has exited");
		}

		static void ConfigureLogger()
		{
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Minute)
				.WriteTo.Console(restrictedToMinimumLevel:LogEventLevel.Information)
				.CreateLogger();
		}
	}
}