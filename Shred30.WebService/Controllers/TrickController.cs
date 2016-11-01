using Shred30.Service.FootbagTrick.Xml;
using System;
using System.Web.Http;

namespace Shred30.WebService.Controllers
{
	public class TrickController : ApiController
	{
		[HttpGet]
		public IHttpActionResult Available()
		{
			try
			{
				XmlFootbagTrickService trickService = new XmlFootbagTrickService();

				return Ok(trickService.FootbagTricks);
			}
			catch(Exception exception)
			{
				return InternalServerError(exception);
			}
		}
	}
}