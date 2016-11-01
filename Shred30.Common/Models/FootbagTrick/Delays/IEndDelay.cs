using Shred30.Common.Enums;

namespace Shred30.Common.Models.FootbagTrick.Delays
{
	public interface IEndDelay
	{
		SurfaceType Surface { get; set; }

		RelativeSideType RelativeSide { get; set; }
	}
}