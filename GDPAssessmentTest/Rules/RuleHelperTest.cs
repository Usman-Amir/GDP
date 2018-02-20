using System;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using TestCleanup = NUnit.Framework.TearDownAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using ClassCleanup = NUnit.Framework.TestFixtureTearDownAttribute;
using ClassInitialize = NUnit.Framework.TestFixtureSetUpAttribute;

using NUnitAssert = NUnit.Framework.Assert;
using GDPAssessment.Rules;
using System.Collections.Generic;
using System.Configuration;
using NUnit.Framework;
using System.IO;

namespace GDPAssessmentTest.Rules
{
	[TestClass]
	public class RuleHelperTest
	{
		[TestMethod]
		public void GetRulesForCustomer_EmptyRule_ReturnsBasicRule()
		{
			// Arrange
			var customerRule = new List<CustomerRule> { };
			// Act
			var result = RuleHelper.GetRulesForCustomer("", customerRule);
			// Assert
			Assert.AreEqual(1, result.Count);
		}

		[TestMethod]
		public void GetRulesForCustomer_RuleforSpecificCustomer_ReturnsSpecialRule()
		{
			// Arrange
			var customerRule = new List<CustomerRule> {
				new CustomerRule { CustomerName = "UNILEVER", Rule = new Rule { ProductName = "Classic Ads" } },
				new CustomerRule { CustomerName = "APPLE", Rule = new Rule { ProductName = "Standout Ads" } },
				new CustomerRule { CustomerName = "NIKE", Rule = new Rule { ProductName = "Premium Ads" } },
			};
			// Act
			var result = RuleHelper.GetRulesForCustomer("UNILEVER", customerRule);
			// Assert
			Assert.AreEqual(2, result.Count);
		}
	}
}
