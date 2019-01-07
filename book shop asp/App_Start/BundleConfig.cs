using System.Web;
using System.Web.Optimization;

namespace book_shop_asp
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-js").Include(
                      "~/Scripts/bootstrap*"));

            bundles.Add(new StyleBundle("~/bundles/bootstrap-css").Include(
                      "~/Content/bootstrap*"));
        }
    }
}
