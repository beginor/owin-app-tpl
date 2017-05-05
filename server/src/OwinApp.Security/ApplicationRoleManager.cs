using System;
using Beginor.OwinApp.Data;
using Microsoft.AspNet.Identity;
using NHibernate.AspNet.Identity;

namespace Beginor.OwinApp.Security {

    public class ApplicationRoleManager : RoleManager<ApplicationRole> {

        public ApplicationRoleManager(RoleStore<ApplicationRole> roleStore) : base(roleStore) {
        }

    }

}
