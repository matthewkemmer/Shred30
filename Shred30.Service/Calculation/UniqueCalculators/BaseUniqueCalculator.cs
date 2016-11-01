using Shred30.Common.Collections;
using Shred30.Common.Comparers;
using Shred30.Common.Models.Contacts;
using System.Collections.Generic;
using System.Linq;

namespace Shred30.Service.Calculation.UniqueCalculators
{
	/// <summary>The basic unique calculator, comparing tricks based on the Shred30ContactComparer.</summary>
	/// <seealso cref="Shred30.Service.Calculation.UniqueCalculators.IUniqueCalculator" />
	public abstract class BaseUniqueCalculator : IUniqueCalculator
	{
		/// <summary>Gets the number of unique contacts.</summary>
		/// <param name="shred30Contacts">The shred30 contacts.</param>
		public int GetNumberOfUniqueContacts(IEnumerable<IShred30Contact> shred30Contacts)
		{
			return this.GetUniqueContacts(shred30Contacts).Count();
		}

		/// <summary>Gets the unique contacts.</summary>
		/// <param name="shred30Contacts">The shred30 contacts.</param>
		public IEnumerable<IShred30Contact> GetUniqueContacts(IEnumerable<IShred30Contact> shred30Contacts)
		{
			Shred30ContactCollection uniqueContacts = new Shred30ContactCollection();

			foreach(IShred30Contact contact in shred30Contacts)
			{
				if(contact.CanBeUnique && !uniqueContacts.Contains(contact, new Shred30ContactComparer()))
				{
					uniqueContacts.Add(contact);
				}
			}

			return this.GetFinalizedUniqueContacts(uniqueContacts);
		}

		/// <summary>Gets the finalized unique contacts, after the basic uniqueness rules have already been applied.</summary>
		/// <param name="basicUniqueShred30Contacts">The basic unique shred30 contacts.</param>
		protected abstract IEnumerable<IShred30Contact> GetFinalizedUniqueContacts(IEnumerable<IShred30Contact> basicUniqueShred30Contacts);

		/// <summary>Determines whether [is instace of contact unique] [the specified shred30 contacts].</summary>
		/// <param name="shred30Contacts">The shred30 contacts.</param>
		/// <param name="shred30Contact">The shred30 contact.</param>
		public bool IsInstaceOfContactUnique(IEnumerable<IShred30Contact> shred30Contacts, IShred30Contact shred30Contact)
		{
			return this
				.GetUniqueContacts(shred30Contacts)
				.Any(uniqueContact => uniqueContact.UniqueId == shred30Contact.UniqueId);
		}
	}
}