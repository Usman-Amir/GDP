using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDPAssessment.Products;

namespace GDPAssessment.Rules
{
	interface IRule
	{
		ProductPrice execute(List<Product> cartitems);
	}
}
