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
        string ticker;
        
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

            yahooFinanceTarget = new YahooFinanceTarget(webPageRenderer);

            ticker = "wmt";
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            driver.Quit();
            driver = null;
        }

        [Test]
        public void ShouldGetQuoteHeaderInfo()
        {
            var data = yahooFinanceTarget.GetQuoteHeaderInfo(ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetQuoteSummary()
        {
            var data = yahooFinanceTarget.GetQuoteSummary(ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetNameCompany()
        {
            var data = yahooFinanceTarget.GetName(ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetPrice()
        {
            var data = yahooFinanceTarget.GetPrice(ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetAsk()
        {
            var data = yahooFinanceTarget.GetAsk(ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }


        [Test]
        public void ShouldGetAvgVolume()
        {
            var data = yahooFinanceTarget.GetAvgVolume(ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetBeta()
        {
            var data = yahooFinanceTarget.GetBeta(ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetBid()
        {
            var data = yahooFinanceTarget.GetBid(ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetDaysRange()
        {
            var data = yahooFinanceTarget.GetDaysRange(ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetDescription()
        {
            var data = yahooFinanceTarget.GetDescription(ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetDividendAndYield()
        {
            var data = yahooFinanceTarget.GetDividendAndYield(ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetEPSRatio()
        {
            var data = yahooFinanceTarget.GetEPSRatio(ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetEarningsDate()
        {
            var data = yahooFinanceTarget.GetEarningsDate(ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetExDividendDate()
        {
            var data = yahooFinanceTarget.GetExDividendDate(ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetOneYearTarget()
        {
            var data = yahooFinanceTarget.GetOneYearTarget(ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetOpen()
        {
            var data = yahooFinanceTarget.GetOpen(ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetPERatio()
        {
            var data = yahooFinanceTarget.GetPERatio(ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetPreviousClose()
        {
            var data = yahooFinanceTarget.GetPreviousClose(ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetStatMarketCap()
        {
            var data = yahooFinanceTarget.GetStatMarketCap(ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetSummMarketCap()
        {
            var data = yahooFinanceTarget.GetSummMarketCap(ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetVolume()
        {
            var data = yahooFinanceTarget.GetVolume(ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetYearsRange()
        {
            var data = yahooFinanceTarget.GetYearsRange(ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }
    }
}
