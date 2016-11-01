namespace Shred30.Service.Calculation.UniqueCalculators
{
	/// <summary>Model for an intermediate-level ADDs-based unique calculator.</summary>
	public class IntermediateAddsBasedUniqueCalculator : AddsBasedUniqueCalculator
	{
		/// <summary>Gets the minimum adds that a unique contact must have.</summary>
		protected override int MinimumAddsForUniqueContact
		{
			get
			{
				return 2;
			}
		}
	}
}