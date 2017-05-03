using System;
using System.Web.Http;
using Beginor.OwinApp.Logic;

namespace Beginor.OwinApp.Api.Controllers {

    [RoutePrefix("rest/samples")]
    public class SamplesController : ApiController {

        private SampleManager mgr = new SampleManager();

        public SamplesController() {
        }

        [HttpGet, Route("")]
        public IHttpActionResult Query() {
            try {
                return Ok(mgr.GetAll());
            }
            catch (Exception ex) {
                return InternalServerError(ex);
            }
        }

    }
}
