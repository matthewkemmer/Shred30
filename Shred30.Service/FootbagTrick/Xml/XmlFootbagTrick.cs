using Shred30.Common.Enums;
using Shred30.Common.Models.FootbagTrick;
using Shred30.Common.Models.FootbagTrick.Delays;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Shred30.Service.FootbagTrick.Xml
{
	[Serializable()]
	public class XmlFootbagTrick : IFootbagTrick
	{
		[XmlElement("adds")]
		public int Adds { get; set; }

		public IStartDelay StartDelay { get { return this.StartDelayXml; } set { } }

		[XmlElement("startdelay")]
		public XmlStartDelay StartDelayXml { get; set; }

		public IEndDelay EndDelay { get { return this.EndDelayXml; } set { } }

		[XmlElement("enddelay")]
		public XmlEndDelay EndDelayXml { get; set; }

		[XmlIgnore]
		public bool IsDoubleDown
		{
			get
			{
				return
					this.Name == "barfly" ||
					this.Name == "doubledown" ||
					this.Name == "downoverdown" ||
					this.Name == "downdoubledown";
			}
		}

		[XmlElement("name")]
		public string Name { get; set; }

		[XmlElement("usexdex")]
		public bool UseXDex { get; set; }

		public bool HasSameSideVariant { get; set; }

		public string TrickId { get; set; }

		public IEnumerable<string> Names { get; set; }

		public XmlFootbagTrick()
		{
			this.Names = new List<string>();
		}
	}

	[Serializable()]
	public class XmlStartDelay : IStartDelay
	{
		[XmlIgnore]
		public SurfaceType Surface
		{
			get
			{
				return (SurfaceType) Enum.Parse(typeof(SurfaceType), this.SurfaceString, ignoreCase: true);
			}
			set { }
		}

		[XmlElement("surface")]
		public string SurfaceString { get; set; }
	}

	[Serializable()]
	public class XmlEndDelay : IEndDelay
	{
		[XmlIgnore]
		public SurfaceType Surface
		{
			get
			{
				return (SurfaceType) Enum.Parse(typeof(SurfaceType), this.SurfaceString, ignoreCase: true);
			}
			set { }
		}

		[XmlElement("surface")]
		public string SurfaceString { get; set; }

		[XmlIgnore]
		public RelativeSideType RelativeSide
		{
			get
			{
				return (RelativeSideType) Enum.Parse(typeof(RelativeSideType), this.RelativeSideString, ignoreCase: true);
			}
			set { }
		}

		[XmlElement("relativeside")]
		public string RelativeSideString { get; set; }
	}
}