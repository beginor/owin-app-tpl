using NHibernate;
using NHibernate.AspNet.Identity;

namespace Beginor.OwinApp.Data {

    public class ApplicationUserStore : UserStore<ApplicationUser> {
        
        public ApplicationUserStore(ISession context) : base(context) {
        }

    }

}
