using NUnit.Framework;
using Beginor.OwinApp.Data;

namespace Beginor.OwinApp.Test.Data {

    [TestFixture]
    public class SampleRepositoryTest : WindsorTest<ISampleRepository> {

        [Test]
        public void CanGetAll() {
            var result = Target.GetAll();
            Assert.IsTrue(result.Count >= 0);
        }

    }

}
