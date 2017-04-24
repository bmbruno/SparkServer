using System.Web.Optimization;

namespace SparkServer
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/html5shiv").Include(
                        "~/Scripts/html5shiv.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/Styles/reset.css",
                        "~/Content/Styles/fonts/fonts.css",
                        "~/Content/Styles/fonts/font-awesome.min.css",
                        "~/Content/Styles/default.css",
                        "~/Content/Styles/highlightjs/github.css"));

            bundles.Add(new StyleBundle("~/Content/ie").Include(
                        "~/Content/Styles/ie.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.js"));


            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                        "~/Scripts/default.js"));

            BundleTable.EnableOptimizations = false;
        }
    }
}
