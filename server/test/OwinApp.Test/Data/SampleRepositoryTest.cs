using NUnit.Framework;
using Beginor.AppFx.Core;
using Beginor.OwinApp.Data;
using System.Threading.Tasks;
using System;

namespace Beginor.OwinApp.Test.Data {

    [TestFixture]
    public class SampleRepositoryTest : WindsorTest<ISampleRepository> {

        [Test]
        public async Task CanGetAll() {
            var result = await Target.GetAllAsync();
            Console.WriteLine(result.Count);
            Assert.IsTrue(result.Count >= 0);
        }

    }

}
