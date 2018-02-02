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
	public class YahooFinanceTarget : IScrapingTarget
	{
		struct SummaryPage
		{
			public struct ID
			{
				public const string Description = "Col2-9-QuoteModule-Proxy";
				public const string QuoteHeaderInfo = "quote-header-info";
				public const string QuoteSummary = "quote-summary";


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
		string _quoteHeaderInfo;
		string _quoteSummary;
		string _lastTicker;

		public YahooFinanceTarget(IWebDriver driver, WebDriverWait wait, Actions actions)
		{
			_driver = driver;
			_wait = wait;
			_actions = actions;
		}

		public string GetQuoteHeaderInfo(string ticker)
		{
			if (ticker != _lastTicker)
				_quoteHeaderInfo = SeleniumHelper.GetElemByID(_driver, _wait, _actions, GetSummaryUrl(ticker), SummaryPage.ID.QuoteHeaderInfo).Text;

            _lastTicker = ticker;

            return _quoteHeaderInfo;
		}


        /* Example output:
Previous Close 106.60
Open 107.00
Bid 0.00 x 0
Ask 0.00 x 0
Day's Range 106.68 - 108.41
52 Week Range 65.63 - 108.41
Volume 6,786,305
Avg. Volume 8,923,319
Market Cap 321.092B
Beta 0.10
PE Ratio (TTM) 28.77
EPS (TTM) 3.77
Earnings Date Feb 20, 2018
Forward Dividend & Yield 2.04 (1.91%)
Ex-Dividend Date 2017-12-07
1y Target Est 105.13
Trade prices are not sourced from all markets
        //*/
        public string GetQuoteSummary(string ticker)
		{
			if (ticker != _lastTicker)
				_quoteSummary = SeleniumHelper.GetElemByID(_driver, _wait, _actions, GetSummaryUrl(ticker), SummaryPage.ID.QuoteSummary).Text;

		    _lastTicker = ticker;

		    return _quoteSummary;
		}

		public string GetDescription(string ticker)
			=> SeleniumHelper.GetElemByID(_driver, _wait, _actions, GetSummaryUrl(ticker), SummaryPage.ID.Description).Text;

		public string GetName(string ticker)
			=> GetQuoteHeaderInfo(ticker).Split('\n')[0].Trim();

		public string GetPrice(string ticker)
            => GetQuoteHeaderInfo(ticker).Split('\n')[3].Trim();

        public string GetPreviousClose(string ticker)
			=> SeleniumHelper.GetElemByXPath(_driver, _wait, _actions, GetSummaryUrl(ticker), SummaryPage.XPath.PrevClose).Text;

		public string GetOpen(string ticker)
			=> SeleniumHelper.GetElemByXPath(_driver, _wait, _actions, GetSummaryUrl(ticker), SummaryPage.XPath.Open).Text;

		public string GetBid(string ticker) => SeleniumHelper.GetElemByXPath(_driver, _wait, _actions, GetSummaryUrl(ticker), SummaryPage.XPath.Bid).Text;

		public string GetAsk(string ticker) => SeleniumHelper.GetElemByXPath(_driver, _wait, _actions, GetSummaryUrl(ticker), SummaryPage.XPath.Ask).Text;

		public string GetDaysRange(string ticker) => SeleniumHelper.GetElemByXPath(_driver, _wait, _actions, GetSummaryUrl(ticker), SummaryPage.XPath.DaysRange).Text;

		public string GetYearsRange(string ticker) => SeleniumHelper.GetElemByXPath(_driver, _wait, _actions, GetSummaryUrl(ticker), SummaryPage.XPath.YearsRange).Text;

		public string GetVolume(string ticker) => SeleniumHelper.GetElemByXPath(_driver, _wait, _actions, GetSummaryUrl(ticker), SummaryPage.XPath.Volume).Text;

		public string GetAvgVolume(string ticker) => SeleniumHelper.GetElemByXPath(_driver, _wait, _actions, GetSummaryUrl(ticker), SummaryPage.XPath.AvgVolume).Text;

		public string GetSummMarketCap(string ticker) => SeleniumHelper.GetElemByXPath(_driver, _wait, _actions, GetSummaryUrl(ticker), SummaryPage.XPath.MarketCap).Text;

		public string GetBeta(string ticker) => SeleniumHelper.GetElemByXPath(_driver, _wait, _actions, GetSummaryUrl(ticker), SummaryPage.XPath.Beta).Text;

		public string GetPERatio(string ticker) => SeleniumHelper.GetElemByXPath(_driver, _wait, _actions, GetSummaryUrl(ticker), SummaryPage.XPath.PERatio).Text;

		public string GetEPSRatio(string ticker) => SeleniumHelper.GetElemByXPath(_driver, _wait, _actions, GetSummaryUrl(ticker), SummaryPage.XPath.EPSRatio).Text;

		public string GetStatMarketCap(string ticker) => SeleniumHelper.GetElemByXPath(_driver, _wait, _actions, GetStatisticUrl(ticker), StatisticsPage.XPath.MarketCap).Text;

		public string GetEarningsDate(string ticker) => SeleniumHelper.GetElemByXPath(_driver, _wait, _actions, GetSummaryUrl(ticker), SummaryPage.XPath.EarningsDate).Text;

		public string GetDividendAndYield(string ticker) => SeleniumHelper.GetElemByXPath(_driver, _wait, _actions, GetSummaryUrl(ticker), SummaryPage.XPath.DividendAndYield).Text;

		public string GetExDividendDate(string ticker) => SeleniumHelper.GetElemByXPath(_driver, _wait, _actions, GetSummaryUrl(ticker), SummaryPage.XPath.ExDividendDate).Text;

		public string GetOneYearTarget(string ticker) => SeleniumHelper.GetElemByXPath(_driver, _wait, _actions, GetSummaryUrl(ticker), SummaryPage.XPath.OneYearTarget).Text;

		public string GetTargetName() => "Yahoo Finance";

		string GetSummaryUrl(string ticker) => $"https://finance.yahoo.com/quote/{ticker}?p={ticker}";

		string GetStatisticUrl(string ticker) => $"https://finance.yahoo.com/quote/{ticker}/key-statistics?p={ticker}";
	}
}
