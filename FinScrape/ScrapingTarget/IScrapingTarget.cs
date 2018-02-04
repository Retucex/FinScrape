namespace FinScrape.ScrapingTarget
{
	public interface IScrapingTarget
	{
		string Description { get; }
		string Price { get; }
	}
}
