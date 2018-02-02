using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinScrape.ScrapingTarget;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Serilog;

namespace FinScrape
{
	public static class Scraper
	{
	    static IWebDriver _driver;
	    static Actions _actions;
	    static WebDriverWait _wait;

	    public static void ScrapeTicker(string ticker)
	    {
            InitWebDriver();
            var yahooScrape = new YahooFinanceTarget(_driver, _wait, _actions);
            ScrapeFinancialData(ticker, yahooScrape);
            QuitWebDriver();

        }

		public static void ScrapeTickers(string[] tickers)
		{
            InitWebDriver();
            var yahooScrape = new YahooFinanceTarget(_driver, _wait, _actions);

            foreach (var ticker in tickers)
            {
                ScrapeFinancialData(ticker, yahooScrape);
            }
            QuitWebDriver();
        }

        static void InitWebDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("headless");
            options.AddArgument("--log-level=3");
            options.AddArgument("--silent");

            _driver = new ChromeDriver(options);

            _actions = new Actions(_driver);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
        }

        static void QuitWebDriver()
        {
            _driver.Quit();
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

            try
            {
                company.Price = scrapingTarget.GetPrice(ticker);
                Log.Debug("Successfully scraped price: {price}", company.Price);
            }
            catch (Exception e)
            {
                company.Price = "";
                Log.Error(e, "Unable to populate Price field from target: {@scrapingTarget}", scrapingTarget);
            }

            Log.Debug("Company generated: {@company}", company);
			return company;
		}
	}
}
