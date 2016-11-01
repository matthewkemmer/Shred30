using Shred30.Common.Enums;

namespace Shred30.Common.Models.FootbagTrick.Delays
{
	public class EndDelay : Delay, IEndDelay
	{
		public RelativeSideType RelativeSide { get; set; }
	}
}