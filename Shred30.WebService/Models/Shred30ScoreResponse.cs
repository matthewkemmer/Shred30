using Shred30.Common.Models;
using Shred30.Service.Calculation.Models;
using System.Collections.Generic;

namespace Shred30.WebService.Models
{
	/// <summary>The shred 30 score metadata response, including an explanation of how the score was calculated.</summary>
	public class Shred30ScoreResponse
	{
		#region Properties
		/// <summary>Gets or sets the shred30 string.</summary>
		public string Shred30String { get; set; }

		/// <summary>Gets the score.</summary>
		public double Score { get; set; }

		/// <summary>Gets the score components.</summary>
		public IEnumerable<Shred30ScoreComponent> ScoreComponents { get; set; }

		/// <summary>Gets the explanation of the score.</summary>
		public IEnumerable<IShred30ContactExplanation> ContactExplanations { get; set; }

		/// <summary>Gets or sets the shred30 options.</summary>
		public Shred30Options Shred30Options { get; set; }
		#endregion
	}
}