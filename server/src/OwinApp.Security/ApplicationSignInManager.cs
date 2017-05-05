using System;
using Beginor.OwinApp.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Beginor.OwinApp.Security {

    public class ApplicationSignInManager : SignInManager<ApplicationUser, string> {

        public ApplicationSignInManager(
            UserManager<ApplicationUser> userManager,
            IAuthenticationManager authenticationManager
        ) : base(userManager, authenticationManager) { }

    }

}
