using System.Web.Mvc;
using MyCMS.Datalayer.Context;
using MyCMS.DomainClasses.Entities;
using MyCMS.Servicelayer.Interfaces;
using MyCMS.Utilities;
using MyCMS.Web.Filters;

namespace MyCMS.Web.Controllers
{
    public partial class PageController : Controller
    {
        private readonly IPageService _pageService;
        private readonly IUnitOfWork _uow;
        private readonly IUserService _userService;

        public PageController(IUnitOfWork uow, IUserService userService, IPageService pageService)
        {
            _uow = uow;
            _userService = userService;
            _pageService = pageService;
        }

        public virtual ActionResult Index(int id)
        {
            Page model = _pageService.Find(id);

            TempData["PageTitle"] = model.Title;
            TempData["PageSubtitle"] = model.SubTitle;
            TempData["FeatureImage"] = model.FeatureImage ?? "/Content/images/material/breadcrumb.jpg";
            _pageService.IncrementVisitedCount(id);
            _uow.SaveChanges();
            return View(model);
        }

        public virtual ActionResult IndexWithKeyWord(string keyword)
        {
            Page model = _pageService.FindByExternalLink(keyword);

            TempData["PageTitle"] = model.Title;
            TempData["PageSubtitle"] = model.SubTitle;
            TempData["FeatureImage"] = model.FeatureImage ?? "/Content/images/material/breadcrumb.jpg";
            _pageService.IncrementVisitedCount(model.Id);
            _uow.SaveChanges();
            return View(model);
        }
        [SiteAuthorize]
        [HttpPost]
        public virtual ActionResult Like(int id)
        {
            string result;
            int likeCount = 0;
            if (!_pageService.IsUserLikePage(id, User.Identity.Name))
            {
                likeCount = _pageService.Like(id, _userService.Find(User.Identity.Name));
                _uow.SaveChanges();
                result = "success";
            }
            else
            {
                result = "duplicate";
            }
            return Json(new { result, count = ConvertToPersian.ConvertToPersianString(likeCount) });
        }

        [SiteAuthorize]
        [HttpPost]
        public virtual ActionResult DisLike(int id)
        {
            string result;
            int likeCount = 0;
            if (!_pageService.IsUserLikePage(id, User.Identity.Name))
            {
                likeCount = _pageService.DisLike(id, _userService.Find(User.Identity.Name));
                _uow.SaveChanges();
                result = "success";
            }
            else
            {
                result = "duplicate";
            }
            return Json(new { result, count = ConvertToPersian.ConvertToPersianString(likeCount) });
        }
    }
}