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

            /******
             routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
             * 
            routes.MapRoute(
                "Blog",                                           // Route name
                "Archive/{entryDate}",                            // URL with parameters
                new { controller = "Archive", action = "Entry" }  // Parameter defaults
            );
             * */

            config.Routes.MapHttpRoute(
                name: "ApiModule",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


          
        //    config.Routes.MapHttpRoute("DefaultApiWithId", "Api/{controller}/{id}", new { id = RouteParameter.Optional }, new { id = @"\d+" });
        //    config.Routes.MapHttpRoute("DefaultApiWithAction", "Api/{controller}/{action}");
       }
    }
}
