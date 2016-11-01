namespace Shred30.Service.Calculation.UniqueCalculators
{
	/// <summary>Model for an open-level ADDs-based unique calculator.</summary>
	/// <seealso cref="Shred30.Service.Calculation.UniqueCalculators.AddsBasedUniqueCalculator" />
	public class OpenAddsBasedUniqueCalculator : AddsBasedUniqueCalculator
	{
		/// <summary>Gets the minimum adds that a unique contact must have.</summary>
		protected override int MinimumAddsForUniqueContact
		{
			get
			{
				return 3;
			}
		}
	}
}