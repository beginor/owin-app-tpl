using Beginor.OwinApp.Api.Controllers;
using Castle.Core.Logging;
using NUnit.Framework;
using System.Web.Http.Results;

namespace Beginor.OwinApp.Test.Controller {

    [TestFixture]
    public class HomeControllerTest : WindsorTest<HomeController> {

        [Test]
        public void _01_CanResolveTarget() {
            Assert.NotNull(Target);
            Assert.False(Target.Logger is NullLogger);
        }

        [Test]
        public void _02_CanIndex() {
            var result = Target.Index();
            Assert.NotNull(result);
            var content = result as NegotiatedContentResult<string>;
            Assert.NotNull(content);
            Assert.AreEqual("Hello, world!", content.Content);
        }

    }

}
