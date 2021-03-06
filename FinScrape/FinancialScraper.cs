﻿using System;
using FinScrape.ScrapingTarget;
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
				company.Description = scrapingTarget.Description;
				Log.Debug("Successfully scraped description: {description}", company.Description);
			}
			catch (Exception e)
			{
				company.Description = "";
				Log.Error(e, "Unable to populate Description field from target: {@scrapingTarget}", scrapingTarget);
			}

            try
            {
	            company.Price = scrapingTarget.Price;
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
