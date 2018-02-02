using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinScrape.ScrapingTarget
{
	public interface IScrapingTarget
	{
		string GetDescription(string ticker);
		string GetPrice(string ticker);
		string GetTargetName();
	}
}
