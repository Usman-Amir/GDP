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
				for (int i = 0; i < this.Purchased; i++)
				{
					cartItems.Remove(cartItems.FirstOrDefault(x => x.Name == this.ProductName));
				}

				return new ProductPrice(cartItems, itemPrice * this.ChargedFor);
			}

			return new ProductPrice(cartItems, 0);
		}
	}
}
