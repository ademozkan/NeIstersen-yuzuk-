using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NeIstersen.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                //birden fazla aynı isimde controller olasını saglıyorum.Adminin home controlırı digerlerinin home controllerı gibi.
                namespaces: new[] { "NeIstersen.UI.Controllers" }
            );
        }
    }
}
