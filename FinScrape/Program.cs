using System;
using FinScrape.ScrapingTarget;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
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
			var target = new YahooFinanceTarget(InitSeleniumWebPageRenderer(), args[0]);
			var finScraper = new FinancialScraper(target);
			finScraper.ScrapeTickers(args);

			Log.Debug("Program has exited");
		}

		static SeleniumWebPageRenderer InitSeleniumWebPageRenderer()
		{
			var options = new ChromeOptions();
			options.AddArgument("headless");
			options.AddArgument("--log-level=3");
			options.AddArgument("--silent");

			var driver = new ChromeDriver(options);

			var actions = new Actions(driver);
			var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

			return new SeleniumWebPageRenderer(driver, wait, actions);
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