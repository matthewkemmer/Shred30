using Shred30.Common.Models.Contacts;
using System;

namespace Shred30.Common.Exceptions
{
	public class NotAllTricksSpecifySidesException : Exception
	{
		public NotAllTricksSpecifySidesException(IShred30Contact shred30Contact)
			: base(GetExceptionMessage(shred30Contact))
		{
		}

		private static string GetExceptionMessage(IShred30Contact shred30Contact)
		{
			return string.Format("Could not figure out side for trick '{0}'", shred30Contact.Name);
		}
	}
}