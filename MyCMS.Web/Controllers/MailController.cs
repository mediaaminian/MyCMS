using System.Web.Mvc;
using MyCMS.Datalayer.Context;
using MyCMS.Servicelayer.Interfaces;
using MyCMS.Utilities.Mail;

namespace MyCMS.Web.Controllers
{
    public partial class MailController : Controller
    {
        private readonly IForgottenPasswordService _forgttenPasswordService;
        private readonly IUnitOfWork _uow;
        private readonly IUserService _userService;

        public MailController(IUnitOfWork uow, IUserService userService,
            IForgottenPasswordService forgottenPasswordService)
        {
            _uow = uow;
            _userService = userService;
            _forgttenPasswordService = forgottenPasswordService;
        }

        public virtual ActionResult Index()
        {
            string m = "";

            return Content(m);
        }
    }
}