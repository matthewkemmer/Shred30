using Shred30.Common.Models.Contacts;
using Shred30.Service.FootbagTrick;
using System.Collections.Generic;

namespace Shred30.Service.Arranging
{
	/// <summary>The footbag trick arranger; get metadata about each contact.</summary>
	/// <seealso cref="Shred30.Service.Arranging.IShred30ContactArranger" />
	public class FootbagTrickArranger : IShred30ContactArranger
	{
		#region Member Variables
		/// <summary>The trick service</summary>
		private IFootbagTrickService TrickService;
		#endregion

		#region Constructor
		/// <summary>Initializes a new instance of the <see cref="FootbagTrickArranger"/> class.</summary>
		/// <param name="trickService">The trick service.</param>
		public FootbagTrickArranger(IFootbagTrickService trickService)
		{
			this.TrickService = trickService;
		}
		#endregion

		#region Methods
		/// <summary>Arranges the contacts.</summary>
		/// <param name="shred30Contacts">The shred30 contacts.</param>
		public IEnumerable<IShred30Contact> ArrangeContacts(IEnumerable<IShred30Contact> shred30Contacts)
		{
			foreach(IShred30Contact shred30Contact in shred30Contacts)
			{
				if(shred30Contact.IsDrop)
				{
					continue;
				}

				shred30Contact.FootbagTrick = this.TrickService.GetTrick(shred30Contact.Name);
			}

			return shred30Contacts;
		}
		#endregion
	}
}