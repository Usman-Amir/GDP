using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Dynamic;
using GDPAssessment.Rules;

namespace GDPAssessmentTest.Rules
{
	[TestClass]
	public class RuleMakerTest
	{
		[TestMethod]
		public void GetRulesForCustomer_RuleNotMatched_ReturnsDefaultRule()
		{
			// Arrange
			dynamic param = new ExpandoObject();
			// Act
			var result = RuleMaker.MakeRule("Default", "promotions", param);
			// Assert
			Assert.AreEqual("Default", result.ProductName);
		}

		[TestMethod]
		public void GetRulesForCustomer_RuleForDiscount_ReturnsDiscountRule()
		{
			// Arrange
			dynamic param = new ExpandoObject();
			param.purchased = 3;
			param.charged_for = 2;
			// Act
			var result = RuleMaker.MakeRule("Classic Ad", "discount", param);
			// Assert
			Assert.AreEqual("Classic Ad", result.ProductName);
		}
		[TestMethod]
		public void GetRulesForCustomer_RuleForPriceDrop_ReturnpricedropRule()
		{
			// Arrange
			dynamic param = new ExpandoObject();
			param.dropped_price = 299.99;
			param.min_num_items = 1;
			// Act
			var result = RuleMaker.MakeRule("Standout Ad", "price_drop", param);
			// Assert
			Assert.AreEqual("Standout Ad", result.ProductName);
		}
	}
}
