using System.Web;
using System.Web.Optimization;

namespace EIS {
    public class BundleConfig {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles) {

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/Kendo/kendo.common.*",
                "~/Content/Kendo/kendo.default.*",
                "~/Content/site.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/Libs/jquery-1.8.*",
                "~/Scripts/Libs/jquery.layout-latest.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                "~/Scripts/Libs/kendo.web.*"
            ));

            bundles.Add(new ScriptBundle("~/bundles/date").Include(
                "~/Scripts/Libs/date.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/pages").Include("~/Scripts/*.js"));

            // Clear all items from the ignore list to allow minified CSS and JavaScript files in debug mode
            bundles.IgnoreList.Clear();

            // Add back the default ignore list rules sans the ones which affect minified files and debug mode
            bundles.IgnoreList.Ignore("*.intellisense.js");
            bundles.IgnoreList.Ignore("*-vsdoc.js");
            bundles.IgnoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);

        }
    }
}