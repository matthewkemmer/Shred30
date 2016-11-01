using Shred30.Common.Models.FootbagTrick;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Shred30.Service.FootbagTrick.Xml
{
	[Serializable()]
	[XmlRoot("trickcollection")]
	public class XmlFootbagTrickCollection : List<IFootbagTrick>
	{
		[XmlArray("tricks")]
		[XmlArrayItem("trick", typeof(XmlFootbagTrick))]
		public List<XmlFootbagTrick> XmlFootbagTricks { get; set; }
	}
}