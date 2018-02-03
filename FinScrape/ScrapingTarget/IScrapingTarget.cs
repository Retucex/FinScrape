namespace FinScrape.ScrapingTarget
{
	public interface IScrapingTarget
	{
		string GetDescription(string ticker);
		string GetPrice(string ticker);
		string GetTargetName();
	}
}
