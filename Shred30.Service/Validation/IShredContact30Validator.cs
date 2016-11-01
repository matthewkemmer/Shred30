using Shred30.Common.Models.Contacts;
using System.Collections.Generic;

namespace Shred30.Service.Validation
{
	/// <summary>Contract for shred 30 contact validation.</summary>
	public interface IShredContact30Validator
	{
		#region Methods
		/// <summary>Validates the contacts.</summary>
		/// <param name="shred30Contacts">The shred30 contacts.</param>
		void ValidateContacts(IEnumerable<IShred30Contact> shred30Contacts);
		#endregion
	}
}