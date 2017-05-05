using Beginor.OwinApp.Api.Controllers;
using NUnit.Framework;

namespace Beginor.OwinApp.Test.Controller {

    [TestFixture]
    public class SamplesControllerTest : WindsorTest<SamplesController> {

        [Test]
        public void CanQueryAll() {
            var result = Target.Query();
            // var response = await result.ExecuteAsync(CancellationToken.None);
            Assert.IsNotNull(result);
        }

    }

}
