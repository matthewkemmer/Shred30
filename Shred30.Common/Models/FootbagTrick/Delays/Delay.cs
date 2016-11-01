using Shred30.Common.Enums;

namespace Shred30.Common.Models.FootbagTrick.Delays
{
	/// <summary>Model to represent a delay between tricks.</summary>
	public class Delay : IStartDelay
	{
		/// <summary>Gets or sets the delay surface.</summary>
		public SurfaceType Surface { get; set; }
	}
}