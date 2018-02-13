using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GDPAssessment.Rules;
using GDPAssessment.Products;
using System.Collections.Generic;
using System.Linq;

namespace GDPAssessmentTest.Price
{
	[TestClass]
	public class PriceDropTest
	{
		private readonly PriceDrop _target = new PriceDrop();

		[TestMethod]
		public void execute_NoProduct_ReturnsNothing()
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
		public void execute_DifferentProduct_ReturnsRemainingItemsAndDroppedPrice()
		{
			// Arrange
			_target.ProductName = "Premium Ad";
			_target.DroppedPrice = 379.99;
			_target.MinNumItems = 4;
			var products = new List<Product> {
				new Product { Name = "Classic Ad", Price = 269.99 },
				new Product { Name = "Premium Ad", Price = 394.99 },
				new Product { Name = "Premium Ad", Price = 394.99 },
				new Product { Name = "Premium Ad", Price = 394.99 },
				new Product { Name = "Premium Ad", Price = 394.99 },
				new Product { Name = "Premium Ad", Price = 394.99 },
			};
			// Act
			var result = _target.execute(products);
			// Assert
			Assert.AreEqual(1, result.ProductsList.Count);
			Assert.AreEqual("Classic Ad", result.ProductsList.FirstOrDefault().Name);
			Assert.AreEqual(1899.95, result.price);
		}
	}
}
