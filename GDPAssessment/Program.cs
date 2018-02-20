using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDPAssessment.Products;
using GDPAssessment.Rules;
using GDPAssessment.Cart;
using System.Configuration;
using System.IO;

namespace GDPAssessment
{
	class Program
	{
		static void Main(string[] args)
		{
			List<CustomerRule> fileRules = GetRulesofAllCustomer();
			if (fileRules.Count > 0)
			{
				// Perform checkout
				CheckoutDefault(fileRules);
				CheckoutUnilever(fileRules);
				CheckoutApple(fileRules);
				CheckoutNike(fileRules);
				Console.WriteLine("Press enter key to exit.");
				Console.Read();

			}
		}
		private static List<CustomerRule> GetRulesofAllCustomer()
		{
			// Read the rules
			return RuleHelper.ReadRules(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", @"assets\pricing_rules.json"));
		}

		private static void CheckoutDefault(List<CustomerRule> fileRules)
		{
			Console.WriteLine("Total of Cart is : " + AdsCheckout.PerformCheckout(
							new List<Product>
							{
					new ClassicAd(),
					new StandoutAd(),
					new PremiumAd()
							},
							RuleHelper.GetRulesForCustomer("default", fileRules)
						));
		}
		private static void CheckoutUnilever(List<CustomerRule> fileRules)
		{
			Console.WriteLine("Total of cart is : " + AdsCheckout.PerformCheckout(
							new List<Product>
							{
					new ClassicAd(),
					new ClassicAd(),
					new ClassicAd(),
					new PremiumAd()
							},
							RuleHelper.GetRulesForCustomer("unilever", fileRules)
						));
		}
		private static void CheckoutApple(List<CustomerRule> fileRules)
		{
			Console.WriteLine("Total of cart is : " + AdsCheckout.PerformCheckout(
				new List<Product>
				{
					new StandoutAd(),
					new StandoutAd(),
					new StandoutAd(),
					new PremiumAd()
				},
				RuleHelper.GetRulesForCustomer("apple", fileRules)
			));
		}
		private static void CheckoutNike(List<CustomerRule> fileRules)
		{
			Console.WriteLine("Total of cart is : " + AdsCheckout.PerformCheckout(
							new List<Product>
							{
					new PremiumAd(),
					new PremiumAd(),
					new PremiumAd(),
					new PremiumAd()
							},
							RuleHelper.GetRulesForCustomer("nike", fileRules)
						));
		}
	}
}

