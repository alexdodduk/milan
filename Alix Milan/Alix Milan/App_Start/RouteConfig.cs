using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Alix_Milan
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                   "Category",
                   "KitHire/Category/{categoryName}",
                   new { controller = "KitHire", action = "Category" }
               );

            routes.MapRoute(
                   "Kit",
                   "KitHire/Kit/{kitName}",
                   new { controller = "KitHire", action = "Kit" }
               );

            routes.MapRoute(
                   "KitItem",
                   "KitHire/KitItem/{kitItemName}",
                   new { controller = "KitHire", action = "KitItem" }
               );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
