using System.Collections.Generic;
using System.IO;
using System.Web;
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
using MyCMS.Web.Helpers;
using MyCMS.Web.HtmlCleaner;
using MyCMS.Web.Searching;

namespace MyCMS.Web.Areas.Admin.Controllers
{
    [SiteAuthorize(Roles = "admin,moderator")]
    public partial class PageController : Controller
    {
        private readonly IPageService _pageService;
        private readonly IUnitOfWork _uow;
        private readonly IUserService _userService;

        public PageController(IUnitOfWork uow, IPageService pageService, IUserService userService)
        {
            _uow = uow;
            _pageService = pageService;
            _userService = userService;
        }

        public virtual ActionResult Index()
        {
            return PartialView(MVC.Admin.Page.Views._Index);
        }

        [HttpGet]
        public virtual ActionResult Add()
        {
            IList<PageDropDownList> lstPages = _pageService.DropDownListData();
            lstPages.Insert(0, new PageDropDownList { Id = -1, Title = "ریشه" });
            ViewBag.ParentPagesList = new SelectList(lstPages, "Id", "Title");

            ViewBag.PageStatus = DropDownList.Status();
            ViewBag.CommentStatus = DropDownList.CommentStatus();

            return PartialView(MVC.Admin.Page.Views._Add);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Add(AddPageModel pageModel)
        {
            var newPage = new Page
            {
                Body = pageModel.Body.ToSafeHtml(),
                CommentStatus = pageModel.CommentStatus,
                CreatedDate = DateAndTime.GetDateTime(),
                Keyword = pageModel.Keyword,
                Order = pageModel.Order,
                Parent = _pageService.Find(pageModel.ParentId.Value),
                Status = pageModel.Status,
                Title = pageModel.Title,
                SubTitle = pageModel.SubTitle,
                IconClass = pageModel.IconClass,
                FeatureImage = pageModel.FeatureImage,
                ExternalLink = pageModel.ExternalLink,
                User = _userService.Find(User.Identity.Name),
                Description = pageModel.Description

            };
            _pageService.Add(newPage);
            _uow.SaveChanges();

            #region Indexing new Post by Lucene.NET

            //Index the new Post lucene.NET
            new LucenePageSearch(_pageService);
            Page currentPage = _pageService.Find(newPage.Id);
            LucenePageSearch.AddUpdateLuceneIndex(new LucenePageModel
            {
                SubTitle = currentPage.SubTitle,
                Body = HtmlUtility.RemoveHtmlTags(currentPage.Body),
                Description = currentPage.Description,
                Keywords = currentPage.Keyword,
                PageId = currentPage.Id,
                Title = currentPage.Title
            });

            #endregion
            return PartialView(MVC.Admin.Shared.Views._Alert, new Alert
            {
                Message = "صفحه جدید با موفقیت در سیستم ثبت شد",
                Mode = AlertMode.Success
            });
        }

        public virtual ActionResult DataTable(string term = "", int page = 0, int count = 10,
            Order order = Order.Descending, PageOrderBy orderBy = PageOrderBy.ParentTitle,
            PageSearchBy searchBy = PageSearchBy.Title)
        {
            ViewBag.CurrentPage = page;
            ViewBag.Count = count;


            ViewBag.TERM = term;
            ViewBag.PAGE = page;
            ViewBag.COUNT = count;
            ViewBag.ORDER = order;
            ViewBag.ORDERBY = orderBy;
            ViewBag.SEARCHBY = searchBy;

            ViewBag.OrderByList = DropDownList.OrderList(order);
            ViewBag.CountList = DropDownList.CountList(count);
            var selectListOrderBy = new List<SelectListItem>
            {
                new SelectListItem {Value = "Date", Text = "تاریخ ارسال"},
                new SelectListItem {Value = "Title", Text = "عنوان"},
                new SelectListItem {Value = "CommentCount", Text = "تعداد دیدگاه"},
                new SelectListItem {Value = "UserName", Text = "نام کاربری"},
                new SelectListItem {Value = "ParentTitle", Text = "ریشه"}
            };

            ViewBag.OrderByItems = new SelectList(selectListOrderBy, "Value", "Text", orderBy);


            IList<PageDataTableModel> model = _pageService.GetDataTable(term, page, count, order, orderBy, searchBy);


            ViewBag.TotalRecords = (string.IsNullOrEmpty(term)) ? _pageService.Count : model.Count;


            return PartialView(MVC.Admin.Page.Views._DataTable, model);
        }

        [HttpGet]
        public virtual ActionResult ConfirmDelete(int id)
        {
            ViewBag.Id = id;
            ViewBag.EntityName = "صفحه";
            ViewBag.DeleteActionName = MVC.Admin.Page.ActionNames.Delete;
            ViewBag.ControllerName = MVC.Admin.Page.Name;
            ViewBag.ReturnActionName = MVC.Admin.Page.ActionNames.Index;
            return PartialView(MVC.Admin.Shared.Views._ConfirmDelete);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Delete(int id)
        {
            _pageService.Remove(id);
            _uow.SaveChanges();
            #region Remove lucene search index

            new LucenePageSearch(_pageService);
            LucenePageSearch.ClearLuceneIndexRecord(id);

            #endregion
            return PartialView(MVC.Admin.Shared.Views._Alert,
                new Alert { Message = "صفحه مورد نظر با موفقیت حذف شد", Mode = AlertMode.Success });
        }

        [HttpGet]
        public virtual ActionResult Edit(int id)
        {
            EditPageModel selectedPage = _pageService.GetEditingData(id);

            IList<PageDropDownList> lstPages = _pageService.DropDownListData(selectedPage.Id);

            lstPages.Insert(0, new PageDropDownList { Id = -1, Title = "ریشه" });
            ViewBag.ParentPagesList = new SelectList(lstPages, "Id", "Title", selectedPage.ParentId);

            ViewBag.PageStatus = DropDownList.Status(selectedPage.Status);
            ViewBag.CommentStatus = DropDownList.CommentStatus(selectedPage.CommentStatus);

            return PartialView(MVC.Admin.Page.Views._Edit, selectedPage);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(EditPageModel pageModel)
        {
            var selectedPage = new Page
            {
                Body = pageModel.Body.ToSafeHtml(),
                CommentStatus = pageModel.CommentStatus,
                Description = pageModel.Description,
                EditedByUser = _userService.Find(User.Identity.Name),
                Keyword = pageModel.Keyword,
                ModifiedDate = DateAndTime.GetDateTime(),
                Id = pageModel.Id,
                Order = pageModel.Order,
                Parent = _pageService.Find(pageModel.ParentId.Value),
                Status = pageModel.Status,
                Title = pageModel.Title,
                SubTitle = pageModel.SubTitle,
                IconClass = pageModel.IconClass,
                FeatureImage = pageModel.FeatureImage,
                ExternalLink = pageModel.ExternalLink,
            };
            _pageService.Update(selectedPage);
            _uow.SaveChanges();
            #region Indexing updated book by Lucene.NET

            //Index updated book lucene.NET
            new LucenePageSearch(_pageService);
            LucenePageSearch.ClearLuceneIndexRecord(pageModel.Id);
            Page currentPage = _pageService.Find(pageModel.Id);
            LucenePageSearch.AddUpdateLuceneIndex(new LucenePageModel
            {
                SubTitle = currentPage.SubTitle,
                Body = HtmlUtility.RemoveHtmlTags(currentPage.Body),
                Description = currentPage.Description,
                Keywords = currentPage.Keyword,
                PageId = currentPage.Id,
                Title = currentPage.Title
            });

            #endregion
            return PartialView(MVC.Admin.Shared.Views._Alert,
                new Alert { Message = "صفحه مورد نظر با موفقیت ویرایش شد", Mode = AlertMode.Success });
        }
    }
}