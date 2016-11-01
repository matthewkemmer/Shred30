using Shred30.Common.Enums;
using Shred30.Common.Models.FootbagTrick;
using System;

namespace Shred30.Common.Models.Contacts
{
	/// <summary>Model for a Shred30 drop.</summary>
	/// <seealso cref="Shred30Calculator.IShred30Contact" />
	/// <remarks>A drop in Shred30 is scored as a non-unique 0 ADD trick.</remarks>
	public class Drop : IShred30Contact
	{
		#region Properties
		/// <summary>Gets the name of the contact.</summary>
		public string Name { get { return "Drop"; } }

		/// <summary>Gets the adds.</summary>
		public int Adds { get { return 0; } }

		/// <summary>Gets a value indicating whether this instance can be unique.</summary>
		public bool CanBeUnique
		{
			get
			{
				return false;
			}
		}

		/// <summary>Gets a value indicating whether this instance is a drop.</summary>
		public bool IsDrop { get { return true; } }

		/// <summary>
		///		Gets a value indicating whether this instance is one of the four basic double down tricks:
		///			Barfly
		///			Down Double Down
		///			Paradon
		///			Down Over Down
		///	</summary>
		///	<remarks>Basic double down tricks on the same side are not considered unique in a shred 30.</remarks>
		public bool IsDoubleDown { get { return false; } }

		/// <summary>Gets or sets a value indicating whether [use x dex].</summary>
		public bool UseXDex { get { return false; } }

		/// <summary>Gets or sets a value indicating whether this instance is same side variate.</summary>
		public bool IsSameSideVariant { get { return false; } set { } }

		/// <summary>Gets the contact's position in the shred 30 string.</summary>
		public Guid UniqueId { get; }

		/// <summary>Gets the type of the ordinal side.</summary>
		public OrdinalSideType StartSide { get { return OrdinalSideType.None; } set { } }

		/// <summary>Gets or sets the footbag trick.</summary>
		public IFootbagTrick FootbagTrick { get { return null; } set { } }
		#endregion

		#region Constructor
		/// <summary>Initializes a new instance of the <see cref="Drop"/> class.</summary>
		public Drop()
		{
			this.UniqueId = Guid.NewGuid();
		}
		#endregion

		#region Methods
		/// <summary>Gets the ordinal side based on relative end.</summary>
		public OrdinalSideType GetEndSide()
		{
			return OrdinalSideType.None;
		}
		#endregion
	}
}