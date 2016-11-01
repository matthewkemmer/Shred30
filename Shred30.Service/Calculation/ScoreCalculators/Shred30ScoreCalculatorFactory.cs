using Shred30.Common.Models;
using Shred30.Common.Models.Contacts;
using Shred30.Service.Arranging;
using Shred30.Service.Calculation.AddCalculators;
using Shred30.Service.Calculation.UniqueCalculators;
using Shred30.Service.FootbagTrick;
using Shred30.Service.FootbagTrick.Xml;
using Shred30.Service.Validation;
using System.Collections.Generic;

namespace Shred30.Service.Calculation.ScoreCalculators
{
	/// <summary>Factory for getting a shred 30 score calculator.</summary>
	public class Shred30ScoreCalculatorFactory
	{
		/// <summary>Gets the score calculator.</summary>
		/// <param name="shred30Options">The shred30 options.</param>
		/// <param name="shred30Contacts">The shred30 contacts.</param>
		public static IShred30ScoreCalculator GetScoreCalculator(Shred30Options shred30Options, IEnumerable<IShred30Contact> shred30Contacts)
		{
			return new StandardShred30ScoreCalculator(
				shred30Contacts,
				GetContactArrangers(shred30Options),
				GetValidators(),
				GetAddCalculator(shred30Options),
				GetUniqueCalculator(shred30Options)
			);
		}

		/// <summary>Gets the contact arrangers.</summary>
		private static IEnumerable<IShred30ContactArranger> GetContactArrangers(Shred30Options shred30Options)
		{
			IFootbagTrickService footbagTrickService;
			if(shred30Options.FootbagTrickService == "xml")
			{
				footbagTrickService = new XmlFootbagTrickService();
			}
			else
			{
				throw new System.Exception(
					string.Format("Unsupported footbag trick service type: {0}", shred30Options.FootbagTrickService)
				);
			}

			return new List<IShred30ContactArranger>()
			{
				new FootbagTrickArranger(footbagTrickService),
				new StartSideArranger()
			};
		}

		/// <summary>Gets the validators.</summary>
		private static IEnumerable<IShredContact30Validator> GetValidators()
		{
			return new List<IShredContact30Validator>()
			{
				new AllTricksSpecifySideValidator(),
				new SurfacesLineUpValidator(),
				new TricksFollowingDropsSpecifySideValidator(),
				new SameSideVariantValidator()
			};
		}

		/// <summary>Gets the add calculator.</summary>
		/// <param name="shred30Options">The shred30 options.</param>
		private static IAddCalculator GetAddCalculator(Shred30Options shred30Options)
		{
			if(shred30Options.UseXDex)
			{
				return new StandardAddCalculator();
			}
			else
			{
				return new NoXDexAddCalculator();
			}
		}

		/// <summary>Gets the unique calculator.</summary>
		/// <param name="shred30Options">The shred30 options.</param>
		private static IUniqueCalculator GetUniqueCalculator(Shred30Options shred30Options)
		{
			if(shred30Options.IsOpenLevel)
			{
				return new OpenAddsBasedUniqueCalculator();
			}
			else
			{
				return new IntermediateAddsBasedUniqueCalculator();
			}
		}
	}
}