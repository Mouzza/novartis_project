using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;


namespace JPP.UI.Web.MVC
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();      
            config.Routes.MapHttpRoute(
                name: "ApiModule",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

       }
    }
}
