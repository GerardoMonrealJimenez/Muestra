using System.Web;
using System.Web.Optimization;

namespace AssistanceOnlineWeb
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/assets/plugins/bootstrap/css/bootstrap.min.css",
                  "~/assets/css/main.css",
                 "~/assets/css/font-awesome.min.css",
                 "~/assets/css/animate.css",
                 "~/assets/plugins/jvectormap/css/jquery-jvectormap-1.2.2.css",
                 "~/assets/plugins/todo/css/todos.css",
                 "~/assets/plugins/morris/css/morris.css"));

            bundles.Add(new StyleBundle("~/Content/SingUp/css").Include(
                     "~/assets/plugins/bootstrap/css/bootstrap.min.css",
                     "~/assets/css/font-awesome.min.css",
                     "~/assets/css/animate.css",
                     "~/assets/css/main.css"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/assets/js/jquery-1.10.2.min.js",
                      "~/assets/plugins/bootstrap/js/bootstrap.min.js",
                      "~/assets/plugins/waypoints/waypoints.min.js",
                      "~/assets/js/application.js",
                      "~/assets/plugins/countTo/jquery.countTo.js",
                      "~/assets/plugins/weather/js/skycons.js",
                      "~/assets/plugins/flot/js/jquery.flot.min.js",
                      "~/assets/plugins/flot/js/jquery.flot.resize.min.js",
                      "~/assets/plugins/flot/js/jquery.flot.canvas.min.js",
                      "~/assets/plugins/flot/js/jquery.flot.image.min.js",
                      "~/assets/plugins/flot/js/jquery.flot.categories.min.js",
                      "~/assets/plugins/flot/js/jquery.flot.crosshair.min.js",
                      "~/assets/plugins/flot/js/jquery.flot.errorbars.min.js",
                      "~/assets/plugins/flot/js/jquery.flot.fillbetween.min.js",
                      "~/assets/plugins/flot/js/jquery.flot.navigate.min.js",
                      "~/assets/plugins/flot/js/jquery.flot.pie.min.js",
                      "~/assets/plugins/flot/js/jquery.flot.selection.min.js",
                      "~/assets/plugins/flot/js/jquery.flot.stack.min.js",
                      "~/assets/plugins/flot/js/jquery.flot.symbol.min.js",
                      "~/assets/plugins/flot/js/jquery.flot.threshold.min.js",
                      "~/assets/plugins/flot/js/jquery.colorhelpers.min.js",
                      "~/assets/plugins/flot/js/jquery.flot.time.min.js",
                      "~/assets/plugins/flot/js/jquery.flot.example.js",
                      "~/assets/plugins/morris/js/morris.min.js",
                      "~/assets/plugins/morris/js/raphael.2.1.0.min.js",
                      "~/assets/plugins/jvectormap/js/jquery-jvectormap-1.2.2.min.js",
                      "~/assets/plugins/jvectormap/js/jquery-jvectormap-world-mill-en.js",
                      "~/assets/plugins/todo/js/todos.js",
                      "~/assets/js/modernizr-2.6.2.min.js",
                      "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/SingUp/js").Include(
                                        "~/assets/js/jquery-1.10.2.min.js",
                                        "~/assets/plugins/bootstrap/js/bootstrap.min.js",
                                        "~/assets/plugins/waypoints/waypoints.min.js",
                                        "~/assets/plugins/nanoScroller/jquery.nanoscroller.min.js",
                                        "~/assets/js/application.js",
                                        "~/assets/js/modernizr-2.6.2.min.js"));
        }
    }
}
