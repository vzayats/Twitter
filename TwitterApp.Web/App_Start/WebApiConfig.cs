using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace TwitterApp.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new {controller = "messages", action = "GetMessages", id = RouteParameter.Optional}
            );

            config.Filters.Add(new AuthorizeAttribute());
        }
    }
}
