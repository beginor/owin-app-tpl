using System;
using Beginor.OwinApp.Data;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using NHibernate.AspNet.Identity;

namespace Beginor.OwinApp.Security {

    public class Installer : IWindsorInstaller {

        public void Install(
            IWindsorContainer container,
            IConfigurationStore store
        ) {
            container.Register(
                Component.For<IIdentityMessageService>()
                    .ImplementedBy<EmailService>()
                    .LifestyleTransient()
                    .Named("emailService"),
                Component.For<IIdentityMessageService>()
                    .ImplementedBy<SmsService>()
                    .LifestyleTransient()
                    .Named("smsService"),
                Component.For<UserStore<ApplicationUser>>()
                    .ImplementedBy<ApplicationUserStore>()
                    .LifestyleTransient(),
                Component.For<RoleStore<ApplicationRole>>()
                    .ImplementedBy<ApplicationRoleStore>()
                    .LifestyleTransient(),
                Component.For<UserManager<ApplicationUser>>()
                    .ImplementedBy<ApplicationUserManager>()
                    .LifestyleTransient()
                    .DependsOn(
                        Dependency.OnComponent("emailService", "emailService"),
                        Dependency.OnComponent("smsService", "smsService")
                    ),
                Component.For<RoleManager<ApplicationRole>>()
                    .ImplementedBy<ApplicationRoleManager>()
                    .LifestyleTransient(),
                Component.For<SignInManager<ApplicationUser, string>>()
                    .ImplementedBy<ApplicationSignInManager>()
                    .LifestyleTransient()
            );
        }

    }

}
