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
	public class SideValidatorTests
	{
		private AllTricksSpecifySideValidator Validator;

		[TestMethod]
		public void CanValidateAllContactsHaveSides()
		{
			List<IShred30Contact> shred30Contacts = new List<IShred30Contact>
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.Right, MockFootbagTricks.BlurryWhirl)
			};

			this.Validator = new AllTricksSpecifySideValidator();

			this.Validator.ValidateContacts(shred30Contacts);
		}

		[TestMethod]
		[ExpectedException(typeof(NotAllTricksSpecifySidesException))]
		public void CanValidateNotAllContactsHaveSides()
		{
			List<IShred30Contact> shred30Contacts = new List<IShred30Contact>
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk),
				new Shred30Trick(OrdinalSideType.None, MockFootbagTricks.BlurryWhirl)
			};

			this.Validator = new AllTricksSpecifySideValidator();

			this.Validator.ValidateContacts(shred30Contacts);
		}
	}
}