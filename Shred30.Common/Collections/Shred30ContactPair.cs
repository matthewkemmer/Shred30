using Shred30.Common.Models.Contacts;

namespace Shred30.Common.Collections
{
	/// <summary>Collection of two shred30 contacts</summary>
	public class Shred30ContactPair
	{
		#region Properties
		/// <summary>Gets or sets the first contact.</summary>
		public IShred30Contact FirstContact { get; set; }

		/// <summary>Gets or sets the second contact.</summary>
		public IShred30Contact SecondContact { get; set; }
		#endregion
	}
}