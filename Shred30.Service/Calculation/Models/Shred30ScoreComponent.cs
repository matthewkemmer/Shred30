namespace Shred30.Service.Calculation.Models
{
	/// <summary>Model for a shred 30 score component.</summary>
	public class Shred30ScoreComponent
	{
		/// <summary>Gets the name of the component.</summary>
		public string Name { get; }

		/// <summary>Gets the value of the component.</summary>
		public object Value { get; }

		/// <summary>Initializes a new instance of the <see cref="Shred30ScoreComponent"/> class.</summary>
		/// <param name="name">The name.</param>
		/// <param name="value">The value.</param>
		public Shred30ScoreComponent(string name, object value)
		{
			this.Name = name;
			this.Value = value;
		}
	}
}