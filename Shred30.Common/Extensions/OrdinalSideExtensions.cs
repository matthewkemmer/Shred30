using Shred30.Common.Enums;

namespace Shred30.Common.Extensions
{
	/// <summary>Extension methods for the OrdinalSideType enum.</summary>
	public static class OrdinalSideExtensions
	{
		/// <summary>Gets the opposite ordinal side.</summary>
		/// <param name="ordinalSide">The ordinal side.</param>
		public static OrdinalSideType GetOpposite(this OrdinalSideType ordinalSide)
		{
			switch(ordinalSide)
			{
				case OrdinalSideType.Left:
					return OrdinalSideType.Right;
				case OrdinalSideType.Right:
					return OrdinalSideType.Left;
				default:
					return OrdinalSideType.None;
			}
		}
	}
}