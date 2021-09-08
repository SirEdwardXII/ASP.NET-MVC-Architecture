using System.Web;
using System.Web.Optimization;

namespace DentalTracks.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // scripts

            bundles.Add(new ScriptBundle("~/scripts/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/scripts/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/scripts/layout").Include(
                      "~/Scripts/layout/site-layout.js"));

            bundles.Add(new ScriptBundle("~/scripts/createContact").Include(
                      "~/Scripts/Contact/create-contact.js"));

            bundles.Add(new ScriptBundle("~/scripts/viewContact").Include(
                    "~/Scripts/Contact/contact.js"));
            // styles

            bundles.Add(new StyleBundle("~/Content/style").Include(
                      "~/content/style/font-awesome.css",
                      "~/Content/style/dentalTracks.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                      "~/Content/bootstrap/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/home").Include(
                 "~/Content/style/home.css"));

            bundles.Add(new StyleBundle("~/Content/contact").Include(
                 "~/Content/style/contact.css"));
        }
    }
}
