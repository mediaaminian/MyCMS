﻿using System.Web.Mvc;
using MyCMS.Model;
using MyCMS.Servicelayer.Interfaces;
using MyCMS.Web.Caching;

namespace MyCMS.Web.Controllers
{
    public partial class MetaTagController : Controller
    {
        private readonly IOptionService _optionService;
        private readonly ICacheService _cacheService;
        public MetaTagController(IOptionService optionService, ICacheService cacheService)
        {
            _optionService = optionService;
            _cacheService = cacheService;
        }

        public virtual ActionResult Index(string title, string keywords, string description)
        {
            SiteConfig siteConfig = _cacheService.GetSiteConfig();

            ViewBag.Title = !string.IsNullOrEmpty(title)
                ? string.Format("{0} - {1}", title, siteConfig.BlogName)
                : siteConfig.BlogName;

            ViewBag.Keywords = keywords;
            ViewBag.Description = description;

            return PartialView();
        }
    }
}