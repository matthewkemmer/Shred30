using Shred30.Common.Enums;
using Shred30.Common.Exceptions;
using Shred30.Common.Models.FootbagTrick;
using Shred30.Common.Models.FootbagTrick.Delays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using FootbagTrickModel = Shred30.Common.Models.FootbagTrick.FootbagTrick;

namespace Shred30.Service.FootbagTrick.Xml
{
	public class XmlFootbagTrickService : IFootbagTrickService
	{
		public Dictionary<string, IFootbagTrick> FootbagTricks { get; private set; }

		public XmlFootbagTrickService()
		{
			this.SetXmlFootbagTricks();
		}

		public IFootbagTrick GetTrick(string trickName)
		{
			IFootbagTrick footbagTrick = this.FootbagTricks
				.Values
				.FirstOrDefault(trick => trick.Names.Contains(trickName));

			if(footbagTrick != null)
			{
				return footbagTrick;
			}
			else
			{
				throw new TrickNotFoundException(trickName);
			}
		}

		private void SetXmlFootbagTricks()
		{
			this.FootbagTricks = new Dictionary<string, IFootbagTrick>();

			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(@"C:\Users\Matt\Documents\Visual Studio 2015\Projects\Shred30\Shred30.WebService\bin\FootbagTrick\Xml\footbagtricks.xml");

			List<IFootbagTrick> footbagTricks = new List<IFootbagTrick>();
			foreach(XmlNode node in xmlDocument.FirstChild.ChildNodes)
			{
				try
				{
					FootbagTrickModel footbagTrick = new FootbagTrickModel
					{
						TrickId = node["trickid"].InnerText,
						Adds = int.Parse(node["adds"].InnerText),
						UseXDex = bool.Parse(node["usexdex"].InnerText),
						StartDelay = new Delay
						{
							Surface = (SurfaceType) Enum.Parse(typeof(SurfaceType), node["startdelay"]["surface"].InnerText, true)
						},
						EndDelay = new EndDelay
						{
							Surface = (SurfaceType) Enum.Parse(typeof(SurfaceType), node["enddelay"]["surface"].InnerText, true),
							RelativeSide = (RelativeSideType) Enum.Parse(typeof(RelativeSideType), node["enddelay"]["relativeside"].InnerText, true)
						},
						HasSameSideVariant = bool.Parse(node["hassamesidevariant"].InnerText)
					};

					List<string> names = new List<string>();
					foreach(XmlNode nameNode in node["names"].ChildNodes)
					{
						names.Add(nameNode.InnerText);
					}

					footbagTrick.Names = names;

					List<string> doubleDownTrickNames = new List<string>()
					{
						"barfly",
						"paradon",
						"downoverdown",
						"downdoubledown"
					};

					footbagTrick.IsDoubleDown = footbagTrick.Names.Any(name => doubleDownTrickNames.Contains(name));

					this.FootbagTricks.Add(footbagTrick.TrickId, footbagTrick);
				}
				catch(Exception exception)
				{
					throw new Exception(
						string.Format("Invalid XML for trick at position {0}", this.FootbagTricks.Count),
						exception
					);
				}
			}
		}
	}
}