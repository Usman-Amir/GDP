using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDPAssessment.Products;

namespace GDPAssessment.Rules
{
	public class ProductPrice
	{
		public List<Product> ProductsList { get; set; }
		public double price { get; set; }
		public ProductPrice(List<Product> prd, double prc)
		{
			this.ProductsList = prd;
			this.price = prc;
		}
		
	}
}
