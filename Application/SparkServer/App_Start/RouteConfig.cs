using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SparkServer
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Article",
                url: "article/{uniqueURL}",
                defaults: new { controller = "Article", action = "Index", uniqueURL = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Blog",
                url: "blog/{year}/{month}/{uniqueURL}",
                defaults: new { controller = "Blog", action = "BlogArticle", year = UrlParameter.Optional, month = UrlParameter.Optional, uniqueURL = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
