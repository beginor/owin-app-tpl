using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Core;

namespace Beginor.OwinApp.Logic {

    public class Installer : IWindsorInstaller {

        public void Install(IWindsorContainer container, IConfigurationStore store) {
            container.Register(
                Component.For<IStartable>()
                    .ImplementedBy<ModelMappings>().Named(typeof(ModelMappings).FullName)
                    .LifestyleTransient(),
                 Classes.FromThisAssembly()
                    .Where(type => type.Name.EndsWith("Manager", StringComparison.Ordinal))
                    .WithServiceDefaultInterfaces()
                    .Configure(cfg => cfg.LifestyleSingleton())
            );
        }

    }

}
