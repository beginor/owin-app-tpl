using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Cookies;
using NHibernate.AspNet.Identity;

namespace Beginor.OwinApp.Security {

    public class AuthenticationProvider : CookieAuthenticationProvider {

        public AuthenticationProvider(
            TimeSpan validateInterval
        ) {
            this.OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<UserManager<IdentityUser>, IdentityUser>(
                validateInterval: validateInterval,
                regenerateIdentity: (mgr, user) => mgr.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie)
            );
        }

    }

}
