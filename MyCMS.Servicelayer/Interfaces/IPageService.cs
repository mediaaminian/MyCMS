using System;
using System.Collections.Generic;
using MyCMS.DomainClasses.Entities;
using MyCMS.Model.AdminModel;
using MyCMS.Servicelayer.EFServices.Enums;

namespace MyCMS.Servicelayer.Interfaces
{
    public class PageDropDownList
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public interface IPageService
    {
        int Count { get; }
        void Add(Page page);
        Page Find(int id);
        Page FindByExternalLink(string ExternalLink);
        IList<Page> GetAll();
        IList<PageDropDownList> DropDownListData();
        IList<PageDropDownList> DropDownListData(int id);

        IList<PageDataTableModel> GetDataTable(string term, int page, int count,
            Order order, PageOrderBy orderBy, PageSearchBy searchBy);

        void Remove(int id);
        EditPageModel GetEditingData(int id);
        void Update(Page page);
        IList<Page> GetNavBarData(Func<Page, bool> expression);
        bool GetCommentStatus(int id);
        bool IsUserLikePage(int id, string userName);
        int Like(int id, User user);
        int DisLike(int id, User user);
        void IncrementVisitedCount(int id);
    }
}