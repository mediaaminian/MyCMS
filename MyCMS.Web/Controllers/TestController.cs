using System.Web.Mvc;

namespace MyCMS.Web.Controllers
{
    public partial class TestController : Controller
    {
        //
        // GET: /Test/

        public virtual ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public virtual ActionResult a()
        {
            return Content(User.Identity.Name);
        }
    }
}