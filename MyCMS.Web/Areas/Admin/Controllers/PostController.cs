using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using MyCMS.Web.HtmlCleaner;
using MyCMS.Web.Searching;

namespace MyCMS.Web.Areas.Admin.Controllers
{
    [SiteAuthorize(Roles = "admin,moderator,writer")]
    public partial class PostController : Controller
    {
        //private readonly IDownloadLinkService _downloadLinkService;
        private readonly ILabelService _labelService;
        private readonly IPostService _postService;
        private readonly IUnitOfWork _uow;
        private readonly IUserService _userService;

        public PostController(IUnitOfWork uow, IPostService postService, ILabelService labelService,
            IUserService userService)//, IDownloadLinkService downloadLinkService
        {
            _uow = uow;
            _postService = postService;
            _labelService = labelService;
            _userService = userService;
            //_downloadLinkService = downloadLinkService;
        }

        public virtual ActionResult Index()
        {
            return PartialView(MVC.Admin.Post.Views._Index);
        }

        public virtual ActionResult GetPostDataTable(int page = 0, int count = 10, Order order = Order.Descending,
            PostOrderBy orderBy = PostOrderBy.ById)
        {
            ViewBag.CurrentPage = page + 1;
            ViewBag.TotalRecords = _postService.GetPostsCount();
            ViewBag.Count = count;
            return PartialView(MVC.Admin.Post.Views._PostDataTable,
                _postService.GetPostDataTable(page, count, order, orderBy));
        }

        #region Add Post

        [HttpGet]
        public virtual ActionResult Add()
        {
            var lstPostStatus = new List<SelectListItem>
            {
                new SelectListItem {Text = "عادی", Value = "visible", Selected = true},
                new SelectListItem {Text = "پنهان", Value = "hidden"},
                new SelectListItem {Text = "پیش نویس", Value = "draft"},
                new SelectListItem {Text = "آرشیو", Value = "archive"}
            };
            ViewBag.PostStatus = lstPostStatus;
            var lstCommentStatus = new List<SelectListItem>
            {
                new SelectListItem {Value = "true", Text = "فعال", Selected = true},
                new SelectListItem {Value = "false", Text = "غیر فعال", Selected = false}
            };

            ViewBag.CommentStatus = lstCommentStatus;

            ViewBag.Labels = new MultiSelectList(_labelService.GetAll(), "Id", "Name");
            return PartialView(MVC.Admin.Post.Views._Add);
        }

