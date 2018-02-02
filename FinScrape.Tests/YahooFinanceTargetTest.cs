using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        IWebDriver _driver;
        WebDriverWait _wait;
        Actions _actions;
        YahooFinanceTarget _yahooFinanceTarget;
        string _ticker;
        
        [OneTimeSetUp]
        public void TestSetup()
        {
            var options = new ChromeOptions();
            options.AddArgument("headless");
            options.AddArgument("--log-level=3");
            options.AddArgument("--silent");

            _driver = new ChromeDriver(options);

            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _actions = new Actions(_driver);

            _yahooFinanceTarget = new YahooFinanceTarget(_driver, _wait, _actions);

            _ticker = "wmt";
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            _driver.Quit();
            _driver = null;
        }

        [Test]
        public void ShouldGetQuoteHeaderInfo()
        {
            var data = _yahooFinanceTarget.GetQuoteHeaderInfo(_ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetQuoteSummary()
        {
            var data = _yahooFinanceTarget.GetQuoteSummary(_ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetNameCompany()
        {
            var data = _yahooFinanceTarget.GetName(_ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetPrice()
        {
            var data = _yahooFinanceTarget.GetPrice(_ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetAsk()
        {
            var data = _yahooFinanceTarget.GetAsk(_ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }


        [Test]
        public void ShouldGetAvgVolume()
        {
            var data = _yahooFinanceTarget.GetAvgVolume(_ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetBeta()
        {
            var data = _yahooFinanceTarget.GetBeta(_ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetBid()
        {
            var data = _yahooFinanceTarget.GetBid(_ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetDaysRange()
        {
            var data = _yahooFinanceTarget.GetDaysRange(_ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetDescription()
        {
            var data = _yahooFinanceTarget.GetDescription(_ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetDividendAndYield()
        {
            var data = _yahooFinanceTarget.GetDividendAndYield(_ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetEPSRatio()
        {
            var data = _yahooFinanceTarget.GetEPSRatio(_ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetEarningsDate()
        {
            var data = _yahooFinanceTarget.GetEarningsDate(_ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetExDividendDate()
        {
            var data = _yahooFinanceTarget.GetExDividendDate(_ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetOneYearTarget()
        {
            var data = _yahooFinanceTarget.GetOneYearTarget(_ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetOpen()
        {
            var data = _yahooFinanceTarget.GetOpen(_ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetPERatio()
        {
            var data = _yahooFinanceTarget.GetPERatio(_ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetPreviousClose()
        {
            var data = _yahooFinanceTarget.GetPreviousClose(_ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetStatMarketCap()
        {
            var data = _yahooFinanceTarget.GetStatMarketCap(_ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetSummMarketCap()
        {
            var data = _yahooFinanceTarget.GetSummMarketCap(_ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetVolume()
        {
            var data = _yahooFinanceTarget.GetVolume(_ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void ShouldGetYearsRange()
        {
            var data = _yahooFinanceTarget.GetYearsRange(_ticker);
            Console.WriteLine(data);

            Assert.IsNotEmpty(data);
        }
    }
}
