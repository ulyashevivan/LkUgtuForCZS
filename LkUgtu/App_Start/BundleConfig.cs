using System.Web;
using System.Web.Optimization;

namespace LkUgtu.App_Start
{
    public class BundleConfig
    {
         public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.2.4.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-ui/ui-bootstrap.min.js"
                         ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/bootstrap-datepicker.min.js",
                      "~/Scripts/locales/bootstrap-datepicker.ru.min.js",
                      "~/Scripts/bootstrap3-typeahead.min.js"));
 
            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/bootstrap.min.css", 
                 "~/Content/bootstrap-theme.min.css",
                 "~/Content/ui-bootstrap-csp.css",
                 "~/Content/bootstrap-datepicker.min.css",
                      "~/Content/site.css"));
        }
    }
}