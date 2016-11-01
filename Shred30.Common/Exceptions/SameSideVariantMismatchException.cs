using Shred30.Common.Models.Contacts;
using System;

namespace Shred30.Common.Exceptions
{
	public class SameSideVariantMismatchException : Exception
	{
		public SameSideVariantMismatchException(IShred30Contact shred30Contact)
			: base(GetExceptionMessage(shred30Contact))
		{
		}

		private static string GetExceptionMessage(IShred30Contact shred30Contact)
		{
			return string.Format(
				"{0} was marked as being a same side variant, but {0} does not have a same side variant",
				shred30Contact.Name
			);
		}
	}
}