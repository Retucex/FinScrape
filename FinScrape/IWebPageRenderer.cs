using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace FinScrape
{
	public interface IWebPageRenderer
	{
		IWebElement GetElemByID(string url, string id);
		IWebElement GetElemByXPath(string url, string xpath);
	}
}
