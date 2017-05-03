using System;
using System.Net;
using System.Web.Http;

namespace Beginor.OwinApp.Api.Controllers {

    public class HomeController : ApiController {

        public IHttpActionResult Index() {
            return this.Content(HttpStatusCode.OK, "Hello, world!");
        }

    }

}
