using Beginor.OwinApp.Data;
using Microsoft.AspNet.Identity;

namespace Beginor.OwinApp.Security {

    public class ApplicationUserManager : UserManager<ApplicationUser> {

        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store) {
        }

    }

}