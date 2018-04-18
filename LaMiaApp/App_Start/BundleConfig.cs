using System.Web;
using System.Web.Optimization;

namespace LaMiaApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/typeahead.bundle.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/fullcalendar").Include(
                        "~/Scripts/lib/moment.min.js",
                        "~/Scripts/fullcalendar.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/datetimepicker").Include(
                        "~/Scripts/bootstrap-datetimepicker.min.js"
                        ));

            // Utilizzare la versione di sviluppo di Modernizr per eseguire attività di sviluppo e formazione. Successivamente, quando si è
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/typeahead.css"));

            bundles.Add(new StyleBundle("~/Content/css/fullcalendar").Include(
                       "~/Content/fullcalendar.css"));
            bundles.Add(new StyleBundle("~/Content/css/datetimepicker").Include(
                       "~/Content/_bootstrap-datetimepicker.less"));


        }
    }
}