        [HttpGet]
        public virtual ActionResult AddCkEditor()
        {
            var lstPostStatus = new List<SelectListItem>
            {
                new SelectListItem {Text = "عادی", Value = "visible", Selected = true},
                new SelectListItem {Text = "پنهان", Value = "hidden"},
                new SelectListItem {Text = "پیش نویس", Value = "draft"},
                new SelectListItem {Text = "آرشیو", Value = "archive"}
            };
            ViewBag.PostStatus = lstPostStatus;
            var lstCommentStatus = new List<SelectListItem>
            {
                new SelectListItem {Value = "true", Text = "فعال", Selected = true},
                new SelectListItem {Value = "false", Text = "غیر فعال", Selected = false}
            };

            ViewBag.CommentStatus = lstCommentStatus;

            ViewBag.Labels = new MultiSelectList(_labelService.GetAll(), "Id", "Name");
            return PartialView(MVC.Admin.Post.Views._AddCkEditor);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult AddPost(AddPostModel postModel)
        {
            if (!ModelState.IsValid)
                return PartialView(MVC.Admin.Shared.Views._ValidationSummery);

            postModel.PostBody = postModel.PostBody.ToSafeHtml();
            //postModel.Book.Description = postModel.Book.Description.ToSafeHtml();

            var post = new Post
            {
                Body = postModel.PostBody,
                CommentStatus = postModel.PostCommentStatus,
                CreatedDate = DateAndTime.GetDateTime(),
                Description = postModel.PostDescription,
                Keyword = postModel.PostKeyword,
                Picture = postModel.PostPicture,
                Status = postModel.PostStatus.ToString().ToLower(),
                Title = postModel.PostTitle,
            };

            #region Comment
            //var book = new Book
            //{
            //    Author = postModel.Book.Author,
            //    Description = postModel.Book.Description,
            //    ISBN = postModel.Book.ISBN,
            //    Language = postModel.Book.Language,
            //    Name = postModel.Book.Name,
            //    Year = postModel.Book.Year,
            //    Publisher = postModel.Book.Publisher,
            //    Page = postModel.Book.Page
            //};

            //var bookImage = new BookImage
            //{
            //    Path = postModel.BookImage.Path,
            //    Title = postModel.BookImage.Title,
            //    Description = postModel.BookImage.Description,
            //    UploadedDate = DateAndTime.GetDateTime()
            //};

            //var links = new List<DownloadLink>();

            //if (!string.IsNullOrEmpty(postModel.DownloadLinks.DownloadLink1.Link))
            //{
            //    links.Add(postModel.DownloadLinks.DownloadLink1);
            //}
            //if (!string.IsNullOrEmpty(postModel.DownloadLinks.DownloadLink2.Link))
            //{
            //    links.Add(postModel.DownloadLinks.DownloadLink2);
            //}
            //if (!string.IsNullOrEmpty(postModel.DownloadLinks.DownloadLink3.Link))
            //{
            //    links.Add(postModel.DownloadLinks.DownloadLink3);
            //}
            //if (!string.IsNullOrEmpty(postModel.DownloadLinks.DownloadLink4.Link))
            //{
            //    links.Add(postModel.DownloadLinks.DownloadLink4);
            //}

            //post.Book = book;
            //post.DownloadLinks = links;
            //post.Book.Image = bookImage; 
            #endregion
            post.User = _userService.GetUserByUserName(User.Identity.Name);
            post.Labels = _labelService.GetLabelsById(postModel.LabelId);

            _postService.AddPost(post);
            _uow.SaveChanges();

            #region Indexing new Post by Lucene.NET

            //Index the new Post lucene.NET
            new LucenePostSearch(_postService);
            Post lastPost = _postService.Find(post.Id);
            LucenePostSearch.AddUpdateLuceneIndex(new LucenePostModel
            {
                Labels = string.Join(" , " , lastPost.Labels.Select(l=>l.Name).ToArray()),
                Body = HtmlUtility.RemoveHtmlTags(lastPost.Body),
                Description = lastPost.Description,
                Keywords = lastPost.Keyword,
                PostId = lastPost.Id,
                Title = lastPost.Title
            });

            #endregion

            return PartialView(MVC.Admin.Shared.Views._Alert,
                new Alert { Message = "دانشنامه جدید با موقیت در سیستم ثبت شد", Mode = AlertMode.Success });
        }

        #endregion

        #region Edit Post

        [HttpGet]
        public virtual ActionResult EditPost(int id)
        {
            EditPostModel model = _postService.GetPostForEdit(id);

            var lstCommentStatus = new List<SelectListItem>
            {
                new SelectListItem {Value = "true", Text = "فعال"},
                new SelectListItem {Value = "false", Text = "غیر فعال"}
            };

            ViewBag.CommentStatus = new SelectList(lstCommentStatus, "Value", "Text", model.PostCommentStatus);

            var lstPostStatus = new List<SelectListItem>
            {
                new SelectListItem {Text = "عادی", Value = "visible"},
                new SelectListItem {Text = "پنهان", Value = "hidden"},
                new SelectListItem {Text = "پیش نویس", Value = "draft"},
                new SelectListItem {Text = "آرشیو", Value = "archive"}
            };
            ViewBag.Post_Status = new SelectList(lstPostStatus, "Value", "Text", model.PostStatus);

            List<int> lstLablesId = model.Labels.Select(label => label.Id).ToList();

            ViewBag.Post_Labels = new MultiSelectList(_labelService.GetAll(), "Id", "Name", lstLablesId);

            //List<DownloadLink> lstDownloadLinks = model.DownloadLinks.ToList();


            //int index = 0;
            //foreach (DownloadLink link in lstDownloadLinks)
            //{
            //    switch (index++)
            //    {
            //        case 0:
            //            model.Links.DownloadLink1 = link;
            //            break;
            //        case 1:
            //            model.Links.DownloadLink2 = link;
            //            break;
            //        case 2:
            //            model.Links.DownloadLink3 = link;
            //            break;
            //        case 3:
            //            model.Links.DownloadLink4 = link;
            //            break;
            //    }
            //}

            //if (lstDownloadLinks.Count < 4)
            //{
            //    for (int i = 0; i < model.DownloadLinks.Count - lstDownloadLinks.Count; i++)
            //    {
            //        lstDownloadLinks.Add(new DownloadLink());
            //    }
            //}


            return PartialView(MVC.Admin.Post.Views._EditPost, model);
        }

        [HttpGet]
        public virtual ActionResult EditPostCkEditor(int id)
        {
            EditPostModel model = _postService.GetPostForEdit(id);

            var lstCommentStatus = new List<SelectListItem>
            {
                new SelectListItem {Value = "true", Text = "فعال"},
                new SelectListItem {Value = "false", Text = "غیر فعال"}
            };

            ViewBag.CommentStatus = new SelectList(lstCommentStatus, "Value", "Text", model.PostCommentStatus);

            var lstPostStatus = new List<SelectListItem>
            {
                new SelectListItem {Text = "عادی", Value = "visible"},
                new SelectListItem {Text = "پنهان", Value = "hidden"},
                new SelectListItem {Text = "پیش نویس", Value = "draft"},
                new SelectListItem {Text = "آرشیو", Value = "archive"}
            };
            ViewBag.Post_Status = new SelectList(lstPostStatus, "Value", "Text", model.PostStatus);

            List<int> lstLablesId = model.Labels.Select(label => label.Id).ToList();

            ViewBag.Post_Labels = new MultiSelectList(_labelService.GetAll(), "Id", "Name", lstLablesId);

            //List<DownloadLink> lstDownloadLinks = model.DownloadLinks.ToList();


            //int index = 0;
            //foreach (DownloadLink link in lstDownloadLinks)
            //{
            //    switch (index++)
            //    {
            //        case 0:
            //            model.Links.DownloadLink1 = link;
            //            break;
            //        case 1:
            //            model.Links.DownloadLink2 = link;
            //            break;
            //        case 2:
            //            model.Links.DownloadLink3 = link;
            //            break;
            //        case 3:
            //            model.Links.DownloadLink4 = link;
            //            break;
            //    }
            //}

            //if (lstDownloadLinks.Count < 4)
            //{
            //    for (int i = 0; i < model.DownloadLinks.Count - lstDownloadLinks.Count; i++)
            //    {
            //        lstDownloadLinks.Add(new DownloadLink());
            //    }
            //}


            return PartialView(MVC.Admin.Post.Views._EditPostCkEditor, model);
        }


        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult EditPost(EditPostModel postModel)
        {
            if (!ModelState.IsValid)
                return PartialView(MVC.Admin.Shared.Views._ValidationSummery);

            postModel.ModifiedDate = DateAndTime.GetDateTime();
            postModel.EditedByUser = _userService.GetUserByUserName(User.Identity.Name);
            postModel.Labels = _labelService.GetLabelsById(postModel.LabelsId);

           // _downloadLinkService.RemoveByPostId(postModel.PostId);

            _uow.SaveChanges();

            //if (!string.IsNullOrEmpty(postModel.Links.DownloadLink1.Link))
            //{
            //    postModel.DownloadLinks.Add(postModel.Links.DownloadLink1);
            //}
            //if (!string.IsNullOrEmpty(postModel.Links.DownloadLink2.Link))
            //{
            //    postModel.DownloadLinks.Add(postModel.Links.DownloadLink2);
            //}
            //if (!string.IsNullOrEmpty(postModel.Links.DownloadLink3.Link))
            //{
            //    postModel.DownloadLinks.Add(postModel.Links.DownloadLink3);
            //}
            //if (!string.IsNullOrEmpty(postModel.Links.DownloadLink4.Link))
            //{
            //    postModel.DownloadLinks.Add(postModel.Links.DownloadLink4);
            //}

            //postModel.Book.Description = postModel.Book.Description.ToSafeHtml();
            postModel.PostBody = postModel.PostBody.ToSafeHtml();

            UpdatePostStatus status = _postService.UpdatePost(postModel);

            if (status == UpdatePostStatus.Successfull)
            {
                _uow.SaveChanges();

                #region Indexing updated Post by Lucene.NET
                new LucenePostSearch(_postService);
                //Index updated book lucene.NET
                LucenePostSearch.ClearLuceneIndexRecord(postModel.PostId);
                Post currentPost = _postService.Find(postModel.PostId);
                LucenePostSearch.AddUpdateLuceneIndex(new LucenePostModel
                {
                    Labels = string.Join(" , ", currentPost.Labels.Select(l => l.Name).ToArray()),
                    Body = HtmlUtility.RemoveHtmlTags(currentPost.Body),
                    Description = currentPost.Description,
                    Keywords = currentPost.Keyword,
                    PostId = currentPost.Id,
                    Title = currentPost.Title
                });

                #endregion

                return PartialView(MVC.Admin.Shared.Views._Alert,
                    new Alert { Message = "اطلاعات با موفقیت به روز رسانی شد", Mode = AlertMode.Success });
            }

            return PartialView(MVC.Admin.Shared.Views._Alert, new Alert
            {
                Message = "خطا در به روز رسانی اطلاعات",
                Mode = AlertMode.Error
            });
        }

        #endregion

        #region Delete Post

        [HttpGet]
        public virtual ActionResult ConfirmDelete(int id)
        {
            ViewBag.Id = id;
            ViewBag.EntityName = "دانشنامه";
            ViewBag.DeleteActionName = MVC.Admin.Post.ActionNames.Delete;
            ViewBag.ControllerName = MVC.Admin.Post.Name;
            ViewBag.ReturnActionName = MVC.Admin.Post.ActionNames.Index;
            return PartialView(MVC.Admin.Shared.Views._ConfirmDelete);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Delete(int id)
        {
            _postService.RemovePostById(id);
            _uow.SaveChanges();

            #region Remove lucene search index
            new LucenePostSearch(_postService);
            LucenePostSearch.ClearLuceneIndexRecord(id);

            #endregion

            return PartialView(MVC.Admin.Shared.Views._Alert, new Alert { Message = "دانشنامه مورد نظر با موفقیت حذف شد" });
        }
        
        #endregion
    }
}