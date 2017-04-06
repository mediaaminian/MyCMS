using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCMS.Web.Controllers
{
    public partial class MyCMSController : Controller
    {
        // GET: MyCMS
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}