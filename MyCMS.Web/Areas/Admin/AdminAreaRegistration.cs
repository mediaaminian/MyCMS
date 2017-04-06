using System.Web.Mvc;
using LowercaseRoutesMVC;

namespace MyCMS.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRouteLowercase(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { area = "Admin", controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "MyCMS.Web.Areas.Admin.Controllers" }
            );
        }
    }
}
