using System.Collections.Generic;
using MyCMS.DomainClasses.Entities;
using MyCMS.Model;
using MyCMS.Model.AdminModel;
using MyCMS.Model.SideBar;
using MyCMS.Servicelayer.EFServices.Enums;

namespace MyCMS.Servicelayer.Interfaces
{
    public interface IArticleService
    {
        int Count { get; }
        void Add(Article article);
        void Update(Article article);
        void Remove(int id);
        bool GetCommentStatus(int id);
        bool IsUserLikeArticle(int id, string userName);
        int Like(int id, User user);
        int DisLike(int id, User user);
        void IncrementVisitedCount(int id);
        Article Find(int id);

        IList<ArticleDataTableModel> GetDataTable(string term, int page, int count,
            Order order, ArticleOrderBy orderBy, ArticleSearchBy searchBy);

        AddUpdateArticleModel GetUpdateData(int id);
        
        IList<CategoryModel> GetAnnounceData(int articleCount = 10);
        IList<PostDetailModel> GetUserArticles(string userName, int page, int count);
        int GetUserArticlesCount(string userName);
    }
}