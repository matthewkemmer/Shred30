using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shred30.Common.Enums;
using Shred30.Common.Exceptions;
using Shred30.Common.Models.Contacts;
using Shred30.Service.Arranging;
using Shred30.Service.Calculation.AddCalculators;
using Shred30.Service.Calculation.ScoreCalculators;
using Shred30.Service.Calculation.UniqueCalculators;
using Shred30.Service.Validation;
using Shred30.UnitTests.Mocks;
using System.Collections.Generic;

namespace Shred30.UnitTests
{
	[TestClass]
	public class ScoreCalculatorTests
	{
		private StandardShred30ScoreCalculator ScoreCalculator;

		private StandardShred30ScoreCalculator GetScoreCalculator(IEnumerable<IShred30Contact> shred30Contacts, bool useXDex = true, IShred30ContactArranger contactArranger = null, IShredContact30Validator validator = null, IUniqueCalculator uniqueCalculator = null)
		{
			IAddCalculator addCalculator;
			if(useXDex)
			{
				addCalculator = new StandardAddCalculator();
			}
			else
			{
				addCalculator = new NoXDexAddCalculator();
			}

			return new StandardShred30ScoreCalculator(
				shred30Contacts,
				contactArranger == null ? new List<IShred30ContactArranger>() : new List<IShred30ContactArranger> { contactArranger },
				validator == null ? new List<IShredContact30Validator>() : new List<IShredContact30Validator> { validator },
				addCalculator,
				uniqueCalculator == null ? new OpenAddsBasedUniqueCalculator() : uniqueCalculator
			);
		}

		[TestMethod]
		public void CanGetTotalAdds()
		{
			List<IShred30Contact> contacts = new List<IShred30Contact>()
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Blur)
			};

			this.ScoreCalculator = this.GetScoreCalculator(contacts);

