using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Reques
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "InicioS", action = "Iniciar", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "SignUp",
                url: "signUp",
                defaults: new { controller = "InicioS", action = "SignUp", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ProjectRequirements",
                url: "projectRequirements",
                defaults: new { controller = "InicioS", action = "ProjectRequirements", id = UrlParameter.Optional }
            );
        }
    }
}
