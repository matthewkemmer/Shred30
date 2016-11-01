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
	public class FootbagTrickArrangerTests
	{
		private FootbagTrickArranger FootbagTrickArranger = new FootbagTrickArranger(new MockFootbagTrickService());

		[TestMethod]
		public void CanGetMetadataForOneTrick()
		{
			List<IShred30Contact> shred30Contacts = new List<IShred30Contact>()
			{
				new Shred30Trick(OrdinalSideType.Left, "dimwalk")
			};

			shred30Contacts = this.FootbagTrickArranger.ArrangeContacts(shred30Contacts).ToList();

			Assert.AreEqual(4, shred30Contacts[0].Adds);
			Assert.AreEqual(OrdinalSideType.Right, shred30Contacts[0].GetEndSide());
		}

		[TestMethod]
		public void CanGetMetadataForMultipleTricks()
		{
			List<IShred30Contact> shred30Contacts = new List<IShred30Contact>()
			{
				new Shred30Trick(OrdinalSideType.Left, "dimwalk"),
				new Shred30Trick(OrdinalSideType.Right, "blurry whirl")
			};

			shred30Contacts = this.FootbagTrickArranger.ArrangeContacts(shred30Contacts).ToList();

			Assert.AreEqual(4, shred30Contacts[0].Adds);
			Assert.AreEqual(OrdinalSideType.Right, shred30Contacts[0].GetEndSide());
			Assert.AreEqual(5, shred30Contacts[1].Adds);
			Assert.AreEqual(OrdinalSideType.Left, shred30Contacts[1].GetEndSide());
		}

		[TestMethod]
		public void CanGetMetadataForMultipleTricksWithDrop()
		{
			List<IShred30Contact> shred30Contacts = new List<IShred30Contact>()
			{
				new Drop(),
				new Shred30Trick(OrdinalSideType.Right, "blurry whirl")
			};

			shred30Contacts = this.FootbagTrickArranger.ArrangeContacts(shred30Contacts).ToList();

			Assert.IsTrue(shred30Contacts[0].IsDrop);
			Assert.AreEqual(5, shred30Contacts[1].Adds);
			Assert.AreEqual(OrdinalSideType.Left, shred30Contacts[1].GetEndSide());
		}
	}
}