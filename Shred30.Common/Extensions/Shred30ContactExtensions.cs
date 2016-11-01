using Shred30.Common.Collections;
using Shred30.Common.Models.Contacts;
using System.Collections.Generic;

namespace Shred30.Common.Extensions
{
	/// <summary>Extensions for IShred30Contact.</summary>
	public static class Shred30ContactExtensions
	{
		/// <summary>Gets the Shred30ContactCollection.</summary>
		/// <param name="shred30Contacts">The shred30 contacts.</param>
		/// <returns></returns>
		public static Shred30ContactCollection GetCollection(this IEnumerable<IShred30Contact> shred30Contacts)
		{
			return new Shred30ContactCollection(shred30Contacts);
		}
	}
}