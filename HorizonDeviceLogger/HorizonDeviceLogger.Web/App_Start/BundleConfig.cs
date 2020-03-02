using System.Web;
using System.Web.Optimization;

namespace HorizonDeviceLogger.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

           bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Content/AdminLteTheme/dist/js/adminlte.js",
                      "~/Content/AdminLteTheme/plugins/chart.js/Chart.min.js",
                      "~/Content/AdminLteTheme/dist/js/pages/dashboard2.js",
                      "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/adminjs").Include(
                "~/Content/AdminLteTheme/plugins/jquery/jquery.min.js",
                "~/Content/AdminLteTheme/plugins/jquery-ui/jquery-ui.min.js",
                "~/Content/AdminLteTheme/plugins/bootstrap/js/bootstrap.bundle.min.js",
                "~/Scripts/jquery.validate*",
                "~/Content/AdminLteTheme/plugins/datatables/jquery.dataTables.js",
                "~/Content/AdminLteTheme/plugins/datatables-bs4/js/dataTables.bootstrap4.js",
                "~/Content/AdminLteTheme/plugins/chart.js/Chart.min.js",
                "~/Content/AdminLteTheme/plugins/daterangepicker/daterangepicker.js",
                "~/Content/AdminLteTheme/dist/js/adminlte.js",
                "~/Content/AdminLteTheme/dist/js/pages/dashboard2.js"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/bootstrap.bundle.min.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/admincss").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css",
                      "~/Content/AdminLteTheme/plugins/datatables-bs4/css/dataTables.bootstrap4.css",
                      "~/Content/AdminLteTheme/plugins/fontawesome-free/css/all.min.css",
                      "~/Content/AdminLteTheme/dist/css/adminlte.min.css"));           

            //BundleTable.EnableOptimizations = false;
        }
    }
}
