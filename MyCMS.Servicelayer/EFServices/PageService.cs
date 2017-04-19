using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MyCMS.Datalayer.Context;
using MyCMS.DomainClasses.Entities;
using MyCMS.Model.AdminModel;
using MyCMS.Servicelayer.EFServices.Enums;
using MyCMS.Servicelayer.Interfaces;
using MyCMS.Utilities.Caching;

namespace MyCMS.Servicelayer.EFServices
{
    public class PageService : IPageService
    {
        private readonly IDbSet<Page> _pages;

        public PageService(IUnitOfWork uow)
        {
            _pages = uow.Set<Page>();
        }

        public void Add(Page page)
        {
            _pages.Add(page);
        }


        public Page Find(int id)
        {
            return _pages.Find(id);
        }

        public Page FindByExternalLink(string ExternalLink)
        {
            //if (_pages.Any(p => p.ExternalLink.ToLower().Contains(ExternalLink.ToLower())))
                return _pages.FirstOrDefault(p => p.ExternalLink.ToLower().Contains(ExternalLink.ToLower()));
           //return new Page();
        }

        public IList<Page> GetAll()
        {
            return _pages.ToList();
        }


        public IList<PageDropDownList> DropDownListData()
        {
            return
                _pages.AsNoTracking().Select(page => new PageDropDownList { Id = page.Id, Title = page.Title }).ToList();
        }

        public IList<PageDropDownList> DropDownListData(int id)
        {
            return _pages.AsNoTracking().Where(page => page.Id != id)
                .Select(page => new PageDropDownList { Id = page.Id, Title = page.Title }).ToList();
        }

