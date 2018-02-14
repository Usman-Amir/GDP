using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDPAssessment.Products;

namespace GDPAssessment.Rules
{
	public class Discount : Rule
	{
		public int Purchased { get; set; }
		public int ChargedFor { get; set; }

		public override ProductPrice execute(List<Product> cartItems)
		{
			var selectedItems = cartItems.Where(x => x.Name == this.ProductName);
			double itemPrice = 0;

			if (selectedItems.Any())
				itemPrice = selectedItems.FirstOrDefault().Price;

			if (selectedItems.Count() >= this.Purchased)
			{
				cartItems.RemoveAll(x => x.Name == this.ProductName);
				return new ProductPrice(cartItems, itemPrice * this.ChargedFor);
			}

			return new ProductPrice(cartItems, 0);
		}
	}
}
