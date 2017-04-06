using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MyCMS.Datalayer.Context;
using MyCMS.DomainClasses.Entities;
using MyCMS.Model.AdminModel;
using MyCMS.Model.LuceneModel;
using MyCMS.Servicelayer.EFServices.Enums;
using MyCMS.Servicelayer.Interfaces;
using MyCMS.Utilities;
using MyCMS.Utilities.DateAndTime;
using MyCMS.Web.Filters;
using MyCMS.Web.HtmlCleaner;
using MyCMS.Web.Searching;


namespace MyCMS.Web.Areas.Admin.Controllers
{
    [SiteAuthorize(Roles = "admin,moderator,writer")]
    public partial class PropertyGroupController : Controller
    {
        private readonly IPropertyGroupService _PropertyGroupService;
        private readonly IUnitOfWork _uow;
        public PropertyGroupController(IUnitOfWork uow, IPropertyGroupService PropertyGroupService, IUserService userService)
        {
            _uow = uow;
            _PropertyGroupService = PropertyGroupService;
        }
        public virtual ActionResult Index()
        {
            return PartialView(MVC.Admin.PropertyGroup.Views._Index);
        }
        public virtual ActionResult GetDataTable()
        {
            var list= _PropertyGroupService.GetAllPropertyGroup();

            //List<PropertyGroupModel> list = new List<PropertyGroupModel>();

            return PartialView(MVC.Admin.PropertyGroup.Views._DataTable, list);
        }
        public virtual JsonResult GetDropDown()
        {
            var list = _PropertyGroupService.GetAllPropertyGroup();


            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public virtual ActionResult Create(PropertyGroupModel model)
        {
            _PropertyGroupService.AddPropertyGroup(model);
            var sd=_uow.SaveChanges();
            return null;

        }
        public virtual ActionResult Update(PropertyGroupModel model)
        {
            _PropertyGroupService.UpdatePropertyGroup(model);
            var sd = _uow.SaveChanges();
            return null;

        }
        public virtual ActionResult Delete(PropertyGroupModel model)
        {
            _PropertyGroupService.DeletePropertyGroup(model.ID);
            var sd = _uow.SaveChanges();

            return null;

        }



    }
}