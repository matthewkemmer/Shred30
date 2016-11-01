using Newtonsoft.Json;
using Shred30.Common.Exceptions;
using Shred30.Common.Extensions;
using Shred30.Common.Models;
using Shred30.Common.Models.Contacts;
using Shred30.Service.Calculation.ScoreCalculators;
using Shred30.Service.Deserialization;
using Shred30.WebService.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace Shred30.WebService.Controllers
{
	/// <summary>Controller for calculating a shred 30 score.</summary>
	/// <seealso cref="System.Web.Http.ApiController" />
	public class ScoreController : ApiController
	{
		#region Methods
		/// <summary>
		///		Deserializes the shred 30 JSON, calculates the score, and returns the score metadata.
		///	</summary>
		/// <param name="shred30">The shred30 JSON.</param>
		/// <param name="shred30Options">The shred30 options.</param>
		[HttpGet]
		public IHttpActionResult Index(string shred30, string options = null)
		{
			try
			{
				Shred30Options shred30Options = this.GetShred30Options(options);

				Shred30ContactsDeserializer deserializer = new Shred30ContactsDeserializer(shred30);
				IEnumerable<IShred30Contact> shred30Contacts = deserializer.Deserialize();

				IShred30ScoreCalculator scoreCalculator =
					Shred30ScoreCalculatorFactory.GetScoreCalculator(shred30Options, shred30Contacts);

				Shred30ScoreResponse scoreResponse = new Shred30ScoreResponse
				{
					Shred30String = shred30Contacts.GetCollection().Format(),
					Score = scoreCalculator.CalculateScore(),
					ScoreComponents = scoreCalculator.GetScoreComponents(),
					ContactExplanations = scoreCalculator.GetContactExplanations(),
					Shred30Options = shred30Options
				};

				return Ok(scoreResponse);
			}
			catch(JsonException jsonException)
			{
				return InternalServerError(jsonException);
			}
			catch(DeserializationException deserializationException)
			{
				return Content(HttpStatusCode.PreconditionFailed, deserializationException);
			}
			catch(TrickNotFoundException trickNotFoundException)
			{
				return Content(HttpStatusCode.NotFound, trickNotFoundException.Message);
			}
			catch(NotAllTricksSpecifySidesException notAllTricksSpecifySideException)
			{
				return Content(HttpStatusCode.PreconditionFailed, notAllTricksSpecifySideException.Message);
			}
			catch(SurfacesDoNotLineUpException surfacesDoNotLineUpException)
			{
				return Content(HttpStatusCode.PreconditionFailed, surfacesDoNotLineUpException.Message);
			}
			catch(TrickAfterDropDoesNotSpecifySideException trickAfterDropDoesNotSpecifySideException)
			{
				return Content(HttpStatusCode.PreconditionFailed, trickAfterDropDoesNotSpecifySideException);
			}
			catch(Exception exception)
			{
				return InternalServerError(exception);
			}
		}

		/// <summary>Gets the shred30 options.</summary>
		/// <param name="options">The options.</param>
		private Shred30Options GetShred30Options(string options)
		{
			if(options == null)
			{
				return Shred30Options.Default();
			}
			else
			{
				return JsonConvert.DeserializeObject<Shred30Options>(options);
			}
		}
		#endregion
	}
}