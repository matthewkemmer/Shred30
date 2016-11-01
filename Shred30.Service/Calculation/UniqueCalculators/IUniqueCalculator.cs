using Shred30.Common.Models.Contacts;
using System.Collections.Generic;

namespace Shred30.Service.Calculation.UniqueCalculators
{
	/// <summary>Unique shred 30 contact contract.</summary>
	public interface IUniqueCalculator
	{
		#region Methods
		/// <summary>Gets the unique contacts.</summary>
		/// <param name="shred30Contacts">The shred30 contacts.</param>
		IEnumerable<IShred30Contact> GetUniqueContacts(IEnumerable<IShred30Contact> shred30Contacts);

		/// <summary>Gets the number of unique contacts.</summary>
		/// <param name="shred30Contacts">The shred30 contacts.</param>
		int GetNumberOfUniqueContacts(IEnumerable<IShred30Contact> shred30Contacts);

		/// <summary>Determines whether [is instace of contact unique] [the specified shred30 contacts].</summary>
		/// <param name="shred30Contacts">The shred30 contacts.</param>
		/// <param name="shred30Contact">The shred30 contact.</param>
		bool IsInstaceOfContactUnique(IEnumerable<IShred30Contact> shred30Contacts, IShred30Contact shred30Contact);
		#endregion
	}
}