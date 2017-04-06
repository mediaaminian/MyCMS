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
    public partial class PropertyController : Controller
    {
        private readonly IPropertyService _PropertyService;
        private readonly IUnitOfWork _uow;
        public PropertyController(IUnitOfWork uow, IPropertyService PropertyService, IUserService userService)
        {
            _uow = uow;
            _PropertyService = PropertyService;
        }
        public virtual ActionResult Index()
        {
            return PartialView(MVC.Admin.Property.Views._Index);
        }
        public virtual ActionResult GetDataTable()
        {
            var list = _PropertyService.GetAllProperties();

            //List<PropertyModel> list = new List<PropertyModel>();

            return PartialView(MVC.Admin.Property.Views._DataTable, list);
        }
        public virtual ActionResult Create(PropertyModel model)
        {
            _PropertyService.AddProperty(model);
            var sd = _uow.SaveChanges();
            return null;

        }
        public virtual ActionResult Update(PropertyModel model)
        {
            _PropertyService.UpdateProperty(model);
            var sd = _uow.SaveChanges();
            return null;

        }
        public virtual ActionResult Delete(PropertyModel model)
        {
            _PropertyService.DeleteProperty(model.Id);
            var sd = _uow.SaveChanges();

            return null;

        }
    }
}