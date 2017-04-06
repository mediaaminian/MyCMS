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
    public partial class ProductTypeController : Controller
    {
        private readonly IProductTypeService _ProductTypeService;
        private readonly IUnitOfWork _uow;
        public ProductTypeController(IUnitOfWork uow, IProductTypeService ProductTypeService, IUserService userService)
        {
            _uow = uow;
            _ProductTypeService = ProductTypeService;
        }
        public virtual ActionResult Index()
        {
            return PartialView(MVC.Admin.ProductType.Views._Index);
        }
        public virtual ActionResult GetDataTable()
        {
            var list= _ProductTypeService.GetAllProductType();

            return PartialView(MVC.Admin.ProductType.Views._DataTable, list);
        }
        public virtual ActionResult Create(ProductTypeModel model)
        {
            _ProductTypeService.AddProductType(model);
            var sd = _uow.SaveChanges();
            return null;

        }
        public virtual ActionResult Update(ProductTypeModel model)
        {
            _ProductTypeService.UpdateProductType(model);
            var sd = _uow.SaveChanges();
            return null;

        }
        public virtual ActionResult Delete(ProductTypeModel model)
        {
            _ProductTypeService.DeleteProductType(model.Id);
            var sd = _uow.SaveChanges();

            return null;

        }
        public virtual JsonResult GetDropDown()
        {
            var list = _ProductTypeService.GetAllProductType();

            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}