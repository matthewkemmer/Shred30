using System.ComponentModel;

namespace Shred30.Common.Enums
{
	/// <summary>Enum to represent the relative side a trick ends on.</summary>
	[DefaultValue(None)]
	public enum RelativeSideType
	{
		Opposite,
		Same,
		Either,
		None
	}
}