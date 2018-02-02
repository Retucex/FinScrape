using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Serilog;

namespace FinScrape
{
	public class SeleniumWebPageRenderer : IWebPageRenderer
	{
		readonly IWebDriver driver;
		readonly WebDriverWait wait;
		readonly Actions browserActions;

		public SeleniumWebPageRenderer(IWebDriver driver, WebDriverWait wait, Actions browserActions)
		{
			this.driver = driver;
			this.wait = wait;
			this.browserActions = browserActions;
		}

		public IWebElement GetElemByID(string url, string id)
		{
			Log.Debug("Get Elem by ID '{id}' at {url}", id, url);

			if (driver.Url != url)
			{
				driver.Url = url;
				driver.Navigate();
				Log.Debug("Navigated to new URL {url}", url);
			}

			var elem = wait.Until<IWebElement>(d => d.FindElement(By.Id(id)));

			try
			{
				browserActions.MoveToElement(elem);
				browserActions.Perform();
			}
			catch (Exception e)
			{
				Log.Error(e, "Unable to navigate to element.");
			}

			return elem;
		}

		public IWebElement GetElemByXPath(string url, string xpath)
		{
			Log.Debug("Get Elem by XPath '{xpath}' at {url}", xpath, url);

			if (driver.Url != url)
			{
				driver.Url = url;
				driver.Navigate();
				Log.Debug("Navigated to new URL {url}", url);
			}

			var elem = wait.Until<IWebElement>(d => d.FindElement(By.XPath(xpath)));

			try
			{
				browserActions.MoveToElement(elem);
				browserActions.Perform();
			}
			catch (Exception e)
			{
				Log.Error(e, "Unable to navigate to element.");
			}

			return elem;
		}

		public static string GetText(IWebElement webElement) => webElement.GetAttribute("textContent");

		~SeleniumWebPageRenderer() => driver.Quit();
	}
}
