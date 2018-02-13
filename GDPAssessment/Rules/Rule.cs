using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDPAssessment.Products;

namespace GDPAssessment.Rules
{
	public class Rule : IRule
	{
		public String ProductName { get; set; }

		public virtual ProductPrice execute(List<Product> cartitems)
		{
			if (cartitems.Count > 0)
			{
				var item = cartitems.FirstOrDefault();
				cartitems.Remove(item);
				return new ProductPrice(cartitems, item.Price);
			}

			return null;
		}
	}
}

