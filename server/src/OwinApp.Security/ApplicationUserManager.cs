using Microsoft.AspNet.Identity;
using NHibernate.AspNet.Identity;

namespace Beginor.OwinApp.Security {

    public class ApplicationUserManager : UserManager<IdentityUser> {

        public ApplicationUserManager(IUserStore<IdentityUser> store) : base(store) {
        }

    }

}