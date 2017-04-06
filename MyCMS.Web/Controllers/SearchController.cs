using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using MyCMS.Model.LuceneModel;
using MyCMS.Servicelayer.Interfaces;
using MyCMS.Web.Helpers;
using MyCMS.Web.Searching;

namespace MyCMS.Web.Controllers
{
    public partial class SearchController : Controller
    {
        private readonly IPostService _postService;
        private readonly IPageService _pageService;

        public SearchController(IPostService postService, IPageService pageService)
        {
            _postService = postService;
            _pageService = pageService;
        }

        public virtual ActionResult Index(string term, int page = 0, int count = 5)
        {
            ViewBag.Term = term;

            var RoutingKey = "search";
            var _page = _pageService.FindByExternalLink(RoutingKey);
            if (_page != null)
            {
                TempData["PageTitle"] = _page.Title ?? "نتیجه جستجو";
                TempData["PageSubtitle"] = _page.SubTitle ?? "جستجو در کل صفحات و مطالب سایت";
                TempData["FeatureImage"] = _page.FeatureImage ?? "/Content/images/material/breadcrumb.jpg";
            }
            else
            {
                TempData["PageTitle"] = "نتیجه جستجو";
                TempData["PageSubtitle"] = "جستجو در کل صفحات و مطالب سایت";
                TempData["FeatureImage"] = "/Content/images/material/breadcrumb.jpg";
            }

            IEnumerable<LucenePostModel> allPosts = LucenePostSearch.Search(term,
                "Title", "Body", "Labels", "Keywords", "Description");
            ViewBag.CurrentPage = page;
            ViewBag.TotalRecords = allPosts.Count();
            ViewBag.Count = count;
            var model = allPosts.Skip(page * count).Take(count);

            const string highlightPattern = @"<b style='color:red;'>$1</b>";

            foreach (LucenePostModel Post in model)
            {
                Post.Title = Regex.
                    Replace(Post.Title ?? " ", string.Format("({0})", term), highlightPattern, RegexOptions.IgnoreCase);
                Post.Description = Regex.
                    Replace(Post.Description ?? " ", string.Format("({0})", term), highlightPattern,
                        RegexOptions.IgnoreCase);
                Post.Body = Regex.
                    Replace(Post.Body ?? " ", string.Format("({0})", term), highlightPattern, RegexOptions.IgnoreCase);
                Post.Labels = Regex.
                    Replace(Post.Labels ?? " ", string.Format("({0})", term), highlightPattern,
                        RegexOptions.IgnoreCase);
                Post.Keywords = Regex.
                    Replace(Post.Keywords ?? " ", string.Format("({0})", term), highlightPattern, RegexOptions.IgnoreCase);
            }
            if (Request.IsAjaxRequest())
            {
                return PartialView(model);
            }
            return View(model);
        }

        public virtual ActionResult AutoCompleteSearch(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
                return Content(string.Empty);

            IEnumerable<LucenePostModel> items =
                LucenePostSearch.Search(term, "Title", "Body", "Labels", "Keywords", "Description").Take(10);


            var data =
                items.Select(x => new
                {
                    label = x.Title,
                    url =
                        Url.Action(MVC.Post.ActionNames.Index, MVC.Post.Name,
                            new { id = x.PostId, title = UrlExtensions.ResolveTitleForUrl(x.Title) })
                });

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}