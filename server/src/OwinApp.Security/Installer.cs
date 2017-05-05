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
                Component.For<UserStore<IdentityUser>>()
                    .ImplementedBy<ApplicationUserStore>()
                    .LifestyleTransient(),
                Component.For<RoleStore<IdentityRole>>()
                    .ImplementedBy<ApplicationRoleStore>()
                    .LifestyleTransient(),
                Component.For<UserManager<IdentityUser>>()
                    .ImplementedBy<ApplicationUserManager>()
                    .LifestyleTransient()
                    .DependsOn(
                        Dependency.OnComponent("emailService", "emailService"),
                        Dependency.OnComponent("smsService", "smsService")
                    ),
                Component.For<RoleManager<IdentityRole>>()
                    .ImplementedBy<ApplicationRoleManager>()
                    .LifestyleTransient(),
                Component.For<SignInManager<IdentityUser, string>>()
                    .ImplementedBy<ApplicationSignInManager>()
                    .LifestyleTransient()
            );
        }

    }

}
