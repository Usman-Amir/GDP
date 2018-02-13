using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPAssessment.Rules
{
	public class RuleMaker
	{
		public static Rule MakeRule(String productName, String ruleType, dynamic param)
		{
			switch (ruleType)
			{
				case "discount":
					return new Discount()
					{
						Purchased = (int)param.purchased,
						ChargedFor = (int)param.charged_for,
						ProductName = productName
					};

				case "price_drop":
					return new PriceDrop()
					{
						DroppedPrice = (double)param.dropped_price,
						MinNumItems = (int)param.min_num_items,
						ProductName = productName
					};

				default:
					return new Rule()
					{
						ProductName = productName
					};
			}
		}
	}
}
