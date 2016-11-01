namespace Shred30.Common.Models
{
	/// <summary>The shred 30 options that affect how the score is calculated.</summary>
	public class Shred30Options
	{
		/// <summary>Gets or sets a value indicating whether [use x dex].</summary>
		public bool UseXDex { get; set; }

		/// <summary>Gets or sets a value indicating whether this instance is open level.</summary>
		public bool IsOpenLevel { get; set; }

		public string FootbagTrickService { get; set; }

		public static Shred30Options Default()
		{
			return new Shred30Options
			{
				UseXDex = true,
				IsOpenLevel = true,
				FootbagTrickService = "xml"
			};
		}
	}
}