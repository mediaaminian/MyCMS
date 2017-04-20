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
using StructureMap.Web.Pipeline;
using MyCMS.Datalayer;
using System.Data.Entity.Infrastructure.Interception;

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

            //MiniProfilerEF.InitializeEF42();
            FluentValidationModelValidatorProvider.Configure();
                System.Web.Mvc.ModelBinders.Binders.Add(typeof(decimal?), new DecimalBinder());
            ModelBinders.Binders.Add(typeof(DateTime?), new PersianDateModelBinder());
            ModelBinders.Binders.DefaultBinder = new CustomModelBinder();

            //Database.SetInitializer<MyCMSDbContext>(null);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyCMSDbContext, Configuration>());


            XmlSiteMapController.RegisterRoutes(RouteTable.Routes); // <-- register sitemap.xml, add this line of code

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.Config();

            DbInterception.Add(new YeKeInterceptor());
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
            //try
            //{
            var context = DependencyResolver.Current.GetService<HttpContextBase>();


            var principalService = DependencyResolver.Current.GetService<IPrincipalService>(); // ObjectFactory.GetInstance<IPrincipalService>(); 

            var formsAuthenticationService = DependencyResolver.Current.GetService<IFormsAuthenticationService>();

            // Set the HttpContext's User to our IPrincipal
            context.User = principalService.GetCurrent();

            if (!context.User.Identity.IsAuthenticated)
                return;

            var userService = DependencyResolver.Current.GetService<IUserService>();

            UserStatus userStatus = userService.GetStatus(Context.User.Identity.Name);

            if (userStatus.IsBaned || !context.User.IsInRole(userStatus.Role))
                formsAuthenticationService.SignOut();

            var dbContext = DependencyResolver.Current.GetService<IUnitOfWork>();

            userService.UpdateUserLastActivity(User.Identity.Name, DateAndTime.GetDateTime());

            dbContext.SaveChanges();
            //}
            //catch
            //{
            //    HttpRuntime.UnloadAppDomain(); // سبب ری استارت برنامه و آغاز مجدد آن با درخواست بعدی می‌شود
            //    throw;
            //}
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
            //ObjectFactory.ReleaseAndDisposeAllHttpScopedObjects();
            HttpContextLifecycle.DisposeAndClearAll();
        }
    }
}