        public IList<PageDataTableModel> GetDataTable(string term, int page, int count,
            Order order, PageOrderBy orderBy, PageSearchBy searchBy)
        {
            IQueryable<Page> selectedPages =
                _pages.Include(Page => Page.Comments).Include(Page => Page.User).AsQueryable();

            // page in lambda expression changed to Page, because it confilicts with page Parameter
            if (!string.IsNullOrEmpty(term))
            {
                switch (searchBy)
                {
                    case PageSearchBy.Title:
                        selectedPages = selectedPages.Where(Page => Page.Title.Contains(term)).AsQueryable();
                        break;
                    case PageSearchBy.UserName:
                        selectedPages = selectedPages.Where(Page => Page.User.UserName.Contains(term)).AsQueryable();
                        break;
                    case PageSearchBy.ParentTitle:
                        selectedPages = selectedPages.Where(Page => Page.Parent.Title.Contains(term)).AsQueryable();
                        break;
                    default:
                        break;
                }
            }

            if (order == Order.Asscending)
            {
                switch (orderBy)
                {
                    case PageOrderBy.Title:
                        selectedPages = selectedPages.OrderBy(Page => Page.Title).AsQueryable();
                        break;
                    case PageOrderBy.Date:
                        selectedPages = selectedPages.OrderBy(Page => Page.CreatedDate).AsQueryable();
                        break;
                    case PageOrderBy.CommentCount:
                        selectedPages = selectedPages.OrderBy(Page => Page.Comments.Count).AsQueryable();
                        break;
                    case PageOrderBy.Status:
                        break;
                    case PageOrderBy.UserName:
                        selectedPages = selectedPages.OrderBy(Page => Page.User.UserName).AsQueryable();
                        break;
                    case PageOrderBy.ParentTitle:
                        selectedPages =
                            selectedPages.OrderBy(Page => Page.CreatedDate).OrderBy(Page => Page.Parent.Title)
                                .AsQueryable();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (orderBy)
                {
                    case PageOrderBy.Title:
                        selectedPages = selectedPages.OrderByDescending(Page => Page.Title).AsQueryable();
                        break;
                    case PageOrderBy.Date:
                        selectedPages = selectedPages.OrderByDescending(Page => Page.CreatedDate).AsQueryable();
                        break;
                    case PageOrderBy.CommentCount:
                        selectedPages = selectedPages.OrderByDescending(Page => Page.Comments.Count).AsQueryable();
                        break;
                    case PageOrderBy.Status:
                        break;
                    case PageOrderBy.UserName:
                        selectedPages = selectedPages.OrderByDescending(Page => Page.User.UserName).AsQueryable();
                        break;
                    case PageOrderBy.ParentTitle:
                        selectedPages =
                            selectedPages.OrderByDescending(Page => Page.CreatedDate).OrderBy(Page => Page.Parent.Title)
                                .AsQueryable();
                        break;
                    default:
                        break;
                }
            }

            return selectedPages.Select(_page => new PageDataTableModel
            {
                CommentCount = _page.Comments.Count,
                CommentStatus = _page.CommentStatus,
                CreatedDate = _page.CreatedDate,
                Id = _page.Id,
                ParentId = _page.Parent.Id,
                ParentTitle = _page.Parent.Title,
                Status = _page.Status,
                Title = _page.Title,
                SubTitle = _page.SubTitle,
                IconClass = _page.IconClass,
                FeatureImage = _page.FeatureImage,
                ExternalLink = _page.ExternalLink,
                UserId = _page.User.Id,
                UserName = _page.User.UserName
            }).Skip(page * count).Take(count).ToList();
        }


        public int Count
        {
            get { return _pages.Count(); }
        }


        public void Remove(int id)
        {
            _pages.Remove(_pages.Find(id));
        }


        public EditPageModel GetEditingData(int id)
        {
            return _pages.Where(page => page.Id == id).Select(page =>
                new EditPageModel
                {
                    Body = page.Body,
                    CommentStatus = page.CommentStatus,
                    Description = page.Description,
                    Id = page.Id,
                    Keyword = page.Keyword,
                    Order = page.Order,
                    ParentId = page.Parent.Id,
                    Status = page.Status,
                    Title = page.Title,
                    SubTitle = page.SubTitle,
                    IconClass = page.IconClass,
                    FeatureImage = page.FeatureImage,
                    ExternalLink = page.ExternalLink,
                }).FirstOrDefault();
        }


        public void Update(Page page)
        {
            Page selectedPage = _pages.Find(page.Id);
            selectedPage.Body = page.Body;
            selectedPage.CommentStatus = page.CommentStatus;
            selectedPage.Description = page.Description;
            selectedPage.Keyword = page.Keyword;
            selectedPage.ModifiedDate = page.ModifiedDate;
            selectedPage.Order = page.Order;
            selectedPage.Parent = page.Parent;
            selectedPage.Status = page.Status;
            selectedPage.Title = page.Title;
            selectedPage.SubTitle = page.SubTitle;
            selectedPage.IconClass = page.IconClass;
            selectedPage.ExternalLink = page.ExternalLink;
            selectedPage.EditedByUser = page.EditedByUser;
        }

        [CacheMethod(SecondsToCache = 600)]
        public IList<Page> GetNavBarData(Func<Page, bool> expression)
        {
            return
                _pages.AsNoTracking()
                    .Include(page => page.Children)
                    .ToList()
                    .Where(page => page.Parent == null)
                    .ToList();
        }

        public bool GetCommentStatus(int id)
        {
            return _pages.Find(id).CommentStatus;
        }


        public bool IsUserLikePage(int id, string userName)
        {
            return _pages.Find(id).LikedUsers.Any(user => user.UserName == userName);
        }


        public int Like(int id, User user)
        {
            int likeCount = _pages.Find(id).LikeCount += 1;
            _pages.Find(id).LikedUsers.Add(user);
            return likeCount;
        }


        public int DisLike(int id, User user)
        {
            int likeCount = _pages.Find(id).LikeCount -= 1;
            _pages.Find(id).LikedUsers.Add(user);
            return likeCount;
        }


        public void IncrementVisitedCount(int id)
        {
            _pages.Find(id).VisitedCount += 1;
        }
    }
}