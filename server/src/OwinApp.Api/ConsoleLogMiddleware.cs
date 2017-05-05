using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beginor.OwinApp.Api {

    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class ConsoleLogMiddleware {

        private AppFunc next;

        public void Initialize(AppFunc next) {
            this.next = next;
        }

        public async Task Invoke(IDictionary<string, object> env) {
            await next.Invoke(env);
            var statusCode = (int)env["owin.ResponseStatusCode"];
            var color = ConsoleColor.DarkGreen;
            if (statusCode > 400) {
                color = ConsoleColor.Red;
            }
            Console.ForegroundColor = color;
            Console.WriteLine("{0} {1} {2}", statusCode, env["owin.RequestMethod"], env["owin.RequestPath"]);
        }

    }

}
