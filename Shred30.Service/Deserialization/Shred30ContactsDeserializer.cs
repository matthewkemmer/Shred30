using Newtonsoft.Json;
using Shred30.Common.Collections;
using Shred30.Common.Exceptions;
using Shred30.Common.Models;
using Shred30.Common.Models.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shred30.Service.Deserialization
{
	/// <summary>Class to deserialize a string of contacts into an ordered list of concrete objects.</summary>
	public class Shred30ContactsDeserializer
	{
		#region Member Variables
		/// <summary>The contacts JSON</summary>
		private string ContactsJson;

		/// <summary>The drop element name.</summary>
		private const string DropElementName = "drop";
		#endregion

		#region Constructor
		/// <summary>Initializes a new instance of the <see cref="Shred30ContactsDeserializer" /> class.</summary>
		/// <param name="contactsJson">The contacts JSON.</param>
		/// 
		public Shred30ContactsDeserializer(string contactsJson)
		{
			this.ContactsJson = contactsJson;
		}
		#endregion

		#region Methods
		/// <summary>Deserializes the specified contacts string.</summary>
		/// <param name="contactsJson">The contacts string.</param>
		public IEnumerable<IShred30Contact> Deserialize()
		{
			List<ContactElementJson> contactElementsJson =
				JsonConvert.DeserializeObject<List<ContactElementJson>>(this.ContactsJson);

			bool anyElementHasBlankName = contactElementsJson
				.Any(contactElement => string.IsNullOrWhiteSpace(contactElement.Name));

			if(anyElementHasBlankName)
			{
				throw new DeserializationException("Cannot deserialize contacts because not all elements have a name.");
			}

			Shred30ContactCollection shred30Contacts = new Shred30ContactCollection();
			foreach(ContactElementJson contactElementJson in contactElementsJson)
			{
				IShred30Contact shred30Contact;
				if(contactElementJson.Name.Equals(DropElementName, StringComparison.OrdinalIgnoreCase))
				{
					shred30Contact = new Drop();
				}
				else
				{
					shred30Contact = new Shred30Trick(
						contactElementJson.Side,
						contactElementJson.Name,
						contactElementJson.SameSide
					);
				}

				shred30Contacts.Add(shred30Contact);
			}

			return shred30Contacts;
		}
		#endregion
	}
}