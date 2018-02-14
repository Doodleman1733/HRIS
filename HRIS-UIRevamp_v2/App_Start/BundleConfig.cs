using System.Web;
using System.Web.Optimization;

namespace HRIS_UIRevamp_v2
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                         "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
                        "~/Scripts/jquery-ui.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/fullcalendar").Include(
                        "~/Scripts/moment.min.js",
                        "~/Scripts/fullcalendar.js"));

            bundles.Add(new ScriptBundle("~/bundles/dynatable").Include(
                        "~/Scripts/jquery.dynatable.js",
                        "~/Scripts/jquery.floatThead.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/perfectscroll").Include(
                        "~/Scripts/perfect-scrollbar.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/floatinglabel").Include(
                       "~/Scripts/jquery.floatinglabel.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/shared").Include(
                        "~/Scripts/SharedScript.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootbox.min.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/icheck.min.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/daterangepicker").Include(
                        "~/Scripts/daterangepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/selectize").Include(
                        "~/Scripts/selectize.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/non-responsive.css",
                      "~/Content/site.css",
                      "~/Content/floatinglabel.css"));

            bundles.Add(new StyleBundle("~/Content/dynatable").Include(
                    "~/Content/jquery.dynatable.css",
                    "~/Content/jquery.dynatable-override.css"
                    ));

            bundles.Add(new StyleBundle("~/Content/fullcalendar").Include(
                    "~/Content/fullcalendar.css",
                    "~/Content/fullcalendar-override.css"
                    ));

            bundles.Add(new StyleBundle("~/Content/daterange").Include(
                    "~/Content/daterangepicker.css"));

            bundles.Add(new StyleBundle("~/Content/perfectscrollbar").Include(
                    "~/Content/perfect-scrollbar.css",
                    "~/Content/perfect-scrollbar-override.css"));

            bundles.Add(new StyleBundle("~/Content/selectize").Include(
                      "~/Content/selectize.css"));
        }
    }
}
