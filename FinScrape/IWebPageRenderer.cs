using OpenQA.Selenium;

namespace FinScrape
{
	public interface IWebPageRenderer
	{
		IWebElement GetElemByID(string url, string id);
		IWebElement GetElemByXPath(string url, string xpath);
	}
}
