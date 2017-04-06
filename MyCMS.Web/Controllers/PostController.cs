using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCMS.Datalayer.Context;
using MyCMS.Model;
using MyCMS.Model.LuceneModel;
using MyCMS.Servicelayer.Interfaces;
using MyCMS.Utilities;
using MyCMS.Web.Filters;
using MyCMS.Web.Searching;

namespace MyCMS.Web.Controllers
{
    public partial class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IUnitOfWork _uow;
        private readonly IUserService _userService;
        private readonly IPageService _pageService;

        public PostController(IUnitOfWork uow, IPostService postSerivce, IUserService userService, IPageService pageService)
        {
            _uow = uow;
            _postService = postSerivce;
            _userService = userService;
            _pageService = pageService;
        }

        public virtual ActionResult Index(int id)
        {
            var postData = _postService.GetPost(id);
            var RoutingKey = "kb";
            var _page = _pageService.FindByExternalLink(RoutingKey);
            if (_page != null)
            {
                TempData["PageTitle"] = _page.Title ?? "دانشنامه";
                TempData["PageSubtitle"] = _page.SubTitle ?? postData.PostTitle;
                TempData["FeatureImage"] = _page.FeatureImage ?? "/Content/images/material/breadcrumb.jpg";
            }
            else
            {
                TempData["PageTitle"] = "دانشنامه";
                TempData["PageSubtitle"] = postData.PostTitle;
                TempData["FeatureImage"] = "/Content/images/material/breadcrumb.jpg";
            }
            _postService.IncrementVisitedNumber(id);
            _uow.SaveChanges();
            return View(postData);
        }

        [SiteAuthorize]
        [HttpPost]
        public virtual ActionResult Like(int id)
        {
            string result = "duplicate";
            int likeCount = 0;
            //if (!_postService.IsUserLikePost(id, User.Identity.Name))
            //{
            //    likeCount = _postService.Like(id, _userService.Find(User.Identity.Name));
            //    _uow.SaveChanges();
            //    result = "success";
            //}
            //else
            //{
            //    result = "duplicate";
            //}
            return Json(new { result, count = ConvertToPersian.ConvertToPersianString(likeCount) });
        }

        [SiteAuthorize]
        [HttpPost]
        public virtual ActionResult DisLike(int id)
        {
            string result = "duplicate";
            int likeCount = 0;
            //if (!_postService.IsUserLikePost(id, User.Identity.Name))
            //{
            //    likeCount = _postService.DisLike(id, _userService.Find(User.Identity.Name));
            //    _uow.SaveChanges();
            //    result = "success";
            //}
            //else
            //{
            //    result = "duplicate";
            //}
            return Json(new { result, count = ConvertToPersian.ConvertToPersianString(likeCount) });
        }

