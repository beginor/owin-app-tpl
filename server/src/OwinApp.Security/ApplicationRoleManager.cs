using Microsoft.AspNet.Identity;
using NHibernate.AspNet.Identity;

namespace Beginor.OwinApp.Security {

    public class ApplicationRoleManager : RoleManager<IdentityRole> {

        public ApplicationRoleManager(RoleStore<IdentityRole> roleStore) : base(roleStore) {
        }

    }

}
