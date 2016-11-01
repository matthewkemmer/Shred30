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
	public class TricksAfterDropsValidator
	{
		private TricksFollowingDropsSpecifySideValidator Validator;

		[TestMethod]
		public void CanValidateTricksAfterDrops()
		{
			List<IShred30Contact> shred30Contacts = new List<IShred30Contact>
			{
				new Drop(),
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk)
			};

			this.Validator = new TricksFollowingDropsSpecifySideValidator();

			this.Validator.ValidateContacts(shred30Contacts);
		}

		[TestMethod]
		[ExpectedException(typeof(TrickAfterDropDoesNotSpecifySideException))]
		public void CanNotValidateTrickAfterDropWithoutSide()
		{
			List<IShred30Contact> shred30Contacts = new List<IShred30Contact>
			{
				new Drop(),
				new Shred30Trick(OrdinalSideType.None, MockFootbagTricks.Ripwalk)
			};

			this.Validator = new TricksFollowingDropsSpecifySideValidator();

			this.Validator.ValidateContacts(shred30Contacts);
		}
	}
}