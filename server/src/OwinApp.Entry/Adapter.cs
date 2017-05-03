using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Beginor.OwinApp.Api;
using Microsoft.Owin.Builder;

namespace Beginor.OwinApp.Entry {

    /// <summary>
    /// Tinyfox/Jexus Adapter.
    /// </summary>
    public class Adapter {

        readonly Func<IDictionary<string, object>, Task> owinApp;

        public Adapter() {
            var app = new AppBuilder();
            var startup = new Startup();
            startup.Configuration(app);
            owinApp = app.Build();
        }

        public Task OwinMain(IDictionary<string, object> env) {
            if (owinApp == null) {
                return null;
            }
            return owinApp(env);
        }
    }

}
