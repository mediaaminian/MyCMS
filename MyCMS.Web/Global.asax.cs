using System;
using System.Data.Entity;
using System.Globalization;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using CaptchaMvc.Infrastructure;
using MyCMS.Datalayer.Context;
using MyCMS.Datalayer.Migrations;
using MyCMS.Servicelayer.Interfaces;
using MyCMS.Utilities.DateAndTime;
using MyCMS.Web.Binders;
using MyCMS.Web.MyCMSMembership;
using MvcSiteMapProvider.Web;
using StackExchange.Profiling;
using StructureMap;
using MyCMS.Web.Searching;
using MyCMS.Web.ViewEngine;
using FluentValidation.Mvc;
namespace MyCMS.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : HttpApplication
    {
        public static bool ReindexingPages { get; set; }
        public static bool ReindexingPosts { get; set; }
        protected void Application_Start()
        {

            FluentValidationModelValidatorProvider.Configure();
            ModelBinders.Binders.DefaultBinder = new CustomModelBinder();
            ModelBinders.Binders.Add(typeof(DateTime?), new PersianDateModelBinder());

            //Database.SetInitializer<MyCMSDbContext>(null);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyCMSDbContext, Configuration>());

            //MiniProfilerEF.InitializeEF42();

            XmlSiteMapController.RegisterRoutes(RouteTable.Routes); // <-- register sitemap.xml, add this line of code

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // Remove Extra ViewEngins
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
            ViewEngines.Engines.Add(new PhpViewEngine());

            MvcHandler.DisableMvcResponseHeader = true;
            CaptchaUtils.CaptchaManager.StorageProvider = new CookieStorageProvider();
            ReindexingPages = true;
            ReindexingPosts = true;
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            var context = DependencyResolver.Current.GetService<HttpContextBase>();

            var principalService = ObjectFactory.GetInstance<IPrincipalService>(); //DependencyResolver.Current.GetService<IPrincipalService>();

            var formsAuthenticationService = ObjectFactory.GetInstance<IFormsAuthenticationService>();

            // Set the HttpContext's User to our IPrincipal
            context.User = principalService.GetCurrent();

            if (!context.User.Identity.IsAuthenticated)
                return;

            var userService = ObjectFactory.GetInstance<IUserService>();

            UserStatus userStatus = userService.GetStatus(Context.User.Identity.Name);

            if (userStatus.IsBaned || !context.User.IsInRole(userStatus.Role))
                formsAuthenticationService.SignOut();

            var dbContext = ObjectFactory.GetInstance<IUnitOfWork>();

            userService.UpdateUserLastActivity(User.Identity.Name, DateAndTime.GetDateTime());

            dbContext.SaveChanges();
        }

        protected void Application_PreSendRequestHeaders(object sender, EventArgs e)
        {
            var app = sender as HttpApplication;
            if (app == null || app.Context == null)
                return;
            app.Context.Response.Headers.Remove("Server");
        }

        private void Application_EndRequest(object sender, EventArgs e)
        {
            ObjectFactory.ReleaseAndDisposeAllHttpScopedObjects();
        }
    }
}