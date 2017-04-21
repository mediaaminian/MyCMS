using System.Web.Optimization;

namespace MyCMS.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region JavaScripts Bundles


            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                   "~/Scripts/jquery-2.1.3.js",
                   //"~/Scripts/jquery-{version}.js",
                   "~/Scripts/jquery-migrate-{version}.js",
                   "~/Scripts/jquery.unobtrusive-ajax.js",
                   "~/Scripts/load.js",
                   "~/Scripts/jquery.validate.js"
                   ));


            bundles.Add(new ScriptBundle("~/bundles/scripts/kendo").Include(
                        "~/Scripts/kendo/2013.2.918/kendo.web.min.js",
                        "~/Scripts/kendo/2013.2.918/kendo.aspnetmvc.min.js",
                        //"~/Scripts/kendo/2013.2.918/kendo.all.min.js",
                        "~/Scripts/kendo.modernizr.custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/plugins").Include(
                "~/Content/js/plugins.js"));

            bundles.Add(new ScriptBundle("~/bundles/AngularJs").Include(
                "~/Content/js/Angularjs/angular.min.js",
                "~/Content/js/Angularjs/angular-animate.min.js",
                "~/Scripts/loading-bar.js",
                "~/Content/js/Controller/LoadingController.js",
                "~/Content/js/Controller/serviceBaseAngular.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/functions").Include(
                "~/Content/js/functions.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                "~/Scripts/jquery-ui-{version}.js",
                "~/Scripts/PersianCalender/calendar.js",
                "~/Scripts/PersianCalender/jquery.ui.datepicker-cc-fa.js",
                "~/Scripts/PersianCalender/jquery.ui.datepicker-cc.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryuitools").Include(
                "~/Scripts/PersianCalender/calendar.js",
                "~/Scripts/PersianCalender/jquery.ui.datepicker-cc-fa.js",
                "~/Scripts/PersianCalender/jquery.ui.datepicker-cc.js",
                "~/Scripts/jquery-ui-1.10.2.autocomplete.js",
                "~/Scripts/jquery-validator-combined.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/sitejs").Include(
                "~/Scripts/TweenMax.min.js",
                "~/Scripts/myscript.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/jqueryform").Include(
                "~/Scripts/jquery.form.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap/bootstrap-rtl.js",
                "~/Scripts/noty/jquery.noty.js",
                "~/Scripts/noty/layouts/top.js",
                "~/Scripts/noty/layouts/topCenter.js",
                "~/Scripts/noty/themes/default.js"
                ));



            bundles.Add(new ScriptBundle("~/bundles/froala").Include(
                "~/Scripts/froala_editor.min.js"
                ));


            bundles.Add(new ScriptBundle("~/bundles/froala/plugins").Include(
                //"~/Scripts/plugins/block_styles.min.js",
                //"~/Scripts/plugins/colors.min.js",
                //"~/Scripts/plugins/file_upload.min.js",
                //"~/Scripts/plugins/font_family.min.js",
                //"~/Scripts/plugins/font_size.min.js",
                //"~/Scripts/plugins/lists.min.js",
                //"~/Scripts/plugins/media_manager.min.js",
                //"~/Scripts/plugins/tables.min.js",
                //"~/Scripts/plugins/video.min.js"
                "~/Scripts/plugins/align.min.js",
                "~/Scripts/plugins/code_beautifier.min.js",
                "~/Scripts/plugins/code_view.min.js",
                "~/Scripts/plugins/colors.min.js",
                "~/Scripts/plugins/draggable.min.js",
                "~/Scripts/plugins/emoticons.min.js",
                "~/Scripts/plugins/font_size.min.js",
                "~/Scripts/plugins/font_family.min.js",
                "~/Scripts/plugins/image.min.js",
                "~/Scripts/plugins/file.min.js",
                "~/Scripts/plugins/image_manager.min.js",
                "~/Scripts/plugins/line_breaker.min.js",
                "~/Scripts/plugins/link.min.js",
                "~/Scripts/plugins/lists.min.js",
                "~/Scripts/plugins/paragraph_format.min.js",
                "~/Scripts/plugins/paragraph_style.min.js",
                "~/Scripts/plugins/video.min.js",
                "~/Scripts/plugins/table.min.js",
                "~/Scripts/plugins/url.min.js",
                "~/Scripts/plugins/entities.min.js",
                "~/Scripts/plugins/char_counter.min.js",
                "~/Scripts/plugins/inline_style.min.js",
                "~/Scripts/plugins/save.min.js",
                "~/Scripts/plugins/fullscreen.min.js",
                "~/Scripts/plugins/quote.min.js",
                "~/Scripts/languages/fa.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/redactor").Include(
                "~/Scripts/redactor/redactor.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/admin").Include(
                "~/Scripts/chosen/chosen.jquery.js",
                "~/Scripts/adminjs.js"
                ));

            #endregion

            #region CSS Bundles

            bundles.Add(new StyleBundle("~/Content/css/kendo").Include(
            "~/Content/kendo/2013.2.918/kendo.common.min.css",
            "~/Content/kendo/2013.2.918/kendo.rtl.min.css",
            "~/Content/kendo/2013.2.918/kendo.Bootstrap.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/header/css").Include(
                "~/Content/css/bootstrap.css",
                "~/Content/css/bootstrap-rtl.css",
                "~/Content/css/style.css",
                "~/Content/css/style-rtl.css",
                "~/Content/css/dark.css",
                "~/Content/css/dark-rtl.css",
                "~/Content/css/font-icons.css",
                "~/Content/css/font-icons-rtl.css",
                "~/Content/css/animate.css",
                "~/Content/css/magnific-popup.css",
                "~/Content/css/responsive.css",
                "~/Content/css/responsive-rtl.css",
                "~/Content/css/loading-bar.css",
                "~/Content/css/fonts/persian/persian.css",
                "~/Content/DistortedButtonEffects/css/main.css"
                ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/bootstrap/css").Include(
                "~/Content/bootstrap/bootstrap-rtl.css",
                "~/Content/bootstrap/responsive-rtl.css"
                ));

            bundles.Add(new StyleBundle("~/Content/feloara/css").Include(
                 "~/Content/font-awesome.min.css",
                 "~/Content/froala_editor.min.css",
                 "~/Content/froala_style.css",
                 "~/Content/froala_page.css"
            ));

            bundles.Add(new StyleBundle("~/Content/feloara/css/Plugins").Include(
                 "~/Content/plugins/code_view.min.css",
                 "~/Content/plugins/colors.css",
                 "~/Content/plugins/image_manager.css",
                 "~/Content/plugins/image.css",
                 "~/Content/plugins/line_breaker.css",
                 "~/Content/plugins/table.css",
                 "~/Content/plugins/char_counter.css",
                 "~/Content/plugins/video.css",
                 "~/Content/plugins/fullscreen.css",
                 "~/Content/plugins/file.css",
                 "~/Content/themes/dark.css"
            ));
            bundles.Add(new StyleBundle("~/Content/redactor/css").Include(
                "~/Scripts/redactor/redactor.css"
                ));

            bundles.Add(new StyleBundle("~/Content/sitecss").Include("~/Content/Style.css"));


            bundles.Add(new StyleBundle("~/Content/themes/start/autocompleteandanimations").Include(
                "~/Content/themes/start/jquery-ui-1.10.2.autocomplete.css",
                "~/Content/animate.css",
                "~/Content/themes/start/jquery.ui.datepicker.css"
                ));


            bundles.Add(new StyleBundle("~/Content/themes/start/css").Include(
                "~/Content/themes/start/jquery.ui.core.css",
                "~/Content/themes/start/jquery.ui.resizable.css",
                "~/Content/themes/start/jquery.ui.selectable.css",
                "~/Content/themes/start/jquery.ui.accordion.css",
                "~/Content/themes/start/jquery.ui.autocomplete.css",
                "~/Content/themes/start/jquery.ui.button.css",
                "~/Content/themes/start/jquery.ui.dialog.css",
                "~/Content/themes/start/jquery.ui.menu.css",
                "~/Content/themes/start/jquery.ui.slider.css",
                "~/Content/themes/start/jquery.ui.tabs.css",
                "~/Content/themes/start/jquery.ui.datepicker.css",
                "~/Content/themes/start/jquery.ui.progressbar.css",
                "~/Content/themes/start/jquery.ui.tooltip.css",
                "~/Content/themes/start/jquery.ui.theme.css"));


            //bundles.Add(new StyleBundle("~/Content").Include(
            //"~/Content/bootstrap-rtl.css", "~/Content/responsive-rtl.css")); 
            #endregion
        }
    }
}