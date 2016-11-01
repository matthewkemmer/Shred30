using Shred30.Common.Models;
using Shred30.Common.Models.Contacts;
using Shred30.Service.Arranging;
using Shred30.Service.Calculation.AddCalculators;
using Shred30.Service.Calculation.Models;
using Shred30.Service.Calculation.UniqueCalculators;
using Shred30.Service.Validation;
using System.Collections.Generic;
using System.Linq;

namespace Shred30.Service.Calculation.ScoreCalculators
{
	/// <summary>A class to calculate a shred 30 score based on a string of contacts.</summary>
	public class StandardShred30ScoreCalculator : IShred30ScoreCalculator
	{
		#region Member Variables
		/// <summary>The contact arrangers.</summary>
		private IEnumerable<IShred30ContactArranger> ContactArrangers;

		/// <summary>The validators</summary>
		private IEnumerable<IShredContact30Validator> Validators;

		/// <summary>The ADD calculator.</summary>
		private IAddCalculator AddCalculator;

		/// <summary>The unique calculator</summary>
		private IUniqueCalculator UniqueCalculator;
		#endregion

		#region Properties
		/// <summary>Gets or sets the shred30 contacts.</summary>
		public IEnumerable<IShred30Contact> Shred30Contacts { get; set; }

		/// <summary>Gets the total number of contacts.</summary>
		public int TotalContacts
		{
			get
			{
				return this.Shred30Contacts.Count();
			}
		}

		/// <summary>Gets the total number unique contacts.</summary>
		public int TotalUniques
		{
			get
			{
				return this.UniqueCalculator.GetNumberOfUniqueContacts(this.Shred30Contacts);
			}
		}

		/// <summary>Gets the total number of ADDs.</summary>
		public int TotalAdds
		{
			get
			{
				return this.AddCalculator.GetTotalAdds(this.Shred30Contacts);
			}
		}

		/// <summary>Gets the ADD ratio (ADDs per contact).</summary>
		public double AddRatio
		{
			get
			{
				return
					((double) this.TotalAdds) /
					((double) this.TotalContacts);
			}
		}
		#endregion

		#region Constructor
		/// <summary>Initializes a new instance of the <see cref="ScoreCalculator" /> class.</summary>
		/// <param name="shred30Contacts">The shred30 contacts.</param>
		/// <param name="contactArrangers">The contact arrangers.</param>
		/// <param name="validators">The validators.</param>
		/// <param name="addCalculator">The add calculator.</param>
		public StandardShred30ScoreCalculator(IEnumerable<IShred30Contact> shred30Contacts, IEnumerable<IShred30ContactArranger> contactArrangers, IEnumerable<IShredContact30Validator> validators, IAddCalculator addCalculator, IUniqueCalculator uniqueCalculator)
		{
			this.Shred30Contacts = shred30Contacts;
			this.ContactArrangers = contactArrangers;
			this.Validators = validators;
			this.AddCalculator = addCalculator;
			this.UniqueCalculator = uniqueCalculator;
		}
		#endregion

		#region Methods
		/// <summary>Calculates the shred 30 score.</summary>
		/// <remarks>
		///     The formula to calculate a shred 30 score is:
		///         ADDs + (Uniques * AddsPerContact)
		/// </remarks>
		public double CalculateScore()
		{
			this.ArrangeContacts();
			this.ValidateContacts();

			return
				this.TotalAdds +
				(this.TotalUniques * this.AddRatio);
		}

		/// <summary>Arranges the contacts.</summary>
		private void ArrangeContacts()
		{
			foreach(IShred30ContactArranger contactArranger in this.ContactArrangers)
			{
				this.Shred30Contacts = contactArranger.ArrangeContacts(this.Shred30Contacts);
			}
		}

		/// <summary>Validates the contacts.</summary>
		private void ValidateContacts()
		{
			foreach(IShredContact30Validator validator in this.Validators)
			{
				validator.ValidateContacts(this.Shred30Contacts);
			}
		}

		/// <summary>Gets the score components used in the calculation.</summary>
		public IEnumerable<Shred30ScoreComponent> GetScoreComponents()
		{
			return new List<Shred30ScoreComponent>
			{
				new Shred30ScoreComponent("Total ADDs", this.TotalAdds),
				new Shred30ScoreComponent("Total Contacts", this.TotalContacts),
				new Shred30ScoreComponent("Total Uniques", this.TotalUniques),
				new Shred30ScoreComponent("ADD Ratio", this.AddRatio)
			};
		}

		/// <summary>Gets the explanation of the shred 30 score.</summary>
		/// <remarks>Lists each trick name, its ADDs, and whether it's unique.</remarks>
		public IEnumerable<IShred30ContactExplanation> GetContactExplanations()
		{
			List<IShred30ContactExplanation> contactExplanations = new List<IShred30ContactExplanation>();

			foreach(IShred30Contact shred30Contact in this.Shred30Contacts)
			{
				contactExplanations.Add(
					new StandardShred30ContactExplanation
					{
						Name = shred30Contact.Name,
						Adds = this.AddCalculator.GetAdds(shred30Contact),
						StartSide = shred30Contact.StartSide,
						IsSameSide = shred30Contact.IsSameSideVariant,
						IsUnique = this.UniqueCalculator.IsInstaceOfContactUnique(this.Shred30Contacts, shred30Contact)
					}
				);
			}

			return contactExplanations;
		}
		#endregion
	}
}