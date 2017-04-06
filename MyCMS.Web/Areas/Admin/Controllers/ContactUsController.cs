using System.Web.Mvc;
using MyCMS.Datalayer.Context;
using MyCMS.Servicelayer.Interfaces;
using MyCMS.Web.Filters;

namespace MyCMS.Web.Areas.Admin.Controllers
{
    [SiteAuthorize(Roles = "admin,moderator")]
    public partial class ContactUsController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IUnitOfWork _uow;

        public ContactUsController(IUnitOfWork uow, IMessageService messageService)
        {
            _uow = uow;
            _messageService = messageService;
        }

        public virtual ActionResult Index()
        {
            var model = _messageService.GetAll();
            foreach (var item in model)
            {
                item.Subject = item.Subject.Split('#')[0];
            }
            return PartialView(MVC.Admin.ContactUs.Views._Index, model);
        }

        public virtual ActionResult Detail(int id)
        {
            var model = _messageService.Find(id);
            model.Subject = model.Subject.Replace("#", "<br />").Replace("[","<strong>").Replace("]","</strong>");
            return PartialView(MVC.Admin.ContactUs.Views._Detail, model);
        }

        #region Delete Message

        [HttpGet]
        public virtual ActionResult ConfirmDelete(int id)
        {
            ViewBag.Id = id;
            ViewBag.EntityName = "پیام";
            ViewBag.DeleteActionName = MVC.Admin.ContactUs.ActionNames.Delete;
            ViewBag.ControllerName = MVC.Admin.ContactUs.Name;
            ViewBag.ReturnActionName = MVC.Admin.ContactUs.ActionNames.Index;
            return PartialView(MVC.Admin.Shared.Views._ConfirmDelete);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Delete(int id)
        {
            _messageService.Remove(id);
            _uow.SaveChanges();
            return PartialView(MVC.Admin.Shared.Views._Alert, new Alert { Message = "پیام مورد نظر با موفقیت حذف شد" });
        }

        #endregion
    }
}