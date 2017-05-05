using System;
using Beginor.OwinApp.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Cookies;

namespace Beginor.OwinApp.Security {

    public class AuthenticationProvider : CookieAuthenticationProvider {

        public AuthenticationProvider(
            TimeSpan validateInterval
        ) {
            this.OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<UserManager<ApplicationUser>, ApplicationUser>(
                validateInterval: validateInterval,
                regenerateIdentity: (mgr, user) => mgr.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie)
            );
        }

    }

}
