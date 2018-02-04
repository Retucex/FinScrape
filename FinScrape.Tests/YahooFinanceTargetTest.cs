using System;
using FinScrape.ScrapingTarget;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace FinScrape.Tests
{
	[TestFixture]
    public class YahooFinanceTargetTest
    {
        IWebDriver driver;
        WebDriverWait wait;
        Actions actions;
        YahooFinanceTarget yahooFinanceTarget;
        
        [OneTimeSetUp]
        public void TestSetup()
        {
			var options = new ChromeOptions();
            options.AddArgument("headless");
            options.AddArgument("--log-level=3");
            options.AddArgument("--silent");

            driver = new ChromeDriver(options);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            actions = new Actions(driver);

			var webPageRenderer = new SeleniumWebPageRenderer(driver, wait, actions);

            yahooFinanceTarget = new YahooFinanceTarget(webPageRenderer, "wmt");
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            driver.Quit();
            driver = null;
        }

		[Test]
	    public void DescriptionTest()
	    {
		    Console.WriteLine(yahooFinanceTarget.Description);
			Assert.IsNotEmpty(yahooFinanceTarget.Description);
	    }

		[Test]
	    public void NameTest()
	    {
		    Console.WriteLine(yahooFinanceTarget.Name);
		    Assert.IsNotEmpty(yahooFinanceTarget.Name);
	    }

	    [Test]
		public void PriceTest()
	    {
		    Console.WriteLine(yahooFinanceTarget.Price);
		    Assert.IsNotEmpty(yahooFinanceTarget.Price);
	    }

	    [Test]
		public void PreviousCloseTest()
	    {
		    Console.WriteLine(yahooFinanceTarget.PreviousClose);
		    Assert.IsNotEmpty(yahooFinanceTarget.PreviousClose);
	    }

	    [Test]
		public void OpenTest()
	    {
		    Console.WriteLine(yahooFinanceTarget.Open);
		    Assert.IsNotEmpty(yahooFinanceTarget.Open);
	    }

	    [Test]
		public void BidTest()
	    {
		    Console.WriteLine(yahooFinanceTarget.Bid);
		    Assert.IsNotEmpty(yahooFinanceTarget.Bid);
	    }

	    [Test]
		public void AskTest()
	    {
		    Console.WriteLine(yahooFinanceTarget.Ask);
		    Assert.IsNotEmpty(yahooFinanceTarget.Ask);
	    }

	    [Test]
		public void DaysRangeTest()
	    {
		    Console.WriteLine(yahooFinanceTarget.DaysRange);
		    Assert.IsNotEmpty(yahooFinanceTarget.DaysRange);
	    }

	    [Test]
		public void YearsRangeTest()
	    {
		    Console.WriteLine(yahooFinanceTarget.YearsRange);
		    Assert.IsNotEmpty(yahooFinanceTarget.YearsRange);
	    }

	    [Test]
		public void VolumeTest()
	    {
		    Console.WriteLine(yahooFinanceTarget.Volume);
		    Assert.IsNotEmpty(yahooFinanceTarget.Volume);
	    }

	    [Test]
		public void AvgVolumeTest()
	    {
		    Console.WriteLine(yahooFinanceTarget.AvgVolume);
		    Assert.IsNotEmpty(yahooFinanceTarget.AvgVolume);
	    }

	    [Test]
		public void SummMarketCapTest()
	    {
		    Console.WriteLine(yahooFinanceTarget.SummMarketCap);
		    Assert.IsNotEmpty(yahooFinanceTarget.SummMarketCap);
	    }

	    [Test]
		public void BetaTest()
	    {
		    Console.WriteLine(yahooFinanceTarget.Beta);
		    Assert.IsNotEmpty(yahooFinanceTarget.Beta);
	    }

	    [Test]
		public void PERatioTest()
	    {
		    Console.WriteLine(yahooFinanceTarget.PERatio);
		    Assert.IsNotEmpty(yahooFinanceTarget.PERatio);
	    }

	    [Test]
		public void EPSRatioTest()
	    {
		    Console.WriteLine(yahooFinanceTarget.EPSRatio);
		    Assert.IsNotEmpty(yahooFinanceTarget.EPSRatio);
	    }

	    [Test]
		public void StatMarketCapTest()
	    {
		    Console.WriteLine(yahooFinanceTarget.StatMarketCap);
		    Assert.IsNotEmpty(yahooFinanceTarget.StatMarketCap);
	    }

	    [Test]
		public void EarningsDateTest()
	    {
		    Console.WriteLine(yahooFinanceTarget.EarningsDate);
		    Assert.IsNotEmpty(yahooFinanceTarget.EarningsDate);
	    }

	    [Test]
		public void DividendAndYieldTest()
	    {
		    Console.WriteLine(yahooFinanceTarget.DividendAndYield);
		    Assert.IsNotEmpty(yahooFinanceTarget.DividendAndYield);
	    }

	    [Test]
		public void ExDividendDateTest()
	    {
		    Console.WriteLine(yahooFinanceTarget.ExDividendDate);
		    Assert.IsNotEmpty(yahooFinanceTarget.ExDividendDate);
	    }

	    [Test]
		public void OneYearTargetTest()
	    {
		    Console.WriteLine(yahooFinanceTarget.OneYearTarget);
		    Assert.IsNotEmpty(yahooFinanceTarget.OneYearTarget);
	    }
	}
}
