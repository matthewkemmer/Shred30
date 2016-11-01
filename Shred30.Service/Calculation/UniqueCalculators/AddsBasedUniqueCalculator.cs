using Shred30.Common.Models.Contacts;
using System.Collections.Generic;
using System.Linq;

namespace Shred30.Service.Calculation.UniqueCalculators
{
	/// <summary>Abstract ADDs-based unique calculator.</summary>
	/// <seealso cref="Shred30.Service.Calculation.UniqueCalculators.BaseUniqueCalculator" />
	/// <remarks>Contacts are only unique if they are greater than an ADD threshold.</remarks>
	public abstract class AddsBasedUniqueCalculator : BaseUniqueCalculator
	{
		/// <summary>Gets the minimum adds that a unique contact must have.</summary>
		protected abstract int MinimumAddsForUniqueContact { get; }

		/// <summary>Gets the finalized unique contacts, after the basic uniqueness rules have already been applied.</summary>
		/// <param name="basicUniqueShred30Contacts">The basic unique shred30 contacts.</param>
		protected override IEnumerable<IShred30Contact> GetFinalizedUniqueContacts(IEnumerable<IShred30Contact> basicUniqueShred30Contacts)
		{
			return basicUniqueShred30Contacts
				.Where(shred30Contact => shred30Contact.Adds >= this.MinimumAddsForUniqueContact);
		}
	}
}