using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using NHibernate.AspNet.Identity;

namespace Beginor.OwinApp.Security {

    public class ApplicationSignInManager : SignInManager<IdentityUser, string> {

        public ApplicationSignInManager(
            UserManager<IdentityUser> userManager,
            IAuthenticationManager authenticationManager
        ) : base(userManager, authenticationManager) { }

    }

}
