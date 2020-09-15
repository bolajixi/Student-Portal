using System.Web;
using System.Web.Optimization;

namespace Student_Portal
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/toastr.js",
                      "~/Scripts/bootbox.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-spacelab.css",
                      "~/Content/toastr.css",
                      "~/Content/site.css"));

            #region Template design
            bundles.Add(new ScriptBundle("~/template/js").Include(
                        "~/Scripts/vendor/jquery-2.2.4.min.js",
                        "~/Scripts/vendor/modernizr-2.8.3.min.js",
                        "~/Scripts/popper.min.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/owl.carousel.min.js",
                        "~/Scripts/metisMenu.min.js",
                        "~/Scripts/jquery.slimscroll.min.js",
                        "~/Scripts/jquery.slicknav.min.js",
                        "~/Scripts/line-chart.js",
                        "~/Scripts/pie-chart.js",
                        "~/Scripts/plugins.js",
                        "~/Scripts/scripts.js"));

            bundles.Add(new StyleBundle("~/template/css").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/font-awesome.min.css",
                      "~/Content/css/themify-icons.css",
                      "~/Content/css/metisMenu.css",
                      "~/Content/css/owl.carousel.min.css",
                      "~/Content/css/slicknav.min.css",
                      "~/Content/css/typography.css",
                      "~/Content/css/default-css.css",
                      "~/Content/css/styles.css",
                      "~/Content/css/responsive.css"));

            bundles.Add(new ScriptBundle("~/template2/js").Include(
                        "~/Content2/lib/jquery/jquery.min.js",
                        "~/Content2/lib/jquery/jquery-migrate.min.js",
                        "~/Content2/lib/popper/popper.min.js",
                        "~/Content2/lib/bootstrap/js/bootstrap.min.js",
                        "~/Content2/lib/easing/easing.min.js",
                        "~/Content2/lib/owlcarousel/owl.carousel.min.js",
                        "~/Content2/lib/scrollreveal/scrollreveal.min.js",
                        "~/Content2/contactform/contactform.js",
                        "~/Content2/js/main.js"));

            bundles.Add(new StyleBundle("~/template2/css").Include(
                      "~/Content2/lib/bootstrap/css/bootstrap.min.css",
                      "~/Content2/lib/font-awesome/css/font-awesome.min.css",
                      "~/Content2/lib/animate/animate.min.css",
                      "~/Content2/lib/ionicons/css/ionicons.min.css",
                      "~/Content2/lib/owlcarousel/assets/owl.carousel.min.css",
                      "~/Content2/css/style.css",
                      "~/Content2/lib/bootstrap/css/bootstrap.min.css"));

            #endregion
        }
    }
}