			Assert.AreEqual(8, this.ScoreCalculator.TotalAdds);
		}

		[TestMethod]
		public void CanGetTotalAdds_WithDrop()
		{
			List<IShred30Contact> contacts = new List<IShred30Contact>()
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Blur),
				new Drop()
			};

			this.ScoreCalculator = this.GetScoreCalculator(contacts);

			Assert.AreEqual(8, this.ScoreCalculator.TotalAdds);
		}

		[TestMethod]
		public void CanGetTotalContacts()
		{
			List<IShred30Contact> contacts = new List<IShred30Contact>()
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Blur)
			};

			this.ScoreCalculator = this.GetScoreCalculator(contacts);

			Assert.AreEqual(2, this.ScoreCalculator.TotalContacts);
		}

		[TestMethod]
		public void CanGetTotalUniques_AllUnique()
		{
			List<IShred30Contact> contacts = new List<IShred30Contact>()
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Blur)
			};

			this.ScoreCalculator = this.GetScoreCalculator(contacts);

			Assert.AreEqual(2, this.ScoreCalculator.TotalUniques);
		}

		[TestMethod]
		public void CanGetTotalUniques_SomeUnique()
		{
			List<IShred30Contact> contacts = new List<IShred30Contact>()
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Blur),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Dimwalk),
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk)
			};

			this.ScoreCalculator = this.GetScoreCalculator(contacts);

			Assert.AreEqual(3, this.ScoreCalculator.TotalUniques);
		}

		[TestMethod]
		public void CanGetTotalUniques_Withdrop()
		{
			List<IShred30Contact> contacts = new List<IShred30Contact>()
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Drop()
			};

			this.ScoreCalculator = this.GetScoreCalculator(contacts);

			Assert.AreEqual(1, this.ScoreCalculator.TotalUniques);
		}

		[TestMethod]
		public void CanGetScore_AllUnique()
		{
			List<IShred30Contact> contacts = new List<IShred30Contact>()
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Blur),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Dimwalk),
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.BlurryWhirl)
			};

			this.ScoreCalculator = this.GetScoreCalculator(contacts);

			Assert.AreEqual(34, this.ScoreCalculator.CalculateScore());
		}

		[TestMethod]
		public void CanGetScore_SomeUnique()
		{
			List<IShred30Contact> contacts = new List<IShred30Contact>()
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Blur),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Dimwalk),
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk)
			};

			this.ScoreCalculator = this.GetScoreCalculator(contacts);

			Assert.AreEqual(28, this.ScoreCalculator.CalculateScore());
		}

		[TestMethod]
		public void CanGetScore_WithDrop()
		{
			List<IShred30Contact> contacts = new List<IShred30Contact>()
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Blur),
				new Drop(),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Ripwalk)
			};

			this.ScoreCalculator = this.GetScoreCalculator(contacts);

			Assert.AreEqual(21, this.ScoreCalculator.CalculateScore());
		}

		[TestMethod]
		[ExpectedException(typeof(NotAllTricksSpecifySidesException))]
		public void CanNotGetScoreWithoutAllSidesSet()
		{
			List<IShred30Contact> contacts = new List<IShred30Contact>()
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.None, MockFootbagTricks.Blur),
			};

			this.ScoreCalculator = this.GetScoreCalculator(contacts, useXDex: true, validator: new AllTricksSpecifySideValidator());

			this.ScoreCalculator.CalculateScore();
		}

		[TestMethod]
		[ExpectedException(typeof(SurfacesDoNotLineUpException))]
		public void CanNotGetScoreWithoutSurfacesNotLiningUp()
		{
			List<IShred30Contact> contacts = new List<IShred30Contact>()
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Dimwalk),
			};

			this.ScoreCalculator = this.GetScoreCalculator(contacts, useXDex: true, validator: new SurfacesLineUpValidator());

			this.ScoreCalculator.CalculateScore();
		}

		[TestMethod]
		[ExpectedException(typeof(TrickAfterDropDoesNotSpecifySideException))]
		public void CanNotGetScoreWithoutSettingSideAfterDrop()
		{
			List<IShred30Contact> contacts = new List<IShred30Contact>()
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Drop(),
				new Shred30Trick(OrdinalSideType.None, MockFootbagTricks.Blur),
			};

			this.ScoreCalculator = this.GetScoreCalculator(contacts, useXDex: true, validator: new TricksFollowingDropsSpecifySideValidator());

			this.ScoreCalculator.CalculateScore();
		}

		[TestMethod]
		public void CanGetScoreSpecifyingMinimumSides()
		{
			List<IShred30Contact> contacts = new List<IShred30Contact>()
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.None, MockFootbagTricks.Barfly),
				new Shred30Trick(OrdinalSideType.None, MockFootbagTricks.Blur),
				new Shred30Trick(OrdinalSideType.None, MockFootbagTricks.DownOverDown)
			};

			this.ScoreCalculator = this.GetScoreCalculator(contacts, useXDex: true, contactArranger: new StartSideArranger());

			this.ScoreCalculator.CalculateScore();
		}

		[TestMethod]
		public void CanGetTotalAddsWithXDexTrick_UseXDex()
		{
			List<IShred30Contact> contacts = new List<IShred30Contact>()
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.AtomSmasher),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Paradon)
			};

			this.ScoreCalculator = this.GetScoreCalculator(contacts);

			Assert.AreEqual(8, this.ScoreCalculator.TotalAdds);
		}

		[TestMethod]
		public void CanGetTotalAddsWithXDexTrick_DoNotUseXDex()
		{
			List<IShred30Contact> contacts = new List<IShred30Contact>()
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.AtomSmasher),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Paradon)
			};

			this.ScoreCalculator = this.GetScoreCalculator(contacts, useXDex: false);

			Assert.AreEqual(7, this.ScoreCalculator.TotalAdds);
		}

		[TestMethod]
		public void CanGetScoreMultipletimes()
		{
			List<IShred30Contact> contacts = new List<IShred30Contact>()
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Blur),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Dimwalk),
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.BlurryWhirl)
			};

			this.ScoreCalculator = this.GetScoreCalculator(contacts);

			Assert.AreEqual(34, this.ScoreCalculator.CalculateScore());
			Assert.AreEqual(34, this.ScoreCalculator.CalculateScore());
			Assert.AreEqual(34, this.ScoreCalculator.CalculateScore());
		}

		[TestMethod]
		public void CanGetScoreWithLowAddTrick_OpenLevel()
		{
			List<IShred30Contact> contacts = new List<IShred30Contact>()
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Blur),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Mirage),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Dimwalk),
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.BlurryWhirl)
			};

			this.ScoreCalculator = this.GetScoreCalculator(contacts, true, null, null, new OpenAddsBasedUniqueCalculator());

			Assert.AreEqual(34.2, this.ScoreCalculator.CalculateScore());
		}

		[TestMethod]
		public void CanGetScoreWithLowAddTrick_IntermediateLevel()
		{
			List<IShred30Contact> contacts = new List<IShred30Contact>()
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Blur),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Mirage),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Dimwalk),
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.BlurryWhirl)
			};

			this.ScoreCalculator = this.GetScoreCalculator(contacts, true, null, null, new IntermediateAddsBasedUniqueCalculator());

			Assert.AreEqual(38, this.ScoreCalculator.CalculateScore());
		}
	}
}