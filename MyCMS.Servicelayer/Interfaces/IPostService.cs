using System;
using System.Collections.Generic;
using MyCMS.DomainClasses.Entities;
using MyCMS.Model;
using MyCMS.Model.AdminModel;
using MyCMS.Model.RSSModel;
using MyCMS.Servicelayer.EFServices.Enums;

namespace MyCMS.Servicelayer.Interfaces
{
    public interface IPostService
    {
        int Count { get; }
        void AddPost(Post post);
        void RemovePostById(int id);
        Post GetPostById(int id);
        Post GetPostDataById(int id);
        IList<Post> GetAllPosts();
        IList<Post> GetPosts(Func<Post, bool> expression);

        IList<PostDataTableModel> GetPostsByExpression(Func<Post, bool> expression);
        PostStatus GetPostStatusById(long id);

        IList<PostDataTableModel> GetPostDataTable(int page, int count, Order order = Order.Asscending,
            PostOrderBy orderBy = PostOrderBy.ById,int skip = 0);

        int GetPostsCount();
        EditPostModel GetPostForEdit(int id);
        UpdatePostStatus UpdatePost(EditPostModel postModel);
        //IList<BooksListModel> GetBooksList(int page, int count);
        //IList<BooksListModel> GetBooksList(int labelId, int page, int count);
        PostModel GetPost(int id);
        void IncrementVisitedNumber(int id);
        //bool IsUserLikePost(int postId, int userId);
        //bool IsUserLikePost(int postId, string userName);
        //int Like(int id, User user);
        //int DisLike(int id, User user);
        Post Find(int id);
        //bool GetCommentStatus(int postId);
        IList<RssPostModel> GetRssPosts(int count);
        IList<PostDetailModel> GetUserPosts(string userName, int page, int count);
        IList<PostDataTableModel> GetPosts(int page, int count ,int skip = 0);
        PostDataTableModel GetLastPost();
        int GetUserPostsCount(string userName);
        IList<SiteMapModel> GetSiteMapData(int count);
    }
}