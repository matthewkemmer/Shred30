using Shred30.Common.Collections;
using System;

namespace Shred30.Common.Exceptions
{
	public class SurfacesDoNotLineUpException : Exception
	{
		public SurfacesDoNotLineUpException(Shred30ContactPair contactPair)
			: base(GetExceptionMessage(contactPair))
		{
		}

		private static string GetExceptionMessage(Shred30ContactPair contactPair)
		{
			return string.Format(
				"Surfaces between '{0}' and '{1}' do not line up.",
				contactPair.FirstContact.Name,
				contactPair.SecondContact.Name
			);
		}
	}
}