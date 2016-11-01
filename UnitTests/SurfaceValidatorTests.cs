using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shred30.Common.Enums;
using Shred30.Common.Exceptions;
using Shred30.Common.Models.Contacts;
using Shred30.Service.Validation;
using Shred30.UnitTests.Mocks;
using System.Collections.Generic;

namespace Shred30.UnitTests
{
	[TestClass]
	public class Surface
	{
		private SurfacesLineUpValidator Validator;

		[TestMethod]
		public void CanValidateValidSurfaces()
		{
			List<IShred30Contact> shred30Contacts = new List<IShred30Contact>
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.BlurryWhirl)
			};

			this.Validator = new SurfacesLineUpValidator();

			this.Validator.ValidateContacts(shred30Contacts);
		}

		[TestMethod]
		[ExpectedException(typeof(SurfacesDoNotLineUpException))]
		public void CanNotValidateContactsWithInvalidSurfaces()
		{
			List<IShred30Contact> shred30Contacts = new List<IShred30Contact>
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Dimwalk)
			};

			this.Validator = new SurfacesLineUpValidator();

			this.Validator.ValidateContacts(shred30Contacts);
		}

		[TestMethod]
		public void CanValidateSurfacesMatchSecondContactStartFromEitherSurface()
		{
			List<IShred30Contact> shred30Contacts = new List<IShred30Contact>
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Blur),
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Mirage),
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Mirage),
			};

			this.Validator = new SurfacesLineUpValidator();

			this.Validator.ValidateContacts(shred30Contacts);
		}
	}
}