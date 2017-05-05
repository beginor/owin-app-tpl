using NHibernate;
using NHibernate.AspNet.Identity;

namespace Beginor.OwinApp.Security {

    public class ApplicationUserStore : UserStore<IdentityUser> {
        
        public ApplicationUserStore(ISession context) : base(context) {
        }

    }

}
