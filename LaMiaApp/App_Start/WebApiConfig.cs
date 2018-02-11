using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace LaMiaApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //this for formatting the JSON Result with the CamelCase
            //var setting = config.Formatters.JsonFormatter.SerializerSettings;
            //setting.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //setting.Formatting = Newtonsoft.Json.Formatting.Indented;

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);




            config.MapHttpAttributeRoutes();
            

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
