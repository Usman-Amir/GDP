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
				if (SelectedRule.is_valid)
				{
					ListOfCustomerRule.Add(
					new CustomerRule()
					{
						CustomerName = SelectedRule.customer_name,
						Rule = RuleMaker.MakeRule(
							ruleTup.product_name,
							ruleTup.rule_type,
							ruleTup.rule_parameters)
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
