using Shred30.Common.Models.Contacts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Shred30.Common.Collections
{
	/// <summary>Collection of IShred30Contacts</summary>
	/// <seealso cref="System.Collections.Generic.IEnumerable{Shred30.Models.Contacts.IShred30Contact}" />
	public class Shred30ContactCollection : IEnumerable<IShred30Contact>
	{
		#region Member Variables
		/// <summary>The shred30 contacts</summary>
		private List<IShred30Contact> Shred30Contacts;
		#endregion

		#region Constructor
		/// <summary>Initializes a new instance of the <see cref="Shred30ContactCollection"/> class.</summary>
		public Shred30ContactCollection()
		{
			this.Shred30Contacts = new List<IShred30Contact>();
		}
		#endregion

		/// <summary>Initializes a new instance of the <see cref="Shred30ContactCollection"/> class.</summary>
		/// <param name="shred30Contacts">The shred30 contacts.</param>
		public Shred30ContactCollection(IEnumerable<IShred30Contact> shred30Contacts)
		{
			this.Shred30Contacts = shred30Contacts.ToList();
		}

		#region Operators
		/// <summary>Gets the <see cref="IShred30Contact"/> at the specified index.</summary>
		public IShred30Contact this[int index]
		{
			get
			{
				return this.Shred30Contacts[index];
			}
		}
		#endregion

		#region Methods
		/// <summary>Adds the specified shred30 contact.</summary>
		/// <param name="shred30Contact">The shred30 contact.</param>
		public void Add(IShred30Contact shred30Contact)
		{
			this.Shred30Contacts.Add(shred30Contact);
		}

		/// <summary>Returns an enumerator that iterates through the collection.</summary>
		public IEnumerator<IShred30Contact> GetEnumerator()
		{
			return this.Shred30Contacts.GetEnumerator();
		}

		/// <summary>Returns an enumerator that iterates through a collection.</summary>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		/// <summary>Formats the specified shred30 contacts in the traditional footbag string format.</summary>
		/// <param name="shred30Contacts">The shred30 contacts.</param>
		public string Format()
		{
			return string.Join(
				">",
				this.Shred30Contacts.Select(contact => contact.Name)
			);
		}

		/// <summary>Gets a collection of shred30 contact pairs.</summary>
		/// <returns></returns>
		public IEnumerable<Shred30ContactPair> GetPairCollection()
		{
			List<Shred30ContactPair> shred30ContactPairs = new List<Shred30ContactPair>();

			if(this.Shred30Contacts.Count > 1)
			{
				for(int i = 0; i < this.Shred30Contacts.Count - 1; i++)
				{
					shred30ContactPairs.Add(
						new Shred30ContactPair
						{
							FirstContact = this.Shred30Contacts[i],
							SecondContact = this.Shred30Contacts[i + 1]
						}
					);
				}
			}

			return shred30ContactPairs;
		}
		#endregion
	}
}