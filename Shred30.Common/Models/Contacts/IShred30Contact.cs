using Shred30.Common.Enums;
using Shred30.Common.Models.FootbagTrick;
using System;

namespace Shred30.Common.Models.Contacts
{
	/// <summary>Contract for a Shred30 contact.</summary>
	public interface IShred30Contact
	{
		#region Properties
		/// <summary>Gets the name of the contact.</summary>
		string Name { get; }

		/// <summary>Gets the adds.</summary>
		int Adds { get; }

		/// <summary>Gets a value indicating whether this instance can be unique.</summary>
		bool CanBeUnique { get; }

		/// <summary>Gets a value indicating whether this instance is a drop.</summary>
		bool IsDrop { get; }

		/// <summary>
		///		Gets a value indicating whether this instance is one of the four basic double down tricks:
		///			Barfly
		///			Down Double Down
		///			Paradon
		///			Down Over Down
		///	</summary>
		///	<remarks>Basic double down tricks on the same side are not considered unique in a shred 30.</remarks>
		bool IsDoubleDown { get; }

		/// <summary>Gets or sets a value indicating whether [use x dex].</summary>
		bool UseXDex { get; }

		/// <summary>Gets or sets a value indicating whether this instance is same side variant.</summary>
		bool IsSameSideVariant { get; set; }

		/// <summary>Gets the contact's position in the shred 30 string.</summary>
		Guid UniqueId { get; }

		/// <summary>Gets or sets the ordinal side that the contact starts on.</summary>
		OrdinalSideType StartSide { get; set; }

		/// <summary>Gets or sets the footbag trick.</summary>
		IFootbagTrick FootbagTrick { get; set; }
		#endregion

		#region Methods
		/// <summary>Gets the ordinal side based on relative end.</summary>
		OrdinalSideType GetEndSide();
		#endregion
	}
}