using System;

namespace Shred30.Common.Exceptions
{
	public class DeserializationException : Exception
	{
		public DeserializationException(string message)
			: base(message)
		{
		}
	}
}