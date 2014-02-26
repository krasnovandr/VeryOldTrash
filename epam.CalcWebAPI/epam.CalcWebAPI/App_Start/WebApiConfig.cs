using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using epam.CalcWebAPI.Services;
using Microsoft.Practices.Unity;

namespace epam.CalcWebAPI
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
            var container = new UnityContainer();
            container.RegisterType<IServiceCalculatorMemory, ServiceCalculatorMemory>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

        }
    }
}
