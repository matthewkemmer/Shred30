using Shred30.Common.Models.Contacts;
using System.Collections.Generic;
using System.Linq;

namespace Shred30.Service.Calculation.AddCalculators
{
	/// <summary>Concrete ADD calculator that sums the raw ADD values of shred 30 contacts.</summary>
	/// <seealso cref="Shred30.Service.Calculation.IAddCalculator" />
	public class StandardAddCalculator : IAddCalculator
	{
		#region Methods
		/// <summary>Gets the total ADDs.</summary>
		/// <param name="shred30Contacts">The shred30 contacts.</param>
		public int GetTotalAdds(IEnumerable<IShred30Contact> shred30Contacts)
		{
			return shred30Contacts.Sum(shred30Contact => this.GetAdds(shred30Contact));
		}

		/// <summary>Gets the adds for a single contact.</summary>
		/// <param name="shred30Contact">The shred30 contact.</param>
		public int GetAdds(IShred30Contact shred30Contact)
		{
			return shred30Contact.Adds;
		}
		#endregion
	}
}