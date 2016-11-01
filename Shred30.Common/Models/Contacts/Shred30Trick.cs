using Shred30.Common.Enums;
using Shred30.Common.Extensions;
using Shred30.Common.Models.FootbagTrick;
using System;

namespace Shred30.Common.Models.Contacts
{
	/// <summary>Model to represent a completed shred 30 trick.</summary>
	/// <seealso cref="Shred30.Models.Contacts.IShred30Contact" />
	public class Shred30Trick : IShred30Contact
	{
		#region Properties
		/// <summary>Gets or sets the trick.</summary>
		public IFootbagTrick FootbagTrick { get; set; }

		/// <summary>Gets the name of the contact.</summary>
		public string Name { get; set; }

		/// <summary>Gets the adds.</summary>
		public int Adds
		{
			get
			{
				return this.FootbagTrick.Adds;
			}
		}

		/// <summary>Gets a value indicating whether this instance can be unique.</summary>
		public bool CanBeUnique { get { return true; } }

		/// <summary>Gets a value indicating whether this instance is a drop.</summary>
		public bool IsDrop { get { return false; } }

		/// <summary>
		///		Gets a value indicating whether this instance is one of the four basic double down tricks:
		///			Barfly
		///			Down Double Down
		///			Paradon
		///			Down Over Down
		///	</summary>
		///	<remarks>Basic double down tricks on the same side are not considered unique in a shred 30.</remarks>
		public bool IsDoubleDown
		{
			get
			{
				return this.FootbagTrick.IsDoubleDown;
			}
		}

		/// <summary>Gets or sets a value indicating whether [use x dex].</summary>
		public bool UseXDex
		{
			get
			{
				return this.FootbagTrick.UseXDex;
			}
		}

		/// <summary>Gets or sets a value indicating whether this instance is same side variate.</summary>
		public bool IsSameSideVariant { get; set; }

		/// <summary>Gets the contact's position in the shred 30 string.</summary>
		public Guid UniqueId { get; set; }

		/// <summary>Gets or sets the type of the ordinal side.</summary>
		public OrdinalSideType StartSide { get; set; }
		#endregion

		#region Constructors
		/// <summary>Initializes a new instance of the <see cref="Shred30Trick" /> class.</summary>
		/// <param name="startSide">The start side.</param>
		/// <param name="footbagTrick">The footbag trick.</param>
		/// <param name="sameSideVariant">if set to <c>true</c> [same side variant].</param>
		public Shred30Trick(OrdinalSideType startSide, IFootbagTrick footbagTrick, bool sameSideVariant = false)
		{
			this.StartSide = startSide;
			this.FootbagTrick = footbagTrick;
			this.IsSameSideVariant = sameSideVariant;
			this.UniqueId = Guid.NewGuid();
		}

		/// <summary>Initializes a new instance of the <see cref="Shred30Trick" /> class.</summary>
		/// <param name="startSide">The start side.</param>
		/// <param name="name">The name.</param>
		/// <param name="sameSideVariant">if set to <c>true</c> [same side variant].</param>
		public Shred30Trick(OrdinalSideType startSide, string name, bool sameSideVariant = false)
		{
			this.StartSide = startSide;
			this.Name = name;
			this.IsSameSideVariant = sameSideVariant;
			this.UniqueId = Guid.NewGuid();
		}
		#endregion

		#region Methods
		/// <summary>Gets the ordinal side based on relative end.</summary>
		public OrdinalSideType GetEndSide()
		{
			RelativeSideType relativeEndingSide = this.FootbagTrick.EndDelay.RelativeSide;

			OrdinalSideType naturalEndingSide;
			if(relativeEndingSide == RelativeSideType.Opposite)
			{
				naturalEndingSide = this.StartSide.GetOpposite();
			}
			else
			{
				naturalEndingSide = this.StartSide;
			}

			if(this.IsSameSideVariant)
			{
				return naturalEndingSide.GetOpposite();
			}
			else
			{
				return naturalEndingSide;
			}
		}
		#endregion
	}
}