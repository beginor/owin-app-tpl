using NHibernate;
using NHibernate.AspNet.Identity;

namespace Beginor.OwinApp.Data {

    public class ApplicationRoleStore : RoleStore<ApplicationRole> {

        public ApplicationRoleStore(ISession context) : base(context) {
        }

    }

}
