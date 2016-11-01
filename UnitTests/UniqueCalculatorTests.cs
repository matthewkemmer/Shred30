using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shred30.Common.Comparers;
using Shred30.Common.Enums;
using Shred30.Common.Models.Contacts;
using Shred30.Service.Calculation.UniqueCalculators;
using Shred30.UnitTests.Mocks;
using System.Collections.Generic;
using System.Linq;

namespace Shred30.UnitTests
{
	[TestClass]
	public class UniqueCalculatorTests
	{
		private IUniqueCalculator UniqueCalculator;

		[TestMethod]
		public void CanGetUniqueNumberOfContacts_AllUnique()
		{
			List<IShred30Contact> contacts = new List<IShred30Contact>()
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Blur),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Dimwalk),
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.BlurryWhirl)
			};

			this.UniqueCalculator = new OpenAddsBasedUniqueCalculator();

			Assert.AreEqual(4, this.UniqueCalculator.GetNumberOfUniqueContacts(contacts));
		}

		[TestMethod]
		public void CanGetUniqueNumberOfContacts_NotAllUnique()
		{
			List<IShred30Contact> contacts = new List<IShred30Contact>()
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Blur),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Dimwalk),
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk)
			};

			this.UniqueCalculator = new OpenAddsBasedUniqueCalculator();

			Assert.AreEqual(3, this.UniqueCalculator.GetNumberOfUniqueContacts(contacts));
		}

		[TestMethod]
		public void CanGetUniqueContacts()
		{
			List<IShred30Contact> contacts = new List<IShred30Contact>()
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Blur),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Dimwalk),
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk)
			};

			this.UniqueCalculator = new OpenAddsBasedUniqueCalculator();

			IEnumerable<IShred30Contact> actualUniqueContacts = this.UniqueCalculator.GetUniqueContacts(contacts);

			List<IShred30Contact> expectedUniqueContacts = new List<IShred30Contact>
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Blur),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Dimwalk)
			};

			Assert.IsTrue(actualUniqueContacts.SequenceEqual(expectedUniqueContacts, new Shred30ContactComparer()));
		}

		[TestMethod]
		public void CanGetUniqueContactsWithDoubleDowns_NonUnique()
		{
			List<IShred30Contact> contacts = new List<IShred30Contact>()
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Barfly),
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Blur),
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.DownOverDown)
			};

			this.UniqueCalculator = new OpenAddsBasedUniqueCalculator();

			IEnumerable<IShred30Contact> actualUniqueContacts = this.UniqueCalculator.GetUniqueContacts(contacts);

			List<IShred30Contact> expectedUniqueContacts = new List<IShred30Contact>
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Barfly),
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Blur)
			};

			Assert.IsTrue(actualUniqueContacts.SequenceEqual(expectedUniqueContacts, new Shred30ContactComparer()));
		}

		[TestMethod]
		public void CanGetUniqueContactsWithDoubleDowns_Unique()
		{
			List<IShred30Contact> contacts = new List<IShred30Contact>()
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Barfly),
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Blur),
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Paradon)
			};

			this.UniqueCalculator = new OpenAddsBasedUniqueCalculator();

			IEnumerable<IShred30Contact> actualUniqueContacts = this.UniqueCalculator.GetUniqueContacts(contacts);

			List<IShred30Contact> expectedUniqueContacts = new List<IShred30Contact>
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Barfly),
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Blur),
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Paradon)
			};

			Assert.IsTrue(actualUniqueContacts.SequenceEqual(expectedUniqueContacts, new Shred30ContactComparer()));
		}

		[TestMethod]
		public void CanGetUniqueContacts_OpenLevelAdds()
		{
			List<IShred30Contact> contacts = new List<IShred30Contact>()
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Barfly),
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Blur),
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Mirage)
			};

			this.UniqueCalculator = new OpenAddsBasedUniqueCalculator();

			IEnumerable<IShred30Contact> actualUniqueContacts = this.UniqueCalculator.GetUniqueContacts(contacts);

			List<IShred30Contact> expectedUniqueContacts = new List<IShred30Contact>
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Barfly),
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Blur)
			};

			Assert.IsTrue(actualUniqueContacts.SequenceEqual(expectedUniqueContacts, new Shred30ContactComparer()));
		}

		[TestMethod]
		public void CanGetUniqueContacts_IntermediateLevelAdds()
		{
			List<IShred30Contact> contacts = new List<IShred30Contact>()
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Barfly),
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Blur),
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Mirage)
			};

			this.UniqueCalculator = new IntermediateAddsBasedUniqueCalculator();

			IEnumerable<IShred30Contact> actualUniqueContacts = this.UniqueCalculator.GetUniqueContacts(contacts);

			List<IShred30Contact> expectedUniqueContacts = new List<IShred30Contact>
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Barfly),
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Blur),
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Mirage)
			};

			Assert.IsTrue(actualUniqueContacts.SequenceEqual(expectedUniqueContacts, new Shred30ContactComparer()));
		}
	}
}