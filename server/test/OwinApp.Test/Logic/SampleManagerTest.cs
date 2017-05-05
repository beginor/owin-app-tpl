using NUnit.Framework;
using Beginor.OwinApp.Logic;

namespace Beginor.OwinApp.Test.Logic {

    [TestFixture]
    public class SampleManagerTest : WindsorTest<ISampleManager> {

        [Test]
        public void CanQueryAll() {
            var result = Target.GetAll();
            Assert.IsTrue(result.Count >= 0);
        }
    }
}
