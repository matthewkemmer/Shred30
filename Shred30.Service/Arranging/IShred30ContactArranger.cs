using Shred30.Common.Models.Contacts;
using System.Collections.Generic;

namespace Shred30.Service.Arranging
{
	/// <summary>Contract for shred 30 contact arranging.</summary>
	public interface IShred30ContactArranger
	{
		#region Methods
		/// <summary>Arranges the contacts.</summary>
		/// <param name="shred30Contacts">The shred30 contacts.</param>
		IEnumerable<IShred30Contact> ArrangeContacts(IEnumerable<IShred30Contact> shred30Contacts);
		#endregion
	}
}