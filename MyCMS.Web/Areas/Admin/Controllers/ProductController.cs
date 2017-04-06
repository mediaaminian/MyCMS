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
using System;

namespace MyCMS.Web.Areas.Admin.Controllers
{
    [SiteAuthorize(Roles = "admin,moderator,writer")]
    public partial class ProductController : Controller
    {

        private readonly IProductService _ProductService;
        private readonly IUnitOfWork _uow;
        public ProductController(IUnitOfWork uow, IProductService ProductService, IUserService userService)
        {
            _uow = uow;
            _ProductService = ProductService;
        }
        public virtual ActionResult Index()
        {
            return PartialView(MVC.Admin.Product.Views._Index);
        }
        public virtual ActionResult GetDataTable()
        {
            var list = _ProductService.GetAllProducts();

            return PartialView(MVC.Admin.Product.Views._DataTable, list);
        }
        public virtual ActionResult Create(ProductModel model)
        {
            model.UserID = 1;
            model.CreatedDate = DateTime.Now;
            _ProductService.AddProduct(model);
            var sd = _uow.SaveChanges();

            return null;

        }
        public virtual ActionResult Update(ProductModel model)
        {
            //model.EditedByUserID = 1;
            model.ModifiedDate = DateTime.Now;

            _ProductService.UpdateProduct(model);
            var sd = _uow.SaveChanges();
            return null;

        }
        public virtual ActionResult Delete(ProductModel model)
        {
            _ProductService.DeleteProduct(model.Id);
            var sd = _uow.SaveChanges();

            return null;

        }

    }
}