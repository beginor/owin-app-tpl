using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Beginor.OwinApp.Api;
using Microsoft.Owin.Builder;
using Nowin;

namespace Beginor.OwinApp.Entry {

    public class Program {

        public static void Main(string[] args) {
            // Define listening ip and port;
            const string ip = "0.0.0.0";
            const int port = 4610;
            // start the server;
            using (var server = BuildNowinServer(ip, port)) {
                var serverRef = new WeakReference<INowinServer>(server);
                Task.Run(() => {
                    INowinServer nowinServer;
                    if (serverRef.TryGetTarget(out nowinServer)) {
                        nowinServer.Start();
                    }
                });
                var baseAddress = "http://" + ip + ":" + port + "/";
                var msg = $"Nowin server listening {baseAddress}, press ENTER to exit.";
                Console.WriteLine(msg);
                // exit when user press enter.
                Console.ReadLine();
            }
        }

        private static INowinServer BuildNowinServer(string ip, int port) {
            // create a new AppBuilder
            var appBuilder = new AppBuilder();
            // init nowin's owin server factory.
            OwinServerFactory.Initialize(appBuilder.Properties);
            var startup = new Startup();
            startup.Configuration(appBuilder);
            // build server
            var serverBuilder = new ServerBuilder();
            var capabilities = appBuilder.Properties[OwinKeys.ServerCapabilitiesKey];
            serverBuilder
                .SetAddress(IPAddress.Parse(ip))
                .SetPort(port)
                .SetOwinApp(appBuilder.Build())
                .SetOwinCapabilities((IDictionary<string, object>)capabilities);
            return serverBuilder.Build();
        }

    }

}