        [OutputCache(Duration = 60, VaryByParam = "id")]
        public virtual ActionResult SilmilarPosts(int id, int count)
        {
            var labelIds = _postService.GetPostById(id).Labels.Select(x => x.Id).ToArray();
            var model = _postService.GetPostsByExpression(p =>  p.Labels.Any(x=> labelIds.Contains(x.Id))).OrderByDescending(x=>x.Id).Take(count);
            return PartialView(MVC.Post.Views._SimilarPosts, model);
        }
        public virtual ActionResult SimilarPostList(int labelId = 0, int page = 0, int count = 8)
        {
            ViewBag.CurrentPage = page;
            var model = _postService.GetPostsByExpression(p => labelId == 0 || p.Labels.Any(x => x.Id == labelId)).Skip(page * count).Take(count);
            if (model.Any())
                return PartialView(MVC.Post.Views._SimilarPostList, model);
            else
                return Content("موردی برای نمایش وجود ندارد");
        }
        public virtual ActionResult PostList( int page = 0, int count = 8)
        {
            ViewBag.CurrentPage = page;
            var RoutingKey = "kb";
            var _page = _pageService.FindByExternalLink(RoutingKey);
            if (_page != null)
            {
                TempData["PageTitle"] = _page.Title ?? "دانشنامه";
                TempData["PageSubtitle"] = _page.SubTitle ?? "دانشنامه ترخیص کالا ، واردات ، صادرات و امور گمرکی و بازرگانی";
                TempData["FeatureImage"] = _page.FeatureImage ?? "/Content/images/material/breadcrumb.jpg";
            }
            else
            {
                TempData["PageTitle"] = "دانشنامه";
                TempData["PageSubtitle"] = "دانشنامه ترخیص کالا ، واردات ، صادرات و امور گمرکی و بازرگانی";
                TempData["FeatureImage"] = "/Content/images/material/breadcrumb.jpg";
            }
            var model = _postService.GetPosts(page, count);
            if (model.Any())
                return View(MVC.Post.Views.PostList, model);
            else
                return Content("موردی برای نمایش وجود ندارد");
        }
        public virtual ActionResult KnowledgeBase(int page = 0, int count = 4, int skip = 7)
        {
            var RoutingKey = "kb";
            var _page = _pageService.FindByExternalLink(RoutingKey);
            if (_page != null)
            {
                TempData["PageTitle"] = _page.Title ?? "دانشنامه";
                TempData["PageSubtitle"] = _page.SubTitle ?? "دانشنامه ترخیص کالا ، واردات ، صادرات و امور گمرکی و بازرگانی";
                TempData["FeatureImage"] = _page.FeatureImage ?? "/Content/images/material/breadcrumb.jpg";
            }
            else
            {
                TempData["PageTitle"] = "دانشنامه";
                TempData["PageSubtitle"] = "دانشنامه ترخیص کالا ، واردات ، صادرات و امور گمرکی و بازرگانی";
                TempData["FeatureImage"] = "/Content/images/material/breadcrumb.jpg";
            }
            ViewBag.CurrentPage = page;
            ViewBag.TotalRecords = _postService.GetPostsCount() - skip;
            ViewBag.Count = count;
            return View();
        }
        public virtual ActionResult LastPost()
        {
            var model = _postService.GetLastPost();
            return PartialView(MVC.Post.Views._LastPost, model);
        }
        public virtual ActionResult SidePostsWithSkip(int page = 0, int count = 6,int skip = 1)
        {
            var model = _postService.GetPosts(page, count, skip: skip);
            return PartialView(MVC.Post.Views._SidePostsWithSkip, model);
        }
        public virtual ActionResult FooterPostsWithSkip(int page = 0, int count = 4,int skip = 7)
        {
            ViewBag.CurrentPage = page + 1;
            ViewBag.TotalRecords = _postService.GetPostsCount() - skip;
            ViewBag.Count = count;
            var model = _postService.GetPosts(page, count, skip: skip);
            return PartialView(MVC.Post.Views._FooterPostsWithSkip, model);
        }
        public virtual ActionResult LatestPost(int page = 0, int count = 3)
        {
            var model = _postService.GetPosts(page, count);
            return PartialView(MVC.Post.Views._LatestPost, model);
        }
        public virtual ActionResult FooterLatestPost(int page = 0, int count = 3)
        {
            var model = _postService.GetPosts(page, count);
            return PartialView(MVC.Post.Views._FooterLatestPost, model);
        }
        public virtual ActionResult SideLatestPost(int page = 0, int count = 5)
        {
            var model = _postService.GetPosts(page, count);
            return PartialView(MVC.Post.Views._SideLatestPost, model);
        }
        public virtual ActionResult SidePopularPost(int page = 0, int count = 5)
        {
            var model =
            _postService.GetPostsByExpression(p => true).OrderByDescending(p=>p.VisitedNumber).Skip(page * count).Take(count);
            return PartialView(MVC.Post.Views._SidePopularPost, model);
        }

        public virtual ActionResult UserPosts(string userName, int page = 0, int count = 100)
        {
            if (string.IsNullOrEmpty(userName)) userName = User.Identity.Name;

            IList<PostDetailModel> model = _postService.GetUserPosts(userName, page, count);
            ViewBag.UserName = userName;
            return PartialView(MVC.Post.Views._UserPosts, model);
        }

        public virtual ActionResult UserPostsList(string userName)
        {
            ViewBag.UserName = userName;
            return View();
        }
    }
}