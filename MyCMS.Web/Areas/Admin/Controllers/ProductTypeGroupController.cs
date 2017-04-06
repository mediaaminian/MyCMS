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
    public partial class ProductTypeGroupController : Controller
    {
        private readonly IProductTypeGroupService _ProductTypeGroupService;
        private readonly IUnitOfWork _uow;
        public ProductTypeGroupController(IUnitOfWork uow, IProductTypeGroupService ProductTypeGroupService, IUserService userService)
        {
            _uow = uow;
            _ProductTypeGroupService = ProductTypeGroupService;
        }
        public virtual ActionResult Index()
        {
            return PartialView(MVC.Admin.ProductTypeGroup.Views._Index);
        }
        public virtual ActionResult GetDataTable()
        {
            var list= _ProductTypeGroupService.GetAllProductTypeGroups();

            return PartialView(MVC.Admin.ProductTypeGroup.Views._DataTable, list);
        }
        public virtual ActionResult Create(ProductTypeGroupModel model)
        {
            _ProductTypeGroupService.AddProductTypeGroup(model);
            var sd = _uow.SaveChanges();
            return null;

        }
        public virtual ActionResult Update(ProductTypeGroupModel model)
        {
            _ProductTypeGroupService.UpdateProductTypeGroup(model);
            var sd = _uow.SaveChanges();
            return null;

        }
        public virtual ActionResult Delete(ProductTypeGroupModel model)
        {
            _ProductTypeGroupService.DeleteProductTypeGroup(model.Id);
            var sd = _uow.SaveChanges();

            return null;

        }
        public virtual JsonResult GetDropDown()
        {
            var list = _ProductTypeGroupService.GetAllProductTypeGroups();

            return Json(list, JsonRequestBehavior.AllowGet);
        }


        }
    }