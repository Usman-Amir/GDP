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
	public class DefaultRuleTest
	{
		private Rule _target;

		[TestMethod]
		public void executeRule_WithoutProduct_ReturnsNull()
		{
			// Arrange
			_target = new Rule();
			var products = new List<Product> { };
			// Act
			var result = _target.execute(products);
			// Assert
			Assert.AreEqual(null, result);
		}

		[TestMethod]
		public void executeRule_DifferentProduct_ReturnsRemaingItemsAndPrice()
		{
			// Arrange
			_target = new Rule();
			var products = new List<Product> {
				new Product { Name = "Classic Ad", Price = 269.99 },
				new Product { Name = "Premium Ad", Price = 394.99 },
			};
			// Act
			var result = _target.execute(products);
			// Assert
			Assert.AreEqual(1, result.ProductsList.Count);
			Assert.AreEqual("Premium Ad", result.ProductsList.FirstOrDefault().Name);
			Assert.AreEqual(269.99, result.price);
		}
	}
}
