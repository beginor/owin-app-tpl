using System;
using System.Diagnostics;
using System.IO;
using System.Web.Http;
using System.Web.Http.Cors;
using Beginor.Owin.StaticFile;
using Beginor.Owin.WebApi.Windsor;
using Beginor.Owin.Windsor;
using Beginor.OwinApp.Security;
using Castle.MicroKernel.Registration;
using Castle.Windsor.Installer;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Logging;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using Swashbuckle.Application;

[assembly: Microsoft.Owin.OwinStartup(typeof(Beginor.OwinApp.Api.Startup))]

namespace Beginor.OwinApp.Api {

    public class Startup {

        public void Configuration(IAppBuilder app) {
            // config windsor
            ConfigWindsor(app);
            // console log middle ware
            ConfigConsoleLogMiddleware(app);
            // owin logger factory
            ConfigLogger(app);
            // config static
            ConfigStaticFile(app);
            // identity and cookie auth, not used now.
            ConfigIdentity(app);
            // config web api
            ConfigWebApi(app);
        }

        private void ConfigWindsor(IAppBuilder app) {
            var windsorConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "windsor.config");
            app.UseWindsorContainer(windsorConfigPath);
            var container = app.GetWindsorContainer();
            container.Install(FromAssembly.This());
            app.UseWindsorMiddleWare();
        }

        [Conditional("DEBUG")]
        private void ConfigConsoleLogMiddleware(IAppBuilder app) {
            app.Use(new ConsoleLogMiddleware());
        }

        private void ConfigLogger(IAppBuilder app) {
            app.SetLoggerFactory(
                app.GetWindsorContainer().Resolve<ILoggerFactory>()
            );
        }

        [Conditional("DEBUG")]
        private void ConfigStaticFile(IAppBuilder app) {
            app.UseStaticFile(
                app.GetWindsorContainer().Resolve<StaticFileMiddlewareOptions>()
            );
        }

        private void ConfigIdentity(IAppBuilder app) {
            var container = app.GetWindsorContainer();
            container.Register(
                Component.For<IAuthenticationManager>().FromOwinContext().LifestyleTransient()
            );
            var dataProtectionProvider = container.Resolve<IDataProtectionProvider>();
            app.SetDataProtectionProvider(dataProtectionProvider);

            app.UseCookieAuthentication(new CookieAuthenticationOptions {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                Provider = new AuthenticationProvider(TimeSpan.FromMinutes(30))
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
        }

        private void ConfigWebApi(IAppBuilder app) {
            var config = new HttpConfiguration();
            // remove xml formatter;
            var xmlFormatter = config.Formatters.XmlFormatter;
            config.Formatters.Remove(xmlFormatter);
            // config json formatter
            var jsonFormatter = config.Formatters.JsonFormatter;
            jsonFormatter.Indent = true;
            jsonFormatter.UseDataContractJsonSerializer = false;
            jsonFormatter.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            // always include error
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            // config cors
            var policy = new EnableCorsAttribute(
                origins: "*",
                headers: "*",
                methods: "*"
            ) {
                SupportsCredentials = true
            };
            config.EnableCors(policy);
            // map http attr routes
            config.MapHttpAttributeRoutes();
            // default api route
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "rest/{controller}/{id}"
            );
            // use windsor container
            config.UseWindsorContainer(app.GetWindsorContainer());
            // enable swagger 
            config.EnableSwagger(c => c.SingleApiVersion("v1", "API Help"))
                .EnableSwaggerUi();

            app.UseWebApi(config);
        }

    }
}
