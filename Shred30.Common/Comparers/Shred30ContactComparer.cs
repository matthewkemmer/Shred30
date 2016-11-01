using Shred30.Common.Enums;
using Shred30.Common.Models.Contacts;
using System.Collections.Generic;

namespace Shred30.Common.Comparers
{
	/// <summary>Comparer for an IContact.</summary>
	/// <seealso cref="System.Collections.Generic.IEqualityComparer{Shred30Calculator.IShred30Contact}" />
	public class Shred30ContactComparer : IEqualityComparer<IShred30Contact>
	{
		#region Methods
		/// <summary>Determines whether the specified objects are equal.</summary>
		/// <param name="x">The first object of type <paramref name="T" /> to compare.</param>
		/// <param name="y">The second object of type <paramref name="T" /> to compare.</param>
		public bool Equals(IShred30Contact x, IShred30Contact y)
		{
			if(x.IsDrop && y.IsDrop)
			{
				return true;
			}

			if(x.StartSide == OrdinalSideType.None || y.StartSide == OrdinalSideType.None)
			{
				return false;
			}

			bool bothTricksAreDoubleDowns = x.IsDoubleDown && y.IsDoubleDown;
			if(bothTricksAreDoubleDowns)
			{
				// double downs are not unique if they end on the same side
				return x.GetEndSide() == y.GetEndSide();
			}

			if(x.FootbagTrick.TrickId != y.FootbagTrick.TrickId)
			{
				return false;
			}

			return x.GetEndSide() == y.GetEndSide();
		}

		/// <summary>Returns a hash code for this instance.</summary>
		/// <param name="obj">The object.</param>
		public int GetHashCode(IShred30Contact obj)
		{
			return obj.GetHashCode();
		}
		#endregion
	}
}