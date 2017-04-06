using System;
using System.Collections.Generic;
using MyCMS.DomainClasses.Entities;
using MyCMS.Model;
using MyCMS.Model.AdminModel;
using MyCMS.Model.RSSModel;
using MyCMS.Servicelayer.EFServices.Enums;

namespace MyCMS.Servicelayer.Interfaces
{
    public interface ICurrencyService
    {
        int Count { get; }
        void AddCurrency(Currency Currency);
        void RemoveCurrencyById(int id);
        Currency GetCurrencyById(int id);
        Currency GetCurrencyDataById(int id);
        IList<CurrencyModel> GetAllCurrency();
        IList<Currency> GetAllCurrencys();
        IList<Currency> GetCurrencys(Func<Currency, bool> expression);
        CurrencyStatus GetCurrencyStatusById(long id);

        IList<CurrencyDataTableModel> GetCurrencyDataTable(int page, int count, Order order = Order.Asscending,
            CurrencyOrderBy orderBy = CurrencyOrderBy.ById);

        int GetCurrencysCount();
        EditCurrencyModel GetCurrencyForEdit(int id);
        UpdateCurrencyStatus UpdateCurrency(EditCurrencyModel CurrencyModel);
        IList<CurrencyModel> GetUserCurrency(string userName, int page, int count);
        CurrencyModel GetCurrency(int id);
        Currency Find(int id);
        IList<RssCurrencyModel> GetRssCurrencys(int count);
    }
}