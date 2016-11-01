using Shred30.Common.Models.Contacts;
using System.Collections.Generic;
using System.Linq;

namespace Shred30.Service.Calculation.AddCalculators
{
	/// <summary>The XDex ADD calculator which does not count the XDex for each shred 30 contact.</summary>
	/// <seealso cref="Shred30.Service.Calculation.IAddCalculator" />
	public class NoXDexAddCalculator : IAddCalculator
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
			if(shred30Contact.UseXDex)
			{
				return shred30Contact.Adds - 1;
			}
			else
			{
				return shred30Contact.Adds;
			}
		}
		#endregion
	}
}