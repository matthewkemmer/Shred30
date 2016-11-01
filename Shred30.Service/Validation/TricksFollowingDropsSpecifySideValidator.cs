using Shred30.Common.Collections;
using Shred30.Common.Enums;
using Shred30.Common.Exceptions;
using Shred30.Common.Extensions;
using Shred30.Common.Models.Contacts;
using System.Collections.Generic;

namespace Shred30.Service.Validation
{
	/// <summary>Validates that all tricks following drops specify a starting side.</summary>
	public class TricksFollowingDropsSpecifySideValidator : IShredContact30Validator
	{
		#region Methods
		/// <summary>Validates the contacts.</summary>
		/// <param name="shred30Contacts">The shred30 contacts.</param>
		/// <exception cref="TrickAfterDropDoesNotSpecifySideException"></exception>
		public void ValidateContacts(IEnumerable<IShred30Contact> shred30Contacts)
		{
			foreach(Shred30ContactPair shred30ContactPair in shred30Contacts.GetCollection().GetPairCollection())
			{
				IShred30Contact firstContact = shred30ContactPair.FirstContact;
				IShred30Contact secondContact = shred30ContactPair.SecondContact;

				bool trickFollowsDrop = firstContact.IsDrop && !secondContact.IsDrop;

				if(trickFollowsDrop)
				{
					if(secondContact.StartSide != OrdinalSideType.None)
					{
						continue;
					}
					else
					{
						throw new TrickAfterDropDoesNotSpecifySideException(secondContact);
					}
				}
			}
		}
		#endregion
	}
}