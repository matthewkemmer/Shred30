using Newtonsoft.Json;
using Shred30.Common.Enums;
using System.ComponentModel;

namespace Shred30.Common.Models
{
	/// <summary>Model for the JSON contact.</summary>
	public class ContactElementJson
	{
		#region Properties
		/// <summary>Gets the name of the contact.</summary>
		public string Name { get; set; }

		/// <summary>Gets or sets the type of the ordinal side.</summary>
		[DefaultValue(OrdinalSideType.None)]
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
		public OrdinalSideType Side { get; set; }

		/// <summary>Gets or sets a value indicating whether [same side].</summary>
		public bool SameSide { get; set; }
		#endregion
	}
}