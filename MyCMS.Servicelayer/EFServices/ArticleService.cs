﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MyCMS.Datalayer.Context;
using MyCMS.DomainClasses.Entities;
using MyCMS.Model;
using MyCMS.Model.AdminModel;
using MyCMS.Model.SideBar;
using MyCMS.Servicelayer.EFServices.Enums;
using MyCMS.Servicelayer.Interfaces;
using MyCMS.Utilities.Caching;

namespace MyCMS.Servicelayer.EFServices
{
    public class ArticleService : IArticleService
    {
        private readonly IDbSet<Article> _articles;

        public ArticleService(IUnitOfWork uow)
        {
            _articles = uow.Set<Article>();
        }

        public void Add(Article article)
        {
            _articles.Add(article);
        }

        public void Update(Article article)
        {
            Article selectedArticle = _articles.Find(article.Id);
            selectedArticle.Body = article.Body;
            selectedArticle.Category = article.Category;
            selectedArticle.CommentStatus = article.CommentStatus;
            selectedArticle.Description = article.Description;
            selectedArticle.EditedByUser = article.EditedByUser;
            selectedArticle.Keyword = article.Keyword;
            selectedArticle.ModifiedDate = article.ModifiedDate;
            selectedArticle.Status = article.Status;
            selectedArticle.Title = article.Title;
        }

        public void Remove(int id)
        {
            _articles.Remove(_articles.Find(id));
        }

        public int Count
        {
            get { return _articles.Count(); }
        }

        public bool GetCommentStatus(int id)
        {
            return _articles.Find(id).CommentStatus;
        }

        public bool IsUserLikeArticle(int id, string userName)
        {
            return _articles.Find(id).LikedUsers.Any(user => user.UserName == userName);
        }

        public int Like(int id, User user)
        {
            int likeCount = _articles.Find(id).LikeCount += 1;
            _articles.Find(id).LikedUsers.Add(user);
            return likeCount;
        }

        public int DisLike(int id, User user)
        {
            int likeCount = _articles.Find(id).LikeCount -= 1;
            _articles.Find(id).LikedUsers.Add(user);
            return likeCount;
        }

        public void IncrementVisitedCount(int id)
        {
            _articles.Find(id).VisitedCount += 1;
        }

        public Article Find(int id)
        {
            return _articles.Find(id);
        }

        public IList<ArticleDataTableModel> GetDataTable(string term, int page, int count, Order order,
            ArticleOrderBy orderBy, ArticleSearchBy searchBy)
        {
            IQueryable<Article> selectedArticles = _articles.AsQueryable();

            if (!string.IsNullOrEmpty(term))
            {
                switch (searchBy)
                {
                    case ArticleSearchBy.Title:
                        selectedArticles = selectedArticles.Where(article => article.Title.Contains(term)).AsQueryable();
                        break;
                    case ArticleSearchBy.UserName:
                        selectedArticles =
                            selectedArticles.Where(article => article.User.UserName.Contains(term)).AsQueryable();
                        break;
                }
            }

            if (order == Order.Asscending)
            {
                switch (orderBy)
                {
                    case ArticleOrderBy.Title:
                        selectedArticles = selectedArticles.OrderBy(article => article.Title).AsQueryable();
                        break;
                    case ArticleOrderBy.Date:
                        selectedArticles = selectedArticles.OrderBy(article => article.CreatedDate).AsQueryable();
                        break;
                    case ArticleOrderBy.CommentCount:
                        selectedArticles = selectedArticles.OrderBy(article => article.Comments.Count).AsQueryable();
                        break;
                    case ArticleOrderBy.Status:
                        selectedArticles = selectedArticles.OrderBy(article => article.Status).AsQueryable();
                        break;
                    case ArticleOrderBy.UserName:
                        selectedArticles = selectedArticles.OrderBy(article => article.User.UserName).AsQueryable();
                        break;
                    case ArticleOrderBy.Order:
                        selectedArticles = selectedArticles.OrderBy(article => article.Category.Order).AsQueryable();
                        break;
                }
            }
            else
            {
                switch (orderBy)
                {
                    case ArticleOrderBy.Title:
                        selectedArticles = selectedArticles.OrderByDescending(article => article.Title).AsQueryable();
                        break;
                    case ArticleOrderBy.Date:
                        selectedArticles =
                            selectedArticles.OrderByDescending(article => article.CreatedDate).AsQueryable();
                        break;
                    case ArticleOrderBy.CommentCount:
                        selectedArticles =
                            selectedArticles.OrderByDescending(article => article.Comments.Count).AsQueryable();
                        break;
                    case ArticleOrderBy.Status:
                        selectedArticles = selectedArticles.OrderByDescending(article => article.Status).AsQueryable();
                        break;
                    case ArticleOrderBy.UserName:
                        selectedArticles =
                            selectedArticles.OrderByDescending(article => article.User.UserName).AsQueryable();
                        break;
                    case ArticleOrderBy.Order:
                        selectedArticles =
                            selectedArticles.OrderByDescending(article => article.Category.Order).AsQueryable();
                        break;
                }
            }

            return selectedArticles.Select(article => new ArticleDataTableModel
            {
                ArticleId = article.Id,
                ArticleStatus = article.Status,
                CommentStatus = article.CommentStatus,
                LikeCount = article.LikeCount,
                Title = article.Title,
                UserId = article.User.Id,
                UserName = article.User.UserName,
                VisitedCount = article.VisitedCount,
                CategoryId = article.Category.Id,
                CategoryName = article.Category.Name
            }).Skip(page * count).Take(count).ToList();
        }


        public AddUpdateArticleModel GetUpdateData(int id)
        {
            return _articles.Where(article => article.Id == id).Select(article => new AddUpdateArticleModel
            {
                ArticleStatus = article.Status,
                Body = article.Body,
                CategoryId = article.Category.Id,
                CommentStatus = article.CommentStatus,
                Description = article.Description,
                Title = article.Title,
                Id = article.Id,
                Keywords = article.Keyword
            }).FirstOrDefault();
        }

        

        [CacheMethod(SecondsToCache = 120)]
        public IList<CategoryModel> GetAnnounceData(int articleCount)
        {
            return
                _articles.AsNoTracking().Include(article => article.Category)
                    .Where(article => article.Category.Order == 0)
                    .OrderBy(article => article.Category.Order)
                    .Select(article => new CategoryModel
                    {
                        ArticleId = article.Id,
                        ArticleTitle = article.Title,
                        CategoryId = article.Category.Id,
                    }).Take(articleCount).ToList();
        }

        [CacheMethod(SecondsToCache = 10)]
        public IList<PostDetailModel> GetUserArticles(string userName, int page, int count)
        {
            return
                _articles.AsNoTracking()
                    .Where(article => article.User.UserName == userName)
                    .Select(article => new PostDetailModel
                    {
                        CommnetCount = article.Comments.Count,
                        Id = article.Id,
                        LikeCount = article.LikeCount,
                        PostedDate = article.CreatedDate,
                        Title = article.Title,
                        VisitedCount = article.VisitedCount
                    }).OrderByDescending(post => post.PostedDate).Skip(page * count).Take(count).ToList();
        }

        public int GetUserArticlesCount(string userName)
        {
            return _articles.Count(article => article.User.UserName == userName);
        }
    }
}