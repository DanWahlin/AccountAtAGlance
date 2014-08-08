using AccountAtAGlance.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AccountAtAGlance
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var mappingContainer = IoCMappingContainer.GetInstance();
            config.DependencyResolver = new IoCScopeContainer(mappingContainer);

        }
    }
}
