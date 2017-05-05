using NHibernate;
using NHibernate.AspNet.Identity;

namespace Beginor.OwinApp.Security {

    public class ApplicationRoleStore : RoleStore<IdentityRole> {

        public ApplicationRoleStore(ISession context) : base(context) {
        }

    }

}
