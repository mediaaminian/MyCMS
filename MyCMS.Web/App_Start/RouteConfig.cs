using System.Web.Mvc;
using System.Web.Routing;
using LowercaseRoutesMVC;

namespace MyCMS.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("Content/{*pathInfo}");
            routes.IgnoreRoute("Scripts/{*pathInfo}");


            routes.MapRouteLowercase("CurrencyRoute", "Currency/{action}/{id}/{title}", new
            {
                area = "",
                controller = "Currency",
                action = "Index",
                id = UrlParameter.Optional,
                title = UrlParameter.Optional
            }, new[] { "MyCMS.Web.Controllers" }
                );

            routes.MapRouteLowercase("ArticleRoute", "Article/{action}/{id}/{title}", new
            {
                area = "",
                controller = "Article",
                action = "Index",
                id = UrlParameter.Optional,
                title = UrlParameter.Optional
            }, new[] { "MyCMS.Web.Controllers" }
                );

            routes.MapRouteLowercase("LabelRoute", "Label/{action}/{id}/{title}/{name}", new
            {
                area = "",
                controller = "Label",
                action = "Index",
                id = UrlParameter.Optional,
                title = UrlParameter.Optional,
                name = UrlParameter.Optional
            }, new[] { "MyCMS.Web.Controllers" }
                );

            routes.MapRouteLowercase("DutyCalculatorRoute", "DutyCalculator/{userName}", new
            {
                area = "",
                controller = "Currency",
                action = "DutyCurrencyCalculator",
                userName = UrlParameter.Optional
            }, new[] { "MyCMS.Web.Controllers" }
                );
            routes.MapRouteLowercase("Currencies", "currencies/{userName}", new
            {
                area = "",
                controller = "Currency",
                action = "Index",
                userName = UrlParameter.Optional
            }, new[] { "MyCMS.Web.Controllers" }
                );
            routes.MapRouteLowercase("KBDetailRoute", "KBDetail/{Id}/{userName}", new
            {
                area = "",
                controller = "Post",
                action = "Index",
                Id = UrlParameter.Optional,
                userName = UrlParameter.Optional
            }, new[] { "MyCMS.Web.Controllers" }
                );
            routes.MapRouteLowercase("KBRoute", "KB/{userName}", new
            {
                area = "",
                controller = "Post",
                action = "KnowledgeBase",
                userName = UrlParameter.Optional
            }, new[] { "MyCMS.Web.Controllers" }
                );
           
            routes.MapRouteLowercase("PostRoute", "Post/{action}/{id}/{title}", new
            {
                area = "",
                controller = "Post",
                action = "Index",
                id = UrlParameter.Optional,
                title = UrlParameter.Optional
            }, new[] { "MyCMS.Web.Controllers" }
                );


            routes.MapRouteLowercase("PageKeywordRoute", "{keyword}.mvc", new
            {
                area = "",
                controller = "Page",
                action = "IndexWithKeyWord",
                keyword = UrlParameter.Optional,
            }, new[] { "MyCMS.Web.Controllers" }
                );
            routes.MapRouteLowercase("PageRoute", "Page/{action}/{id}/{title}", new
            {
                area = "",
                controller = "Page",
                action = "Index",
                id = UrlParameter.Optional,
                title = UrlParameter.Optional
            }, new[] { "MyCMS.Web.Controllers" }
                );

            routes.MapRouteLowercase("LoginRoute", "User/Login/{userName}", new
            {
                area = "",
                controller = "User",
                action = "Logon",
                userName = UrlParameter.Optional
            }, new[] { "MyCMS.Web.Controllers" }
                );

            routes.MapRouteLowercase("UserRoute", "User/{action}/{userName}", new
            {
                area = "",
                controller = "User",
                action = "Index",
                userName = UrlParameter.Optional
            }, new[] { "MyCMS.Web.Controllers" }
                );

            routes.MapRouteLowercase("AdminRout", "Admin", new
            {
                area = "Admin",
                controller = "Home",
                action = "Index",
                id = UrlParameter.Optional,
            }, new[] { "MyCMS.Web.Controllers" }
                );

            routes.MapRouteLowercase("Default", "{controller}/{action}/{id}", new
            {
                area = "",
                controller = "Home",
                action = "Index",
                id = UrlParameter.Optional,
            }, new[] { "MyCMS.Web.Controllers" }
                );
        }
    }
}