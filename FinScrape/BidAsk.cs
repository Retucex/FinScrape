using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinScrape
{
	public class BidAsk
	{
		public double Price { get; set; }
		public int Volume { get; set; }

		public override string ToString() => $"{Price:C} x {Volume:.2}";
	}
}
