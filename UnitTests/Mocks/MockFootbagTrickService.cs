using Shred30.Common.Models.FootbagTrick;
using Shred30.Service.FootbagTrick;

namespace Shred30.UnitTests.Mocks
{
	public class MockFootbagTrickService : IFootbagTrickService
	{
		#region Methods
		/// <summary>Gets the trick with the given name</summary>
		/// <param name="trickName">Name of the trick.</param>
		/// <remarks>TODO: Call out to API or database to get actual trick metadata.</remarks>
		public IFootbagTrick GetTrick(string trickName)
		{
			switch(trickName.ToLower())
			{
				case "ripwalk":
					{
						return MockFootbagTricks.Ripwalk;
					}
				case "blurry whirl":
					{
						return MockFootbagTricks.BlurryWhirl;
					}
				case "dimwalk":
					{
						return MockFootbagTricks.Dimwalk;
					}
				case "blur":
					{
						return MockFootbagTricks.Blur;
					}
				default:
					throw new System.Exception(
						string.Format("Could not find metadata for trick ({0})", trickName)
					);
			}
		}
		#endregion
	}
}