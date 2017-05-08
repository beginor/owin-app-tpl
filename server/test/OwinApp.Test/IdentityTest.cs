using NUnit.Framework;
using System;
using System.Linq;
using Microsoft.AspNet.Identity;
using NHibernate;
using NHibernate.Linq;
using Beginor.OwinApp.Security;
using NHibernate.AspNet.Identity;

namespace Beginor.OwinApp.Test {

    [TestFixture]
    public class IdentityTest : WindsorTest {

        [Test]
        public void CanQueryUsers() {
            using (var session = Container.Resolve<ISession>()) {
                var users = session.Query<IdentityUser>().ToList();
                Assert.True(users.Count >= 0);
            }
        }
    }
}
