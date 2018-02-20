using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;

namespace GDPAssessment.Rules
{
	public class RuleHelper
	{
		public static List<Rule> GetRulesForCustomer(String customerName, IEnumerable<CustomerRule> allCustomerRules)
		{
			List<Rule> custRules = allCustomerRules
			.Where(x => x.CustomerName.Equals(customerName))
			.Select(o => o.Rule).ToList();

			custRules.Add(new Rule());
			return custRules;
		}

		public static List<CustomerRule> ReadRules(String filename)
		{
			dynamic ListOfAllRules = GetRulesTupples(filename);

			List<CustomerRule> ListOfCustomerRule = new List<CustomerRule>();

			foreach (var SelectedRule in ListOfAllRules)
			{
				var ruleTup = SelectedRule.rule;
				if (SelectedRule.isvalid)
				{
					ListOfCustomerRule.Add(
					new CustomerRule()
					{
						CustomerName = SelectedRule.customername,
						Rule = RuleMaker.MakeRule(
							ruleTup.productname,
							ruleTup.ruletype,
							ruleTup.ruleparameters)
					});
				}
			}
			return ListOfCustomerRule;
		}

		private static dynamic GetRulesTupples(string filename)
		{
			return JsonConvert.DeserializeObject<List<ExpandoObject>>(
				new StreamReader(filename).ReadToEnd(),
				new ExpandoObjectConverter());
		}
	}
}
