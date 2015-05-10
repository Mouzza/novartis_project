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
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

          
        //    config.Routes.MapHttpRoute("DefaultApiWithId", "Api/{controller}/{id}", new { id = RouteParameter.Optional }, new { id = @"\d+" });
        //    config.Routes.MapHttpRoute("DefaultApiWithAction", "Api/{controller}/{action}");
       }
    }
}
