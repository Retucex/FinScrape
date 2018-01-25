using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinScrape.ScrapingTarget;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Serilog;

namespace FinScrape
{
	static class Scraper
	{
		public static void Start(string[] tickers)
		{
			var options = new ChromeOptions();
			options.AddArgument("headless");
			options.AddArgument("--log-level=3");
			options.AddArgument("--silent");

			using (var driver = new ChromeDriver(options))
			{
				var actions = new Actions(driver);
				var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

				var yahooScrape = new YahooFinanceTarget(driver, wait, actions);

				foreach (var ticker in tickers)
				{
					ScrapeFinancialData(ticker, yahooScrape);
				}
			}
		}

		static Company ScrapeFinancialData(string ticker, IScrapingTarget scrapingTarget)
		{
			var company = new Company();

			try
			{
				company.Description = scrapingTarget.GetDescription(ticker);
				Log.Debug("Successfully scraped description: {description}", company.Description);
			}
			catch (Exception e)
			{
				company.Description = "";
				Log.Error(e, "Unable to populate Description field from target: {@scrapingTarget}", scrapingTarget);
			}

			Log.Debug("Company generated: {@company}", company);
			return company;
		}
	}
}
