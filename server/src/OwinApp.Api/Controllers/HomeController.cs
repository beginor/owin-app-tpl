using System;
using System.Net;
using System.Web.Http;

namespace Beginor.OwinApp.Api.Controllers {

    [RoutePrefix("rest/home")]
    public class HomeController : ApiController {

        [HttpGet]
        public IHttpActionResult Index() {
            return this.Content(HttpStatusCode.OK, "Hello, world!");
        }

    }

}
