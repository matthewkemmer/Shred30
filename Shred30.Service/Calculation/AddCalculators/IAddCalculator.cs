using Shred30.Common.Models.Contacts;
using System.Collections.Generic;

namespace Shred30.Service.Calculation.AddCalculators
{
	/// <summary>The ADD calculator contract.</summary>
	public interface IAddCalculator
	{
		#region Methods
		/// <summary>Gets the total ADDs.</summary>
		/// <param name="shred30Contacts">The shred30 contacts.</param>
		int GetTotalAdds(IEnumerable<IShred30Contact> shred30Contacts);

		/// <summary>Gets the adds for a single contact.</summary>
		/// <param name="shred30Contact">The shred30 contact.</param>
		int GetAdds(IShred30Contact shred30Contact);
		#endregion
	}
}