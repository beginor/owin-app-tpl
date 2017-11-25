using System;
using System.Web.Http;
using Beginor.OwinApp.Logic;
using Castle.Core.Logging;

namespace Beginor.OwinApp.Api.Controllers {

    [RoutePrefix("rest/samples")]
    public class SamplesController : ApiController {

        private ISampleManager mgr;

        public ILogger Logger { get; set; } = NullLogger.Instance;

        public SamplesController(ISampleManager mgr) {
            this.mgr = mgr;
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                mgr = null;
            }
            base.Dispose(disposing);
        }

        [HttpGet, Route("")]
        public IHttpActionResult Query() {
            try {
                return Ok(mgr.GetAll());
            }
            catch (Exception ex) {
                Logger.Error("无法查询示例！", ex);
                return InternalServerError(ex);
            }
        }

    }
}
