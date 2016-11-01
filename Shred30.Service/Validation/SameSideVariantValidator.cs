using Shred30.Common.Exceptions;
using Shred30.Common.Models.Contacts;
using System.Collections.Generic;

namespace Shred30.Service.Validation
{
	/// <summary>Validates that all contacts marked as a "same side variant" can actually be same side.</summary>
	/// <seealso cref="Shred30.Service.Validation.IShredContact30Validator" />
	public class SameSideVariantValidator : IShredContact30Validator
	{
		#region Methods
		/// <summary>Validates the contacts.</summary>
		/// <param name="shred30Contacts">The shred30 contacts.</param>
		public void ValidateContacts(IEnumerable<IShred30Contact> shred30Contacts)
		{
			foreach(IShred30Contact shred30Contact in shred30Contacts)
			{
				if(!shred30Contact.IsSameSideVariant)
				{
					continue;
				}

				if(!shred30Contact.FootbagTrick.HasSameSideVariant)
				{
					throw new SameSideVariantMismatchException(shred30Contact);
				}
			}
		}
		#endregion
	}
}