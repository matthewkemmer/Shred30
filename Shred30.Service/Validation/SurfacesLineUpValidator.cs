using Shred30.Common.Collections;
using Shred30.Common.Enums;
using Shred30.Common.Exceptions;
using Shred30.Common.Extensions;
using Shred30.Common.Models.Contacts;
using System.Collections.Generic;
using System.Linq;

namespace Shred30.Service.Validation
{
	/// <summary>Validates that the surfaces of each trick line up correctly.</summary>
	/// <seealso cref="Shred30.Service.Validation.IShredContact30Validator" />
	public class SurfacesLineUpValidator : IShredContact30Validator
	{
		#region Methods
		/// <summary>Validates the contacts.</summary>
		/// <param name="shred30Contacts">The shred30 contacts.</param>
		/// <exception cref="SurfacesDoNotLineUpException"></exception>
		public void ValidateContacts(IEnumerable<IShred30Contact> shred30Contacts)
		{
			if(shred30Contacts.Count() <= 1)
			{
				return;
			}

			foreach(Shred30ContactPair shred30ContactPair in shred30Contacts.GetCollection().GetPairCollection())
			{
				IShred30Contact firstContact = shred30ContactPair.FirstContact;
				IShred30Contact secondContact = shred30ContactPair.SecondContact;

				// drops don't have surfaces, so it is automatically a valid surface pair
				if(firstContact.IsDrop || secondContact.IsDrop)
				{
					continue;
				}

				SurfaceType firstContactEndSurface = firstContact.FootbagTrick.EndDelay.Surface;
				SurfaceType secondContactStartSurface = secondContact.FootbagTrick.StartDelay.Surface;

				bool surfacesLineUpExactly = firstContactEndSurface == secondContactStartSurface;
				bool secondTrickCanStartFromEitherSurface = secondContactStartSurface == SurfaceType.Either;

				if(!(surfacesLineUpExactly || secondTrickCanStartFromEitherSurface))
				{
					throw new SurfacesDoNotLineUpException(shred30ContactPair);
				}
			}
		}
		#endregion
	}
}