using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDPAssessment.Products;

namespace GDPAssessment.Rules
{
	public class PriceDrop: Rule
	{
		public double DroppedPrice { get; set; }
		public int MinNumItems { get; set; }

		public override ProductPrice execute(List<Product> cartItems)
		{
			var selectedItems = cartItems.Where(x => x.Name == this.ProductName);
			if (selectedItems.Count() >= this.MinNumItems)
			{
				int itemCount = selectedItems.Count();
				cartItems.RemoveAll(x => x.Name == this.ProductName);

				return new ProductPrice(cartItems, itemCount * this.DroppedPrice);
			}

			return new ProductPrice(cartItems, 0);
		}
	}
}
