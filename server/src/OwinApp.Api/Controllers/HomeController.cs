using System.Net;
using System.Web.Http;
using Castle.Core.Logging;

namespace Beginor.OwinApp.Api.Controllers {

    [RoutePrefix("rest/home")]
    public class HomeController : ApiController {

        public ILogger Logger { get; set; } = NullLogger.Instance;

        [HttpGet]
        public IHttpActionResult Index() {
            return this.Content(HttpStatusCode.OK, "Hello, world!");
        }

    }

}
