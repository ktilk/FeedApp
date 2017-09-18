using System.Web.Optimization;

namespace FeedAppClient
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-route.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        "~/App/app.js",
                        "~/App/data.js",
                        "~/App/Controllers/articleController.js",
                        "~/App/Services/articleService.js"));

            bundles.Add(new ScriptBundle("~/bundles/foundation6").Include(
                      "~/Assets/js/vendor/jquery.js",
                      "~/Assets/js/vendor/what-input.js",
                      "~/Assets/js/vendor/foundation.js",
                      "~/Assets/js/app.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Assets/css/foundation.css",
                      "~/Assets/css/app.css"));
        }
    }
}