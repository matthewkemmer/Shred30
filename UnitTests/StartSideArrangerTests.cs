using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shred30.Common.Enums;
using Shred30.Common.Models.Contacts;
using Shred30.Service.Arranging;
using Shred30.UnitTests.Mocks;
using System.Collections.Generic;
using System.Linq;

namespace Shred30.UnitTests
{
	[TestClass]
	public class Shred30StartSideArrangerTests
	{
		private IShred30ContactArranger ContactArranger;

		[TestMethod]
		public void CanSetSidesWithMultipleTricks()
		{
			List<IShred30Contact> contacts = new List<IShred30Contact>()
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.None, MockFootbagTricks.Blur),
				new Shred30Trick(OrdinalSideType.None, MockFootbagTricks.Dimwalk)
			};

			this.ContactArranger = new StartSideArranger();

			List<IShred30Contact> shred30Contacts = this.ContactArranger.ArrangeContacts(contacts).ToList();

			Assert.AreEqual(OrdinalSideType.Left, shred30Contacts[0].StartSide);
			Assert.AreEqual(OrdinalSideType.Right, shred30Contacts[1].StartSide);
			Assert.AreEqual(OrdinalSideType.Right, shred30Contacts[2].StartSide);
		}

		[TestMethod]
		public void CanSetSidesWithDrop()
		{
			List<IShred30Contact> contacts = new List<IShred30Contact>()
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.None, MockFootbagTricks.Blur),
				new Drop(),
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Dimwalk),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.BlurryWhirl)
			};

			this.ContactArranger = new StartSideArranger();

			List<IShred30Contact> shred30Contacts = this.ContactArranger.ArrangeContacts(contacts).ToList();

			Assert.AreEqual(OrdinalSideType.Left, shred30Contacts[0].StartSide);
			Assert.AreEqual(OrdinalSideType.Right, shred30Contacts[1].StartSide);
			Assert.AreEqual(OrdinalSideType.None, shred30Contacts[2].StartSide);
			Assert.AreEqual(OrdinalSideType.Left, shred30Contacts[3].StartSide);
			Assert.AreEqual(OrdinalSideType.Right, shred30Contacts[4].StartSide);
		}
	}
}