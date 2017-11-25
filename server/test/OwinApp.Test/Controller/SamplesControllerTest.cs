using Beginor.OwinApp.Api.Controllers;
using Castle.Core.Logging;
using NUnit.Framework;

namespace Beginor.OwinApp.Test.Controller {

    [TestFixture]
    public class SamplesControllerTest : WindsorTest<SamplesController> {

        [Test]
        public void _01_CanResolveTarget() {
            Assert.NotNull(Target);
            Assert.False(Target.Logger is NullLogger);
        }

        [Test]
        public void _02_CanQueryAll() {
            var result = Target.Query();
            // var response = await result.ExecuteAsync(CancellationToken.None);
            Assert.IsNotNull(result);
        }

    }

}
