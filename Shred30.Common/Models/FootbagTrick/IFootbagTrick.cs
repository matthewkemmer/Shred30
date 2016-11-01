using Shred30.Common.Models.FootbagTrick.Delays;
using System.Collections.Generic;

namespace Shred30.Common.Models.FootbagTrick
{
	/// <summary>The footbag trick contract.</summary>
	public interface IFootbagTrick
	{
		#region Properties
		/// <summary>Gets or sets the trick ID.</summary>
		string TrickId { get; set; }

		/// <summary>Gets or sets the name.</summary>
		IEnumerable<string> Names { get; set; }

		/// <summary>Gets or sets the adds.</summary>
		int Adds { get; set; }

		/// <summary>Gets or sets a value indicating whether this instance is a double down.</summary>
		bool IsDoubleDown { get; }

		/// <summary>Gets or sets a value indicating whether [use x dex].</summary>
		bool UseXDex { get; set; }

		/// <summary>Gets or sets a value indicating whether this instance has same side variant.</summary>
		bool HasSameSideVariant { get; set; }

		/// <summary>Gets or sets the start delay.</summary>
		IStartDelay StartDelay { get; set; }

		/// <summary>Gets or sets the end delay.</summary>
		IEndDelay EndDelay { get; set; }
		#endregion
	}
}