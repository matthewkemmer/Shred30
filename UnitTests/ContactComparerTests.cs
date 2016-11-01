using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shred30.Common.Comparers;
using Shred30.Common.Enums;
using Shred30.Common.Models.Contacts;
using Shred30.UnitTests.Mocks;

namespace Shred30.UnitTests
{
	[TestClass]
	public class ContactComparerTests
	{
		private Shred30ContactComparer Comparer;

		public ContactComparerTests()
		{
			this.Comparer = new Shred30ContactComparer();
		}

		[TestMethod]
		public void CanCompareEqualTricks()
		{
			IShred30Contact first = new Shred30Trick
			(
				OrdinalSideType.Left
,
				MockFootbagTricks.Ripwalk);
			IShred30Contact second = new Shred30Trick
			(
				OrdinalSideType.Left
,
				MockFootbagTricks.Ripwalk);

			Assert.IsTrue(this.Comparer.Equals(first, second));
			Assert.IsTrue(this.Comparer.Equals(second, first));
		}

		[TestMethod]
		public void CanCompareUnequalTricks()
		{
			IShred30Contact first = new Shred30Trick
			(
				OrdinalSideType.Left
,
				MockFootbagTricks.Ripwalk);
			IShred30Contact second = new Shred30Trick
			(
				OrdinalSideType.Left
,
				MockFootbagTricks.Blur);

			Assert.IsFalse(this.Comparer.Equals(first, second));
			Assert.IsFalse(this.Comparer.Equals(second, first));
		}

		[TestMethod]
		public void CanCompareSameTricksWithDifferentSide()
		{
			IShred30Contact first = new Shred30Trick
			(
				OrdinalSideType.Left
,
				MockFootbagTricks.Ripwalk);
			IShred30Contact second = new Shred30Trick
			(
				OrdinalSideType.Right
,
				MockFootbagTricks.Ripwalk);

			Assert.IsFalse(this.Comparer.Equals(first, second));
			Assert.IsFalse(this.Comparer.Equals(second, first));
		}

		[TestMethod]
		public void CanCompareTrickWithDrop()
		{
			IShred30Contact first = new Shred30Trick
			(
				OrdinalSideType.Left
,
				MockFootbagTricks.Ripwalk);
			IShred30Contact second = new Drop();

			Assert.IsFalse(this.Comparer.Equals(first, second));
			Assert.IsFalse(this.Comparer.Equals(second, first));
		}

		[TestMethod]
		public void CanNotCompareTricksWithNoside()
		{
			IShred30Contact first = new Shred30Trick
			(
				OrdinalSideType.None
,
				MockFootbagTricks.Ripwalk);
			IShred30Contact second = new Shred30Trick
			(
				OrdinalSideType.Left
,
				MockFootbagTricks.Ripwalk);

			Assert.IsFalse(this.Comparer.Equals(first, second));
		}

		[TestMethod]
		public void CanCompareDrops()
		{
			IShred30Contact first = new Drop();
			IShred30Contact second = new Drop();

			Assert.IsTrue(this.Comparer.Equals(first, second));
		}

		[TestMethod]
		public void CanCompareDoubleDownsStartingOnSameSide_Equal()
		{
			IShred30Contact first = new Shred30Trick
			(
				OrdinalSideType.Right
,
				MockFootbagTricks.DownDoubleDown);
			IShred30Contact second = new Shred30Trick
			(
				OrdinalSideType.Right
,
				MockFootbagTricks.DownOverDown);

			Assert.IsTrue(this.Comparer.Equals(first, second));
		}

		[TestMethod]
		public void CanCompareDoubleDownsStartingOnOppositeSide_Equal()
		{
			IShred30Contact first = new Shred30Trick
			(
				OrdinalSideType.Right
,
				MockFootbagTricks.Barfly);
			IShred30Contact second = new Shred30Trick
			(
				OrdinalSideType.Left
,
				MockFootbagTricks.DownOverDown);

			Assert.IsTrue(this.Comparer.Equals(first, second));
		}

		[TestMethod]
		public void CanCompareDoubleDownsStartingOnSameSide_UnEqual()
		{
			IShred30Contact first = new Shred30Trick
			(
				OrdinalSideType.Right
,
				MockFootbagTricks.DownDoubleDown);
			IShred30Contact second = new Shred30Trick
			(
				OrdinalSideType.Right
,
				MockFootbagTricks.Barfly);

			Assert.IsFalse(this.Comparer.Equals(first, second));
		}

		[TestMethod]
		public void CanCompareDoubleDownsStartingOnOppositeSide_UnEqual()
		{
			IShred30Contact first = new Shred30Trick
			(
				OrdinalSideType.Right
,
				MockFootbagTricks.DownDoubleDown);
			IShred30Contact second = new Shred30Trick
			(
				OrdinalSideType.Left
,
				MockFootbagTricks.DownOverDown);

			Assert.IsFalse(this.Comparer.Equals(first, second));
		}
	}
}