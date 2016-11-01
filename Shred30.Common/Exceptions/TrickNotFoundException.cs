using System;

namespace Shred30.Common.Exceptions
{
	public class TrickNotFoundException : Exception
	{
		public TrickNotFoundException(string trickName)
			: base(GetExceptionMessage(trickName))
		{
		}

		private static string GetExceptionMessage(string trickName)
		{
			return string.Format("Trick with name '{0}' not found.", trickName);
		}
	}
}