using System.Web;
using System.Web.Optimization;

namespace AccountAtAGlance
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://www.asp.net/mvc/tutorials/mvc-4/bundling-and-minification
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Load jQuery from CDN unless in debug mode then load from local file
            var jqueryCdnPath = "//ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js";
            bundles.Add(new ScriptBundle("~/bundles/jquery", jqueryCdnPath).Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/plugins").Include(
                        "~/Scripts/handlebars.js",
                        "~/Scripts/jquery.formatCurrency-1.4.0.js",
                        "~/Scripts/jquery.dataTables.js",
                        "~/Scripts/jquery.dataTables.currencySort.js",
                        "~/Scripts/jquery.flot.js",
                        "~/Scripts/jquery.Scroller-1.0.js",
                        "~/Scripts/jquery.easing.1.3.js",
                        "~/Scripts/raphael-min.js",
                        "~/Scripts/raphael-pie.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.unobtrusive*",
            //            "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                        "~/Scripts/scene.handlebars.helpers.js",
                        "~/Scripts/scene.layoutservice.js",
                        "~/Scripts/scene.statemanager.js",
                        "~/Scripts/scene.dataservice.js",
                        "~/Scripts/scene.tile.formatter.js",
                        "~/Scripts/scene.tile.binder.js",
                        "~/Scripts/scene.tile.renderer.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/themes/base/jquery-ui.css",
                        "~/Content/TileStyles.css",
                        "~/Content/Site.css"));

        }
    }
}