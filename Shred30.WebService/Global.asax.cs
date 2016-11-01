using Shred30.WebService.Config;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Shred30.WebService
{
	public class Shred30WebService : HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
		}
	}
}