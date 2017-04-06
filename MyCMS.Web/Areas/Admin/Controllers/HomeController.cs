using System.Web.Mvc;
using MyCMS.Web.Infrastructure;
using MyCMS.Web.HtmlCleaner;

namespace MyCMS.Web.Areas.Admin.Controllers
{
    public partial class HomeController : Controller
    {
        [Authorize(Roles = "admin,moderator,writer,editor")]
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult TinyMCE()
        {
            return PartialView(MVC.Admin.Home.ActionNames.TinyMCE, MVC.Admin.Home.Name);
        }
        public virtual ActionResult IFrame()
        {
            return View();
        }

        public virtual ActionResult Standalone()
        {
            return View();
        }
        [Authorize(Roles = "admin,moderator,writer,editor")]
        public virtual ActionResult TopMenu()
        {
            AvatarImage.DefaultPath = Url.Content("~/Content/Admin/css/Images/profile_user.jpg");
            AvatarImage.BasePath = Url.Content("~/Content/avatars/");
            ViewBag.AvatarPath = AvatarImage.GetAvatarImage(User.Identity.Name);
            return PartialView(MVC.Admin.Home.Views._TopMenu);
        }

        [Authorize(Roles = "admin,moderator,writer,editor")]
        public virtual ActionResult Footer()
        {
            return PartialView(MVC.Admin.Home.Views._Footer);
        }

        [Authorize(Roles = "admin,moderator,writer,editor")]
        public virtual ActionResult QuickSidebar()
        {
            return PartialView(MVC.Admin.Home.Views._QuickSidebar);
        }

        [Authorize(Roles = "admin,moderator,writer,editor")]
        public virtual ActionResult Sidebar()
        {
            return PartialView(MVC.Admin.Home.Views._Sidebar);
        }

        [Authorize(Roles = "admin,moderator,writer,editor")]
        public virtual ActionResult Breadcrumb()
        {
            return PartialView(MVC.Admin.Home.Views._Breadcrumb);
        }
        public virtual ActionResult RenderDashBoard()
        {
            // set avatar images for users
            AvatarImage.DefaultPath = Url.Content("~/Content/Admin/css/Images/profile_user.jpg");
            AvatarImage.BasePath = Url.Content("~/Content/avatars/");
            ViewBag.AvatarPath = AvatarImage.GetAvatarImage(User.Identity.Name);
            return PartialView(MVC.Admin.Home.Views._DashBoard);
        }
    }
}