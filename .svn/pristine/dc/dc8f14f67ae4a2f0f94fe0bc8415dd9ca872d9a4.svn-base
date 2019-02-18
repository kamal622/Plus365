using System.Web;
using System.Web.Optimization;

namespace _365Plus.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.IgnoreList.Clear();
            //BundleTable.EnableOptimizations = false;
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.min.js",
                        "~/Scripts/jquery.blockUI.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/ajax").Include(
                "~/Scripts/jquery.unobtrusive-ajax.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/angular.min.js",
                 "~/Scripts/lodash.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                "~/Scripts/Kendo/2018.3.1017/kendo.core.min.js",
                "~/Scripts/Kendo/2018.3.1017/kendo.ui.core.min.js",
                "~/Scripts/Kendo/2018.3.1017/kendo.angular.min.js"
                ));

            bundles.Add(new StyleBundle("~/Content/kendo").Include(
                      "~/Content/Kendo/2018.3.1017/kendo.common.min.css",
                      "~/Content/Kendo/2018.3.1017/kendo.bootstrap.min.css",
                      "~/Content/Kendo/2018.3.1017/kendo.bootstrap.mobile.min.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
                "~/Scripts/DataTables/jquery.dataTables.js",
                     "~/Scripts/DataTables/dataTables.bootstrap4.js"));

            bundles.Add(new StyleBundle("~/Content/datatable").Include(
                     "~/Content/DataTables/css/jquery.dataTables.css",
                     "~/Content/DataTables/css/dataTables.bootstrap4.css"));
        }
    }
}

