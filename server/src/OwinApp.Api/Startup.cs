using System;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using Swashbuckle.Application;

namespace Beginor.OwinApp.Api {

    public class Startup {

        public void Configuration(IAppBuilder app) {
            ConfigWebApi(app);
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
            //config.UseWindsorContainer(app.GetWindsorContainer());
            // enable swagger 
            config.EnableSwagger(c => c.SingleApiVersion("v1", "API Help"))
                .EnableSwaggerUi();

            app.UseWebApi(config);
        }

    }
}
