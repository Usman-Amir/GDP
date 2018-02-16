using System;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using TestCleanup = NUnit.Framework.TearDownAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using ClassCleanup = NUnit.Framework.TestFixtureTearDownAttribute;
using ClassInitialize = NUnit.Framework.TestFixtureSetUpAttribute;

using NUnitAssert = NUnit.Framework.Assert;
using System.Dynamic;
using GDPAssessment.Rules;
using NUnit.Framework;

namespace GDPAssessmentTest.Rules
{
	[@TestClass]
	public class RuleMakerTest
	{
		[@TestMethod]
		public void GetRulesForCustomer_RuleNotMatched_ReturnsDefaultRule()
		{
			// Arrange
			dynamic param = new ExpandoObject();
			// Act
			var result = RuleMaker.MakeRule("Default", "promotions", param);
			// Assert
			Assert.AreEqual("Default", result.ProductName);
		}

		[@TestMethod]
		public void GetRulesForCustomer_RuleForDiscount_ReturnsDiscountRule()
		{
			// Arrange
			dynamic param = new ExpandoObject();
			param.purchased = 3;
			param.chargedfor = 2;
			// Act
			var result = RuleMaker.MakeRule("Classic Ad", "discount", param);
			// Assert
			Assert.AreEqual("Classic Ad", result.ProductName);
		}
		[@TestMethod]
		public void GetRulesForCustomer_RuleForPriceDrop_ReturnpricedropRule()
		{
			// Arrange
			dynamic param = new ExpandoObject();
			param.droppedprice = 299.99;
			param.minnumitems = 1;
			// Act
			var result = RuleMaker.MakeRule("Standout Ad", "price_drop", param);
			// Assert
			Assert.AreEqual("Standout Ad", result.ProductName);
		}
	}
}
