using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDPAssessment.Products;
using GDPAssessment.Rules;

namespace GDPAssessment.Cart
{
	public class AdsCheckout
	{
		public static double PerformCheckout(List<Product> items, List<Rule> pricingRules)
		{
			if (items.Count == 0)
			{
				return 0;
			}

			double ratio = double.MaxValue;
			List<Product> remainingItems = items;
			double consumptionPrice = double.MinValue;

			foreach (var rule in pricingRules)
			{
				var executeResult = rule.execute(new List<Product>(items));
				var consumedItems = items.Count - executeResult.ProductsList.Count;

				var consumptionRatio = executeResult.price / consumedItems;
				if (consumptionRatio < ratio)
				{
					ratio = consumptionRatio;
					remainingItems = executeResult.ProductsList;
					consumptionPrice = executeResult.price;
				}
			}

			return PerformCheckout(remainingItems, pricingRules) + consumptionPrice;
		}
	}
}
