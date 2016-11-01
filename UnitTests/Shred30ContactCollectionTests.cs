using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shred30.Common.Collections;
using Shred30.Common.Enums;
using Shred30.Common.Models.Contacts;
using Shred30.UnitTests.Mocks;
using System.Collections.Generic;
using System.Linq;

namespace Shred30.UnitTests
{
	[TestClass]
	public class Shred30ContactCollectionTests
	{
		private Shred30ContactCollection Collection;

		[TestMethod]
		public void CanAddToCollection()
		{
			this.Collection = new Shred30ContactCollection();

			this.Collection.Add(new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk));

			Assert.AreEqual(MockFootbagTricks.Ripwalk.TrickId, this.Collection[0].FootbagTrick.TrickId);
		}

		[TestMethod]
		public void CanGetCollectionFromList()
		{
			List<IShred30Contact> contacts = new List<IShred30Contact>
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Blur)
			};

			this.Collection = new Shred30ContactCollection(contacts);

			Assert.AreEqual(MockFootbagTricks.Ripwalk.TrickId, this.Collection[0].FootbagTrick.TrickId);
			Assert.AreEqual(MockFootbagTricks.Blur.TrickId, this.Collection[1].FootbagTrick.TrickId);
		}

		[TestMethod]
		public void CanGetPairsFromCollection()
		{
			List<IShred30Contact> contacts = new List<IShred30Contact>
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Blur),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Dimwalk)
			};

			this.Collection = new Shred30ContactCollection(contacts);

			List<Shred30ContactPair> pairs = this.Collection.GetPairCollection().ToList();

			Assert.AreEqual(2, pairs.Count());
			Assert.AreEqual(MockFootbagTricks.Ripwalk.TrickId, pairs[0].FirstContact.FootbagTrick.TrickId);
			Assert.AreEqual(MockFootbagTricks.Blur.TrickId, pairs[0].SecondContact.FootbagTrick.TrickId);
			Assert.AreEqual(MockFootbagTricks.Blur.TrickId, pairs[1].FirstContact.FootbagTrick.TrickId);
			Assert.AreEqual(MockFootbagTricks.Dimwalk.TrickId, pairs[1].SecondContact.FootbagTrick.TrickId);
		}

		public void CanGetNoPairsFromOneTrickCollection()
		{
			List<IShred30Contact> contacts = new List<IShred30Contact>
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
			};

			this.Collection = new Shred30ContactCollection(contacts);

			List<Shred30ContactPair> pairsFromOneTrick = this.Collection.GetPairCollection().ToList();

			Assert.IsTrue(!pairsFromOneTrick.Any());
		}

		public void CanGetNoPairsFromZeroTrickCollection()
		{
			this.Collection = new Shred30ContactCollection();

			List<Shred30ContactPair> pairsFromOneTrick = this.Collection.GetPairCollection().ToList();

			Assert.IsTrue(!pairsFromOneTrick.Any());
		}
	}
}