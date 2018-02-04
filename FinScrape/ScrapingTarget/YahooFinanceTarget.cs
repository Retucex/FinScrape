using Serilog;

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
				public const string KeyStatisticsID = "Col1-0-KeyStatistics-Proxy";
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

		public string Ticker
		{
			get => ticker;
			set
			{
				ticker = value;
				GetQuoteInfos();
			}

		}

		public string Description { get; private set; }

		public string Name { get; private set; }

		public string Price { get; private set; }

		public string PreviousClose { get; private set; }

		public string Open { get; private set; }

		public string Bid { get; private set; }

		public string Ask { get; private set; }

		public string DaysRange { get; private set; }

		public string YearsRange { get; private set; }

		public string Volume { get; private set; }

		public string AvgVolume { get; private set; }

		public string SummMarketCap { get; private set; }

		public string Beta { get; private set; }

		public string PERatio { get; private set; }

		public string EPSRatio { get; private set; }

		public string StatMarketCap { get; private set; }

		public string EarningsDate { get; private set; }

		public string DividendAndYield { get; private set; }

		public string ExDividendDate { get; private set; }

		public string OneYearTarget { get; private set; }

		readonly IWebPageRenderer webPageRenderer;
		string quoteHeaderInfo;
		string quoteSummary;
		string quoteKeyStatistics;
		string ticker;

		public YahooFinanceTarget(IWebPageRenderer webPageRenderer, string ticker)
		{
			this.webPageRenderer = webPageRenderer;
			Ticker = ticker;
		}

		void GetQuoteInfos()
		{
			quoteHeaderInfo = webPageRenderer.GetElemByID(GetSummaryUrl(Ticker), SummaryPage.ID.QuoteHeaderInfo).Text;
			Log.Debug("Fetched quoteHeaderInfo for {ticker}: {quoteHeaderInfo}", Ticker, quoteHeaderInfo);

			quoteSummary = webPageRenderer.GetElemByID(GetSummaryUrl(Ticker), SummaryPage.ID.QuoteSummary).Text;
			Log.Debug("Fetched quoteSummary for {ticker}: {quoteSummary}", Ticker, quoteSummary);

			quoteKeyStatistics = webPageRenderer.GetElemByID(GetStatisticUrl(Ticker), StatisticsPage.ID.KeyStatisticsID).Text;
			Log.Debug("Fetched quoteStatistics for {ticker}: {quoteKeyStatistics}", Ticker, quoteKeyStatistics);


			//TODO Change target from summary page to profile page
			Description = webPageRenderer.GetElemByID(GetSummaryUrl(ticker), SummaryPage.ID.Description).Text;

			ParseQuoteInfos();
		}

		void ParseQuoteInfos()
		{
			Name = quoteHeaderInfo.Split('\n')[0].Trim();
			Price = quoteHeaderInfo.Split('\n')[3].Split('+', '-')[0].Trim();

			PreviousClose = quoteSummary.Split('\n')[0].Substring("Previous Close".Length).Trim();
			Open = quoteSummary.Split('\n')[1].Substring("Open".Length).Trim();
			Bid = quoteSummary.Split('\n')[2].Substring("Bid".Length).Trim();
			Ask = quoteSummary.Split('\n')[3].Substring("Ask".Length).Trim();
			DaysRange = quoteSummary.Split('\n')[4].Substring("Day's Range".Length).Trim();
			YearsRange = quoteSummary.Split('\n')[5].Substring("52 Week Range".Length).Trim();
			Volume = quoteSummary.Split('\n')[6].Substring("Volume".Length).Trim();
			AvgVolume = quoteSummary.Split('\n')[7].Substring("Avg. Volume".Length).Trim();
			SummMarketCap = quoteSummary.Split('\n')[8].Substring("Market Cap".Length).Trim();
			Beta = quoteSummary.Split('\n')[9].Substring("Beta".Length).Trim();
			PERatio = quoteSummary.Split('\n')[10].Substring("PE Ratio (TTM)".Length).Trim();
			EPSRatio = quoteSummary.Split('\n')[11].Substring("EPS (TTM)".Length).Trim();
			EarningsDate = quoteSummary.Split('\n')[12].Substring("Earnings Date".Length).Trim();
			DividendAndYield = quoteSummary.Split('\n')[13].Substring("Forward Dividend & Yield".Length).Trim();
			ExDividendDate = quoteSummary.Split('\n')[14].Substring("Ex-Dividend Date".Length).Trim();
			OneYearTarget = quoteSummary.Split('\n')[15].Substring("1y Target Est".Length).Trim();
		}

		string GetSummaryUrl(string ticker) => $"https://finance.yahoo.com/quote/{ticker}?p={ticker}";

		string GetStatisticUrl(string ticker) => $"https://finance.yahoo.com/quote/{ticker}/key-statistics?p={ticker}";
	}
}
