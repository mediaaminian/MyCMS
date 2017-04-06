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
    public partial class ProductPropertyController : Controller
    {
        private readonly IProductPropertyService _ProductPropertyService;
        private readonly IUnitOfWork _uow;
        public ProductPropertyController(IUnitOfWork uow, IProductPropertyService ProductPropertyService, IUserService userService)
        {
            _uow = uow;
            _ProductPropertyService = ProductPropertyService;
        }
        public virtual ActionResult Index()
        {
            return PartialView(MVC.Admin.ProductProperty.Views._Index);
        }
        public virtual ActionResult GetDataTable()
        {
            //var list= _ProductPropertyService.GetAllProductProperty();

            List<ProductPropertyModel> list = new List<ProductPropertyModel>();

            return PartialView(MVC.Admin.ProductProperty.Views._DataTable, list);
        }
        public virtual ActionResult Create(ProductPropertyModel model)
        {
            _ProductPropertyService.AddProductProperty(model);
            var sd = _uow.SaveChanges();
            return null;

        }
        public virtual ActionResult Update(ProductPropertyModel model)
        {
            _ProductPropertyService.UpdateProductProperty(model);
            var sd = _uow.SaveChanges();
            return null;

        }
        public virtual ActionResult Delete(ProductPropertyModel model)
        {
            _ProductPropertyService.DeleteProductProperty(model.Id);
            var sd = _uow.SaveChanges();

            return null;

        }

    }
}