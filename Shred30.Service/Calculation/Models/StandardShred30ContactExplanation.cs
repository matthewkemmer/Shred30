using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Shred30.Common.Enums;

namespace Shred30.Service.Calculation.Models
{
	/// <summary>The explanation each contacts score contribution using the standard scoring.</summary>
	/// <seealso cref="Shred30.Service.Calculation.Models.IShred30ContactExplanation" />
	public class StandardShred30ContactExplanation : IShred30ContactExplanation
	{
		#region Properties
		/// <summary>Gets or sets the name.</summary>
		public string Name { get; set; }

		/// <summary>Gets or sets the adds.</summary>
		public int Adds { get; set; }

		/// <summary>Gets or sets the start side.</summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public OrdinalSideType StartSide { get; set; }

		/// <summary>Gets or sets a value indicating whether this instance is same side.</summary>
		public bool IsSameSide { get; set; }

		/// <summary>Gets or sets a value indicating whether this instance is unique.</summary>
		public bool IsUnique { get; set; }
		#endregion
	}
}