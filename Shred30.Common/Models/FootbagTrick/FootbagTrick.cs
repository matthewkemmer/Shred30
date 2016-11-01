using Shred30.Common.Models.FootbagTrick.Delays;
using System.Collections.Generic;

namespace Shred30.Common.Models.FootbagTrick
{
	/// <summary>Model for a Shred30 trick.</summary>
	public class FootbagTrick : IFootbagTrick
	{
		#region Properties
		/// <summary>Gets or sets the trick ID.</summary>
		public string TrickId { get; set; }

		/// <summary>Gets the name of the contact.</summary>
		public IEnumerable<string> Names { get; set; }

		/// <summary>Gets the adds.</summary>
		public int Adds { get; set; }

		/// <summary>Gets or sets a value indicating whether this instance is a double down.</summary>
		public bool IsDoubleDown { get; set; }

		/// <summary>Gets or sets a value indicating whether [use x dex].</summary>
		public bool UseXDex { get; set; }

		/// <summary>Gets or sets a value indicating whether this instance has same side variant.</summary>
		public bool HasSameSideVariant { get; set; }

		/// <summary>Gets the start delay.</summary>
		public IStartDelay StartDelay { get; set; }

		/// <summary>Gets the end delay.</summary>
		public IEndDelay EndDelay { get; set; }
		#endregion

		#region
		/// <summary>Initializes a new instance of the <see cref="FootbagTrick"/> class.</summary>
		public FootbagTrick()
		{
			this.Names = new List<string>();
		}
		#endregion
	}
}