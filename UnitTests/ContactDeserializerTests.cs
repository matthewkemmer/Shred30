using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shred30.Common.Enums;
using Shred30.Common.Exceptions;
using Shred30.Common.Models.Contacts;
using Shred30.Service.Deserialization;
using System.Collections.Generic;
using System.Linq;

namespace Shred30.UnitTests
{
	[TestClass]
	public class ContactDeserializerTests
	{
		private Shred30ContactsDeserializer Deserializer;

		[TestMethod]
		public void CanDeserializeContact()
		{
			string contactsJson = @"[{""name"":""ripwalk""}]";

			this.Deserializer = new Shred30ContactsDeserializer(contactsJson);

			IEnumerable<IShred30Contact> shred30Contacts = this.Deserializer.Deserialize();

			Assert.AreEqual(1, shred30Contacts.Count());
			Assert.AreEqual("ripwalk", shred30Contacts.First().Name);
			Assert.AreEqual(OrdinalSideType.None, shred30Contacts.First().StartSide);
		}

		[TestMethod]
		public void CanDeserializeMultipleContacts()
		{
			string contactsJson = @"[{""name"":""blurry whirl"",""side"":""left""},{""name"":""blur""},{""name"":""dimwalk""}]";

			this.Deserializer = new Shred30ContactsDeserializer(contactsJson);

			List<IShred30Contact> shred30Contacts = this.Deserializer.Deserialize().ToList();

			Assert.AreEqual(3, shred30Contacts.Count());
			Assert.AreEqual("blurry whirl", shred30Contacts[0].Name);
			Assert.AreEqual(OrdinalSideType.Left, shred30Contacts[0].StartSide);
			Assert.AreEqual("blur", shred30Contacts[1].Name);
			Assert.AreEqual("dimwalk", shred30Contacts[2].Name);
		}

		[TestMethod]
		public void CanDeserializeMultipleContactsWithDrop()
		{
			string contactsJson = @"[{""name"":""ripwalk"",""side"":""left""},{""name"":""drop""},{""name"":""blur"",""side"":""left""},{""name"":""dimwalk""}]";

			this.Deserializer = new Shred30ContactsDeserializer(contactsJson);

			List<IShred30Contact> shred30Contacts = this.Deserializer.Deserialize().ToList();

			Assert.AreEqual(4, shred30Contacts.Count());
			Assert.AreEqual("ripwalk", shred30Contacts[0].Name);
			Assert.AreEqual(OrdinalSideType.Left, shred30Contacts[0].StartSide);
			Assert.IsTrue(shred30Contacts[1].IsDrop);
			Assert.AreEqual("blur", shred30Contacts[2].Name);
			Assert.AreEqual(OrdinalSideType.Left, shred30Contacts[2].StartSide);
			Assert.AreEqual("dimwalk", shred30Contacts[3].Name);
		}

		[TestMethod]
		[ExpectedException(typeof(DeserializationException))]
		public void CannotDeserializeWithBlankName()
		{
			string contactsJson = @"[{""name"":""""}]";

			this.Deserializer = new Shred30ContactsDeserializer(contactsJson);

			this.Deserializer.Deserialize();
		}

		[TestMethod]
		public void CanDeserializeSameSideVariant()
		{
			string contactsJson = @"[{""name"":""mirage"",""sameside"":true}]";

			this.Deserializer = new Shred30ContactsDeserializer(contactsJson);

			IEnumerable<IShred30Contact> shred30Contacts = this.Deserializer.Deserialize();

			Assert.AreEqual(1, shred30Contacts.Count());
			Assert.AreEqual("mirage", shred30Contacts.First().Name);
			Assert.IsTrue(shred30Contacts.First().IsSameSideVariant);
		}
	}
}