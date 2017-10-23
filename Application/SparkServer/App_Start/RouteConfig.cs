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

            //
            // Articles
            //

            routes.MapRoute(
                name: "ArticleSample",
                url: "article/sample",
                defaults: new { controller = "Article", action = "Sample" }
            );

            routes.MapRoute(
                name: "Article",
                url: "article/{uniqueURL}",
                defaults: new { controller = "Article", action = "Article", uniqueURL = UrlParameter.Optional }
            );

            //
            // Blogs
            //

            routes.MapRoute(
                name: "BlogSample",
                url: "blog/sample",
                defaults: new { controller = "Blog", action = "Sample" }
            );

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
            // Videos
            //

            routes.MapRoute(
                name: "Videos",
                url: "videos",
                defaults: new { controller = "Home", action = "Videos" }
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
