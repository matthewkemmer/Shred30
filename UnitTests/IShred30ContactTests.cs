using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shred30.Common.Enums;
using Shred30.Common.Models.Contacts;
using Shred30.Common.Models.FootbagTrick;
using Shred30.UnitTests.Mocks;

namespace Shred30.UnitTests
{
	[TestClass]
	public class IShred30ContactTests
	{
		[TestMethod]
		public void CanContactBeUnique()
		{
			IShred30Contact shred30Trick = new Shred30Trick(OrdinalSideType.None, new FootbagTrick());
			IShred30Contact drop = new Drop();

			Assert.IsTrue(shred30Trick.CanBeUnique);
			Assert.IsFalse(drop.CanBeUnique);
		}

		[TestMethod]
		public void CanGetOrdinalSideBasedOnRelativeEnd()
		{
			IShred30Contact ripwalk = new Shred30Trick(
				OrdinalSideType.Left,
				MockFootbagTricks.Ripwalk);
			IShred30Contact blur = new Shred30Trick(
				OrdinalSideType.Left,
				MockFootbagTricks.Blur);

			Assert.AreEqual(ripwalk.GetEndSide(), OrdinalSideType.Right);
			Assert.AreEqual(blur.GetEndSide(), OrdinalSideType.Left);
		}

		[TestMethod]
		public void CanGetAddsOfDrop()
		{
			IShred30Contact drop = new Drop();

			Assert.AreEqual(0, drop.Adds);
		}

		[TestMethod]
		public void CanGetAddsOfTrick()
		{
			IShred30Contact trick = new Shred30Trick(
				OrdinalSideType.None
,
				MockFootbagTricks.BlurryWhirl);

			Assert.AreEqual(5, trick.Adds);
		}

		[TestMethod]
		public void CanGetIsDrop()
		{
			IShred30Contact trick = new Shred30Trick(OrdinalSideType.None, MockFootbagTricks.Blur);
			IShred30Contact drop = new Drop();

			Assert.IsFalse(trick.IsDrop);
			Assert.IsTrue(drop.IsDrop);
		}

		[TestMethod]
		public void CanGetCorrectSideFromSameSideVariant()
		{
			IShred30Contact trick = new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.Mirage);
			trick.IsSameSideVariant = true;

			Assert.AreEqual(OrdinalSideType.Left, trick.GetEndSide());
		}
	}
}