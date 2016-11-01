using Shred30.Common.Models.FootbagTrick;

namespace Shred30.Service.FootbagTrick
{
	/// <summary>The footbag trick service contract.</summary>
	public interface IFootbagTrickService
	{
		#region Methods
		/// <summary>Gets the footbag trick.</summary>
		/// <param name="trickName">Name of the trick.</param>
		IFootbagTrick GetTrick(string trickName);
		#endregion
	}
}