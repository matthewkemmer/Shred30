using Shred30.Common.Models.Contacts;
using System;

namespace Shred30.Common.Exceptions
{
	public class TrickAfterDropDoesNotSpecifySideException : Exception
	{
		public TrickAfterDropDoesNotSpecifySideException(IShred30Contact shred30Contact)
			: base(GetExceptionMessage(shred30Contact))
		{
		}

		private static string GetExceptionMessage(IShred30Contact shred30Contact)
		{
			return string.Format("'{0}' must specify a starting side because it comes after a drop.", shred30Contact.Name);
		}
	}
}