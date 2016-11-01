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
	public class SameSideVariantValidatorTests
	{
		private SameSideVariantValidator Validator;

		[TestMethod]
		public void CanValidateSameSideTricks()
		{
			List<IShred30Contact> shred30Contacts = new List<IShred30Contact>
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Mirage, sameSideVariant: true)
			};

			this.Validator = new SameSideVariantValidator();

			this.Validator.ValidateContacts(shred30Contacts);
		}

		[TestMethod]
		public void CanValidateTricksThatDontSpecifySameSide()
		{
			List<IShred30Contact> shred30Contacts = new List<IShred30Contact>
			{
				new Shred30Trick(OrdinalSideType.Left, MockFootbagTricks.Ripwalk)
			};

			this.Validator = new SameSideVariantValidator();

			this.Validator.ValidateContacts(shred30Contacts);
		}

		[TestMethod]
		[ExpectedException(typeof(SameSideVariantMismatchException))]
		public void CanNotValidateTrickAfterDropWithoutSide()
		{
			List<IShred30Contact> shred30Contacts = new List<IShred30Contact>
			{
				new Shred30Trick(OrdinalSideType.None, MockFootbagTricks.Ripwalk, sameSideVariant: true)
			};

			this.Validator = new SameSideVariantValidator();

			this.Validator.ValidateContacts(shred30Contacts);
		}
	}
}