using Shred30.Common.Collections;
using Shred30.Common.Extensions;
using Shred30.Common.Models.Contacts;
using System.Collections.Generic;
using System.Linq;

namespace Shred30.Service.Arranging
{
	/// <summary>Class to set the sides of all shred 30 contacts in a collection</summary>
	public class StartSideArranger : IShred30ContactArranger
	{
		#region Methods
		/// <summary>Sets the ordinal sides for each contact.</summary>
		/// <param name="shred30Contacts">The shred30 contacts.</param>
		public IEnumerable<IShred30Contact> ArrangeContacts(IEnumerable<IShred30Contact> shred30Contacts)
		{
			if(shred30Contacts.Count() <= 1)
			{
				return shred30Contacts;
			}

			foreach(Shred30ContactPair shred30ContactPair in shred30Contacts.GetCollection().GetPairCollection())
			{
				IShred30Contact firstContact = shred30ContactPair.FirstContact;
				IShred30Contact secondContact = shred30ContactPair.SecondContact;

				if(firstContact.IsDrop || secondContact.IsDrop)
				{
					continue;
				}

				secondContact.StartSide = firstContact.GetEndSide();
			}

			return shred30Contacts;
		}
		#endregion
	}
}