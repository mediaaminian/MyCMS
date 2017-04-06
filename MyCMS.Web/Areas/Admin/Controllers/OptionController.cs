﻿using System.Web.Mvc;
using MyCMS.Datalayer.Context;
using MyCMS.Model;
using MyCMS.Servicelayer.Interfaces;
using MyCMS.Web.Caching;
using MyCMS.Web.Filters;

namespace MyCMS.Web.Areas.Admin.Controllers
{
    [SiteAuthorize(Roles = "admin")]
    public partial class OptionController : Controller
    {
        private readonly IOptionService _optionService;
        private readonly IUnitOfWork _uow;
        private readonly ICacheService _cacheService;

        public OptionController(IUnitOfWork uow, IOptionService optionService,ICacheService cacheService)
        {
            _uow = uow;
            _optionService = optionService;
            _cacheService = cacheService;
        }

        public virtual ActionResult Index()
        {
            return PartialView(MVC.Admin.Option.Views._Index, _optionService.GetAll());
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult Index(SiteConfig model)
        {
            _optionService.Update(model);
            _uow.SaveChanges();
            _cacheService.RemoveSiteConfig();
            return PartialView(MVC.Admin.Shared.Views._Alert, new Alert
            {
                Message = "تنظیمات سایت با موفقیت به روز رسانی شد",
                Mode = AlertMode.Success
            });
        }
    }
}