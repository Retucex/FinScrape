using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace FinScrape.ScrapingTarget
{
	class YahooFinanceTarget : IScrapingTarget
	{
		struct SummaryPage
		{
			public struct ID
			{
				public const string Description = "Col2-9-QuoteModule-Proxy";
			}

			public struct XPath
			{
				public const string Name = "/html/body/div[1]/div/div/div[1]/div/div[2]/div/div/div[3]/div/div[2]/div[1]/div[1]/h1";

				public const string Price =
					"/html/body/div[1]/div/div/div[1]/div/div[2]/div/div/div[3]/div/div[3]/div[1]/div/span[1]";

				public const string PrevClose =
					"/html/body/div[1]/div/div/div[1]/div/div[3]/div[1]/div/div[1]/div/div[2]/div[1]/table/tbody/tr[1]/td[2]/span";

				public const string Open =
					"/html/body/div[1]/div/div/div[1]/div/div[3]/div[1]/div/div[1]/div/div[2]/div[1]/table/tbody/tr[2]/td[2]/span";

				public const string Bid =
					"/html/body/div[1]/div/div/div[1]/div/div[3]/div[1]/div/div[1]/div/div[2]/div[1]/table/tbody/tr[3]/td[2]";

				public const string Ask =
					"/html/body/div[1]/div/div/div[1]/div/div[3]/div[1]/div/div[1]/div/div[2]/div[1]/table/tbody/tr[4]/td[2]";

				public const string DaysRange =
					"/html/body/div[1]/div/div/div[1]/div/div[3]/div[1]/div/div[1]/div/div[2]/div[1]/table/tbody/tr[5]/td[2]";

				public const string YearsRange =
					"/html/body/div[1]/div/div/div[1]/div/div[3]/div[1]/div/div[1]/div/div[2]/div[1]/table/tbody/tr[6]/td[2]";

				public const string Volume =
					"/html/body/div[1]/div/div/div[1]/div/div[3]/div[1]/div/div[1]/div/div[2]/div[1]/table/tbody/tr[7]/td[2]/span";

				public const string AvgVolume =
					"/html/body/div[1]/div/div/div[1]/div/div[3]/div[1]/div/div[1]/div/div[2]/div[1]/table/tbody/tr[8]/td[2]/span";

				public const string MarketCap =
					"/html/body/div[1]/div/div/div[1]/div/div[3]/div[1]/div/div[1]/div/div[2]/div[2]/table/tbody/tr[1]/td[2]/span";

				public const string Beta =
					"/html/body/div[1]/div/div/div[1]/div/div[3]/div[1]/div/div[1]/div/div[2]/div[2]/table/tbody/tr[2]/td[2]/span";

				public const string PERatio =
					"/html/body/div[1]/div/div/div[1]/div/div[3]/div[1]/div/div[1]/div/div[2]/div[2]/table/tbody/tr[3]/td[2]/span";

				public const string EPSRatio =
					"/html/body/div[1]/div/div/div[1]/div/div[3]/div[1]/div/div[1]/div/div[2]/div[2]/table/tbody/tr[4]/td[2]/span";

				public const string EarningsDate =
					"/html/body/div[1]/div/div/div[1]/div/div[3]/div[1]/div/div[1]/div/div[2]/div[2]/table/tbody/tr[5]/td[2]";

				public const string DividendAndYield =
					"/html/body/div[1]/div/div/div[1]/div/div[3]/div[1]/div/div[1]/div/div[2]/div[2]/table/tbody/tr[6]/td[2]";

				public const string ExDividendDate =
					"/html/body/div[1]/div/div/div[1]/div/div[3]/div[1]/div/div[1]/div/div[2]/div[2]/table/tbody/tr[7]/td[2]/span";

				public const string OneYearTarget =
					"/html/body/div[1]/div/div/div[1]/div/div[3]/div[1]/div/div[1]/div/div[2]/div[2]/table/tbody/tr[8]/td[2]/span";
			}
		}

		struct StatisticsPage
		{
			public struct ID
			{

			}

			public struct XPath
			{
				public const string MarketCap = "/html/body/div[1]/div/div/div[1]/div/div[3]/div[1]/div/div[1]/div/div/section/div[2]/div[1]/div[1]/div/table/tbody/tr[1]/td[2]";
				//public const string  = "";
				//public const string  = "";
				//public const string  = "";
				//public const string  = "";
				//public const string  = "";
				//public const string  = "";
				//public const string  = "";
				//public const string  = "";
				//public const string  = "";
				//public const string  = "";
				//public const string  = "";
				//public const string  = "";
				//public const string  = "";
				//public const string  = "";
				//public const string  = "";
				//public const string  = "";
				//public const string  = "";
				//public const string  = "";
				//public const string  = "";
				//public const string  = "";
				//public const string  = "";
				//public const string  = "";
			}
		}

		readonly IWebDriver _driver;
		readonly WebDriverWait _wait;
		readonly Actions _actions;

		public YahooFinanceTarget(IWebDriver driver, WebDriverWait wait, Actions actions)
		{
			_driver = driver;
			_wait = wait;
			_actions = actions;
		}

		public string GetDescription(string ticker)
		{
			return SeleniumHelper.GetElemByID(_driver, _wait, _actions, GetSummaryUrl(ticker), SummaryPage.ID.Description).Text;
		}

		public string GetName(string ticker)
		{
			return SeleniumHelper.GetElemByXPath(_driver, _wait, _actions, GetSummaryUrl(ticker), SummaryPage.XPath.Name).Text;
		}

		public string GetPrice(string ticker)
		{
			return SeleniumHelper.GetElemByXPath(_driver, _wait, _actions, GetSummaryUrl(ticker), SummaryPage.XPath.Price).Text;
		}

		public string GetMarketCap(string ticker)
		{
			return SeleniumHelper.GetElemByXPath(_driver, _wait, _actions, GetStatisticUrl(ticker), StatisticsPage.XPath.MarketCap).Text;
		}

		public string GetTargetName() => "Yahoo Finance";

		string GetSummaryUrl(string ticker) => $"https://finance.yahoo.com/quote/{ticker}?p={ticker}";

		string GetStatisticUrl(string ticker) => $"https://finance.yahoo.com/quote/{ticker}/key-statistics?p={ticker}";
	}
}
