using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MyCMS.Datalayer.Context;
using MyCMS.Model;
using MyCMS.Model.LuceneModel;
using MyCMS.Servicelayer.Interfaces;
using MyCMS.Utilities;
using MyCMS.Web.Caching;
using MyCMS.Web.Filters;
using MyCMS.Web.Searching;

namespace MyCMS.Web.Controllers
{
    public partial class CurrencyController : Controller
    {
        private readonly ICacheService _cacheService;
        private readonly ICurrencyService _CurrencyService;
        private readonly IUnitOfWork _uow;
        private readonly IUserService _userService;
        private readonly IPageService _pageService;

        public CurrencyController(IUnitOfWork uow, ICurrencyService CurrencySerivce, IUserService userService, ICacheService cacheService, IPageService pageService)
        {
            _uow = uow;
            _CurrencyService = CurrencySerivce;
            _userService = userService;
            _cacheService = cacheService;
            _pageService = pageService;
        }
        public virtual ActionResult Index()
        {
            var RoutingKey = "currencies";
            var _page =_pageService.FindByExternalLink(RoutingKey);
            if (_page != null)
            {
                TempData["PageTitle"] = _page.Title ?? "نرخ  روزانه ارز و تبدیل واحدهای ارزی";
                TempData["PageSubtitle"] = _page.SubTitle ?? "لیست جامع نرخ روزانه ارز و تبدیل واحدهای ارزی";
                TempData["FeatureImage"] = _page.FeatureImage ?? "/Content/images/material/breadcrumb.jpg";
            }
            else
            {
                TempData["PageTitle"] = "نرخ  روزانه ارز و تبدیل واحدهای ارزی";
                TempData["PageSubtitle"] = "لیست جامع نرخ روزانه ارز و تبدیل واحدهای ارزی";
                TempData["FeatureImage"] = "/Content/images/material/breadcrumb.jpg";
            }
            return View(MVC.Currency.Views.Index, _CurrencyService.GetAllCurrency());
        }

        public virtual ActionResult TopCurrency(int count)
        {
            return PartialView(MVC.Currency.Views._TopCurrency,
           _CurrencyService.GetCurrencyDataTable(0, count, orderBy: Servicelayer.EFServices.Enums.CurrencyOrderBy.ByPriority));
        }

        public virtual ActionResult DutyCalculator()
        {
            return PartialView(MVC.Currency.Views._DutyCalculator);
        }
        public virtual ActionResult Exchange()
        {
            return View();
        }
        public virtual ActionResult DutyCurrencyCalculator(string keyword = "DutyCalculator")
        {
            var RoutingKey = keyword;
            var _page =_pageService.FindByExternalLink(RoutingKey);
            if (_page != null)
            {
                TempData["PageTitle"] = _page.Title ?? "محاسبه آنلاین حقوق و عوارض گمرکی";
                TempData["PageSubtitle"] = _page.SubTitle ?? "محاسبه آنلاین هزینه های گمرک";
                TempData["FeatureImage"] = _page.FeatureImage ?? "/Content/images/material/breadcrumb.jpg";
            }
            else
            {
                TempData["PageTitle"] = "محاسبه آنلاین حقوق و عوارض گمرکی";
                TempData["PageSubtitle"] = "محاسبه آنلاین هزینه های گمرک";
                TempData["FeatureImage"] = "/Content/images/material/breadcrumb.jpg";
            }
            var config = _cacheService.GetSiteConfig();
            ViewBag.VATPercent = config.VATPercent;
            ViewBag.SourcePercent = config.CustomSourcePercent;
            return View();
        }

        public virtual JsonResult GetAllCurrencies()
        {
            var currencies = _CurrencyService.GetAllCurrency();
            return Json(currencies, JsonRequestBehavior.AllowGet);
        }
        public virtual ActionResult UserCurrencys(string userName, int page = 0, int count = 100)
        {
            if (string.IsNullOrEmpty(userName)) userName = User.Identity.Name;

            IList<CurrencyModel> model = _CurrencyService.GetUserCurrency(userName, page, count);
            ViewBag.UserName = userName;
            return PartialView(MVC.Currency.Views._UserCurrency, model);
        }

        public virtual ActionResult UserCurrencysList(string userName)
        {
            ViewBag.UserName = userName;
            return View();
        }
    }
}