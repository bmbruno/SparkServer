﻿using System.Web.Mvc;
using System.Web.Routing;

namespace SparkServer
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //
            // Articles
            //

            routes.MapRoute(
                name: "Article",
                url: "article/{uniqueURL}",
                defaults: new { controller = "Article", action = "Article", uniqueURL = UrlParameter.Optional }
            );

            //
            // Blogs
            //

            routes.MapRoute(
                name: "BlogTags",
                url: "blog/tag/{tagName}",
                defaults: new { controller = "Blog", action = "ListByTag" }
            );

            routes.MapRoute(
                name: "BlogIndex",
                url: "blog/{year}/{month}",
                defaults: new { controller = "Blog", action = "Index", year = UrlParameter.Optional, month = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "BlogArticle",
                url: "blog/{year}/{month}/{uniqueURL}",
                defaults: new { controller = "Blog", action = "BlogArticle" }
            );

            //
            // Resources
            //

            routes.MapRoute(
                name: "Resources",
                url: "resources",
                defaults: new { controller = "Home", action = "Resources" }
            );

            //
            // Admin
            //

            routes.MapRoute(
                name: "Admin",
                url: "admin/{action}",
                defaults: new { controller = "Admin", action = "Index" }
            );

            //
            // Misc
            //

            routes.MapRoute(
                name: "About",
                url: "about",
                defaults: new { controller = "Home", action = "About" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
