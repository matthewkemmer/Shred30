using System.ComponentModel;

namespace Shred30.Common.Enums
{
	/// <summary>Enum to represent a delay surface.</summary>
	[DefaultValue(None)]
	public enum SurfaceType
	{
		Toe,
		Clipper,
		Either,
		None
	}
}