using System.Web.Optimization;

namespace Bookcase.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-3.1.1.intellisense.js",
                "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/jqueryval").Include(
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/js/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/js/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/kendo").Include(
                "~/KendoUI/js/kendo.all.min.js",
                "~/KendoUI/js/kendo.web.min.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/css/bootstrap").Include(
                "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/bundles/css/site").Include(
                "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/css/kendo").Include(
                "~/KendoUI/styles/kendo.common.min.css",
                "~/KendoUI/styles/kendo.default.min.css",
                "~/KendoUI/styles/kendo.default.mobile.min.css"));
        }
    }
}