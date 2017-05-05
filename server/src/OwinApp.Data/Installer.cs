using System;
using System.IO;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using NHibernate;
using NHibernate.Cfg;

namespace Beginor.OwinApp.Data {

    public class Installer : IWindsorInstaller {
        
        public void Install(
            IWindsorContainer container,
            IConfigurationStore store
        ) {
            RegisterSessionFactory(container, "hibernate.config");
            RegisterSession(container);
            RegisterRepositories(container);
        }

        private void RegisterSessionFactory(
            IWindsorContainer container,
            string configFile
        ) {
            if (!Path.IsPathRooted(configFile)) {
                configFile = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    configFile
                );
            }
            if (!File.Exists(configFile)) {
                throw new FileNotFoundException($"Config file {configFile} not exists.");
            }
            container.Register(
                Component.For<ISessionFactory>()
                .UsingFactoryMethod(() => {
                    var cfg = new Configuration();
                    cfg.Configure(configFile);
                    return cfg.BuildSessionFactory();
                }).LifestyleSingleton()
            );
        }

        private void RegisterSession(IWindsorContainer container) {
            container.Register(
                Component.For<ISession>().UsingFactoryMethod((kernel, context) => {
                    var sessionFactory = kernel.Resolve<ISessionFactory>();
                    return sessionFactory.OpenSession();
                }).LifestyleTransient()
            );
        }

        private void RegisterRepositories(IWindsorContainer container) {
            container.Register(
                Classes.FromThisAssembly()
                    .Where(type => type.Name.EndsWith("Repository", StringComparison.Ordinal))
                    .WithServiceDefaultInterfaces()
                    .Configure(cfg => cfg.LifestyleSingleton())
            );
        }
    }
}
