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
	public class FinancialScraper : IFinancialScraper
	{
		readonly IScrapingTarget target;

		public FinancialScraper(IScrapingTarget target)
		{
			this.target = target;
		}

		public void ScrapeTickers(string[] tickers)
		{
            foreach (var ticker in tickers)
            {
                ScrapeFinancialData(ticker, target);
            }
        }

        Company ScrapeFinancialData(string ticker, IScrapingTarget scrapingTarget)
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
