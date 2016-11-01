using Shred30.Common.Models.Contacts;
using Shred30.Service.Calculation.Models;
using System.Collections.Generic;

namespace Shred30.Service.Calculation.ScoreCalculators
{
	/// <summary>Contract for a shred 30 calculator.</summary>
	public interface IShred30ScoreCalculator
	{
		IEnumerable<IShred30Contact> Shred30Contacts { get; set; }

		/// <summary>Calculates the shred 30 score.</summary>
		double CalculateScore();

		/// <summary>Gets the score components used in the calculation.</summary>
		IEnumerable<Shred30ScoreComponent> GetScoreComponents();

		/// <summary>Gets the explanation of the shred 30 score.</summary>
		IEnumerable<IShred30ContactExplanation> GetContactExplanations();
	}
}