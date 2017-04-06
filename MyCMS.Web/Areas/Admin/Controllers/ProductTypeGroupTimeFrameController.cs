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
    public partial class ProductTypeGroupTimeFrameController : Controller
    {
        private readonly IProductTypeGroupTimeFrameService _ProductTypeGroupTimeFrameService;
        private readonly IUnitOfWork _uow;
        public ProductTypeGroupTimeFrameController(IUnitOfWork uow, IProductTypeGroupTimeFrameService ProductTypeGroupTimeFrameService, IUserService userService)
        {
            _uow = uow;
            _ProductTypeGroupTimeFrameService = ProductTypeGroupTimeFrameService;
        }
        public virtual ActionResult Index()
        {
            return PartialView(MVC.Admin.ProductTypeGroupTimeFrame.Views._Index);
        }
        public virtual ActionResult GetDataTable()
        {
            var list= _ProductTypeGroupTimeFrameService.GetAllProductTypeGroupTimeFrames();


            return PartialView(MVC.Admin.ProductTypeGroupTimeFrame.Views._DataTable, list);
        }
        public virtual ActionResult Create(ProductTypeGroupTimeFrameModel model)
        {
            _ProductTypeGroupTimeFrameService.AddProductTypeGroupTimeFrame(model);
            var sd = _uow.SaveChanges();
            return null;

        }
        public virtual ActionResult Update(ProductTypeGroupTimeFrameModel model)
        {
            _ProductTypeGroupTimeFrameService.UpdateProductTypeGroupTimeFrame(model);
            var sd = _uow.SaveChanges();
            return null;

        }
        public virtual ActionResult Delete(ProductTypeGroupTimeFrameModel model)
        {
            _ProductTypeGroupTimeFrameService.DeleteProductTypeGroupTimeFrame(model.Id);
            var sd = _uow.SaveChanges();

            return null;

        }
    }
}