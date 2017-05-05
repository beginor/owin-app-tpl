using System.Web.Http.ExceptionHandling;
using Beginor.Owin.StaticFile;
using Microsoft.Owin.Security.DataProtection;
using NUnit.Framework;
using Beginor.OwinApp.Logic;

namespace Beginor.OwinApp.Test {
    
    [TestFixture]
    public class ConfigTest : WindsorTest {
        
        [Test]
        public void CanResolveLoggerFactory() {
            var loggerFactory = Container.Resolve<Microsoft.Owin.Logging.ILoggerFactory>();
            Assert.NotNull(loggerFactory);
        }

        [Test]
        public void CanResolveExceptionLogger() {
            var exLogger = Container.Resolve<IExceptionLogger>();
            Assert.NotNull(exLogger);
        }

        [Test]
        public void CanResolveAesDataProtectionProvider() {
            var aes = Container.Resolve<IDataProtectionProvider>();
            Assert.NotNull(aes);
        }

        [Test]
        public void CanResolveStaticFileOptions() {
            var opts = Container.Resolve<StaticFileMiddlewareOptions>();
            Assert.NotNull(opts);
        }

        [Test]
        public void CanResolveModelMappings() {
            var mappings = Container.Resolve<ModelMappings>();
            mappings.Start();
            Assert.NotNull(mappings);
        }

    }
}
