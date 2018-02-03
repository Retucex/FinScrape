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

		readonly IWebPageRenderer webPageRenderer;
		string quoteHeaderInfo;
		string quoteSummary;
		string lastTicker;

		public YahooFinanceTarget(IWebPageRenderer webPageRenderer)
		{
			this.webPageRenderer = webPageRenderer;
		}

		public string GetQuoteHeaderInfo(string ticker)
		{
			if (ticker != lastTicker)
				quoteHeaderInfo = webPageRenderer.GetElemByID(GetSummaryUrl(ticker), SummaryPage.ID.QuoteHeaderInfo).Text;

            lastTicker = ticker;

            return quoteHeaderInfo;
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
			if (ticker != lastTicker)
				quoteSummary = webPageRenderer.GetElemByID(GetSummaryUrl(ticker), SummaryPage.ID.QuoteSummary).Text;

		    lastTicker = ticker;

		    return quoteSummary;
		}

		public string GetDescription(string ticker) => webPageRenderer.GetElemByID(GetSummaryUrl(ticker), SummaryPage.ID.Description).Text;

		public string GetName(string ticker) => GetQuoteHeaderInfo(ticker).Split('\n')[0].Trim();

		public string GetPrice(string ticker) => GetQuoteHeaderInfo(ticker).Split('\n')[3].Trim();

        public string GetPreviousClose(string ticker) => webPageRenderer.GetElemByXPath(GetSummaryUrl(ticker), SummaryPage.XPath.PrevClose).Text;

		public string GetOpen(string ticker) => webPageRenderer.GetElemByXPath(GetSummaryUrl(ticker), SummaryPage.XPath.Open).Text;

		public string GetBid(string ticker) => webPageRenderer.GetElemByXPath(GetSummaryUrl(ticker), SummaryPage.XPath.Bid).Text;

		public string GetAsk(string ticker) => webPageRenderer.GetElemByXPath(GetSummaryUrl(ticker), SummaryPage.XPath.Ask).Text;

		public string GetDaysRange(string ticker) => webPageRenderer.GetElemByXPath(GetSummaryUrl(ticker), SummaryPage.XPath.DaysRange).Text;

		public string GetYearsRange(string ticker) => webPageRenderer.GetElemByXPath(GetSummaryUrl(ticker), SummaryPage.XPath.YearsRange).Text;

		public string GetVolume(string ticker) => webPageRenderer.GetElemByXPath(GetSummaryUrl(ticker), SummaryPage.XPath.Volume).Text;

		public string GetAvgVolume(string ticker) => webPageRenderer.GetElemByXPath(GetSummaryUrl(ticker), SummaryPage.XPath.AvgVolume).Text;

		public string GetSummMarketCap(string ticker) => webPageRenderer.GetElemByXPath(GetSummaryUrl(ticker), SummaryPage.XPath.MarketCap).Text;

		public string GetBeta(string ticker) => webPageRenderer.GetElemByXPath(GetSummaryUrl(ticker), SummaryPage.XPath.Beta).Text;

		public string GetPERatio(string ticker) => webPageRenderer.GetElemByXPath(GetSummaryUrl(ticker), SummaryPage.XPath.PERatio).Text;

		public string GetEPSRatio(string ticker) => webPageRenderer.GetElemByXPath(GetSummaryUrl(ticker), SummaryPage.XPath.EPSRatio).Text;

		public string GetStatMarketCap(string ticker) => webPageRenderer.GetElemByXPath(GetStatisticUrl(ticker), StatisticsPage.XPath.MarketCap).Text;

		public string GetEarningsDate(string ticker) => webPageRenderer.GetElemByXPath(GetSummaryUrl(ticker), SummaryPage.XPath.EarningsDate).Text;

		public string GetDividendAndYield(string ticker) => webPageRenderer.GetElemByXPath(GetSummaryUrl(ticker), SummaryPage.XPath.DividendAndYield).Text;

		public string GetExDividendDate(string ticker) => webPageRenderer.GetElemByXPath(GetSummaryUrl(ticker), SummaryPage.XPath.ExDividendDate).Text;

		public string GetOneYearTarget(string ticker) => webPageRenderer.GetElemByXPath(GetSummaryUrl(ticker), SummaryPage.XPath.OneYearTarget).Text;

		public string GetTargetName() => "Yahoo Finance";

		string GetSummaryUrl(string ticker) => $"https://finance.yahoo.com/quote/{ticker}?p={ticker}";

		string GetStatisticUrl(string ticker) => $"https://finance.yahoo.com/quote/{ticker}/key-statistics?p={ticker}";
	}
}
