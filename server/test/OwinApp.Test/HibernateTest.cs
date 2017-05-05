using System;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace Beginor.OwinApp.Test {

    [TestFixture]
    public class HibernateTest : WindsorTest {

        [Test]
        public void CanResolveSessionFactory() {
            var sessionFactory = Container.Resolve<ISessionFactory>();
            Assert.NotNull(sessionFactory);
        }

        [Test]
        public void CanResolveSession() {
            var session = Container.Resolve<ISession>();
            Assert.NotNull(session);
            session.Close();
            session.Dispose();
        }

        [Test]
        public void CanExportSchema() {
            var cfg = new Configuration();
            var configFile = System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "hibernate.config"
            );
            cfg.Configure(configFile);
            SchemaExport export = new SchemaExport(cfg);
            export.Execute(true, false, false);
        }

    }

}
