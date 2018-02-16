using System;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using TestCleanup = NUnit.Framework.TearDownAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using ClassCleanup = NUnit.Framework.TestFixtureTearDownAttribute;
using ClassInitialize = NUnit.Framework.TestFixtureSetUpAttribute;

using NUnitAssert = NUnit.Framework.Assert;
using GDPAssessment.Products;
using System.Collections.Generic;
using GDPAssessment.Rules;
using System.Linq;
using NUnit.Framework;

namespace GDPAssessmentTest.Rules
{
	[TestClass]
	public class DiscountTest
	{
		private readonly Discount _target = new Discount();

		[TestMethod]
		public void executeRule_NoProduct_ReturnsNothing()
		{
			// Arrange
			var products = new List<Product> { };
			// Act
			var result = _target.execute(products);
			// Assert
			Assert.AreEqual(0, result.ProductsList.Count);
			Assert.AreEqual(0, result.price);
		}

		[TestMethod]
		public void executeRule_MultipleProduct_ReturnsRemainingItemsWithDiscountedPrice()
		{
			// Arrange
			_target.ProductName = "Classic Ad";
			_target.Purchased = 3;
			_target.ChargedFor = 2;
			var products = new List<Product> {
				new Product { Name = "Classic Ad", Price = 269.99 },
				new Product { Name = "Classic Ad", Price = 269.99 },
				new Product { Name = "Classic Ad", Price = 269.99 },
				new Product { Name = "Premium Ad", Price = 394.99 },
			};
			// Act
			var result = _target.execute(products);
			// Assert
			Assert.AreEqual(1, result.ProductsList.Count);
			Assert.AreEqual("Premium Ad", result.ProductsList.FirstOrDefault().Name);
			Assert.AreEqual(539.98, result.price);
		}
	}
}
