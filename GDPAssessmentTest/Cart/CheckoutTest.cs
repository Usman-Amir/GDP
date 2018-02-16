using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDPAssessment.Products;
using GDPAssessment.Rules;
using GDPAssessment.Cart;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using TestCleanup = NUnit.Framework.TearDownAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using ClassCleanup = NUnit.Framework.TestFixtureTearDownAttribute;
using ClassInitialize = NUnit.Framework.TestFixtureSetUpAttribute;

using NUnitAssert = NUnit.Framework.Assert;
using NUnit.Framework;

namespace GDPAssessmentTest.Cart
{
	[TestClass]
	public class CheckoutTest
	{
		[TestMethod]
		public void CheckoutProduct_WithoutProduct_ReturnsZeroProduct()
		{
			// Arrange
			var products = new List<Product> { };
			var rules = new List<Rule> { };
			// Act
			var result = AdsCheckout.PerformCheckout(products, rules);
			// Assert
			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void CheckoutProduct_DifferentProductWithRules_ReturnsTotalAmount()
		{
			// Arrange
			var products = new List<Product> {
				new Product { Name = "Classic Ad", Price = 269.99 },
				new Product { Name = "Premium Ad", Price = 394.99 },
			};
			var rules = new List<Rule> {
				new Rule { ProductName = "Classic Ads" },
				new Rule { ProductName = "Standout Ads" }
			};
			// Act
			var result = AdsCheckout.PerformCheckout(products, rules);
			// Assert
			Assert.AreEqual(664.98, result);
		}
		[TestMethod]
		public void CheckoutProduct_NikeProductWithRules_ReturnDiscountedPriceAsPerRule()
		{
			//Arrange
			var products = new List<Product> {
				new Product { Name="Premium Ad", Price = 379.99 },
				new Product { Name="Premium Ad", Price = 379.99 },
				new Product { Name="Premium Ad", Price = 379.99 },
				new Product { Name="Premium Ad", Price = 379.99 }
			};
			var rules = new List<Rule> {
				new Rule { ProductName = "Premium Ads" }
			};

			//Act
			var result = AdsCheckout.PerformCheckout(products,rules );
			//Assert
			Assert.AreEqual(1519.96, result);
		}
	}
}
