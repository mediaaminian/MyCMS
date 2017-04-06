using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MyCMS.Datalayer.Context;
using MyCMS.DomainClasses.Entities;
using MyCMS.Model;
using MyCMS.Model.AdminModel;
using MyCMS.Model.RSSModel;
using MyCMS.Servicelayer.EFServices.Enums;
using MyCMS.Servicelayer.Interfaces;
using MyCMS.Utilities.Caching;
using AutoMapper;
namespace MyCMS.Servicelayer.EFServices
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IDbSet<Currency> _Currencys;

        public CurrencyService(IUnitOfWork uow)
        {
            _Currencys = uow.Set<Currency>();
        }

        public void AddCurrency(Currency Currency)
        {
            _Currencys.Add(Currency);
        }

        public void RemoveCurrencyById(int id)
        {
            _Currencys.Remove(_Currencys.Find(id));
        }

        public EditCurrencyModel GetCurrencyForEdit(int id)
        {
            EditCurrencyModel CurrencyModel =
                _Currencys.Where(Currency => Currency.Id == id)
                    .Select(
                        Currency =>
                            new EditCurrencyModel
                            {
                                CurrencyId = Currency.Id,
                                CurrencyKeyword = Currency.Keyword,
                                CurrencyTitle = Currency.Title,
                                CurrencyStatus = Currency.Status,
                                CurrencyIcon = Currency.Icon,
                                CurrencyPrice = Currency.Price,
                                CurrencyPriority = Currency.Priority,
                                ModifiedDate = DateTime.Now,
                                EditedByUser = Currency.User
                            })
                    .FirstOrDefault();
            return CurrencyModel;
        }


        public UpdateCurrencyStatus UpdateCurrency(EditCurrencyModel CurrencyModel)
        {
            Currency selectedCurrency = _Currencys.Find(CurrencyModel.CurrencyId);

            selectedCurrency.Keyword = CurrencyModel.CurrencyKeyword;
            selectedCurrency.ModifiedDate = CurrencyModel.ModifiedDate;
            selectedCurrency.Status = CurrencyModel.CurrencyStatus;
            selectedCurrency.Title = CurrencyModel.CurrencyTitle;
            selectedCurrency.Priority = CurrencyModel.CurrencyPriority;
            selectedCurrency.Price = CurrencyModel.CurrencyPrice;
            selectedCurrency.ModifiedDate = DateTime.Now;
            selectedCurrency.Icon = CurrencyModel.CurrencyIcon;

            return UpdateCurrencyStatus.Successfull;
        }



        [CacheMethod(SecondsToCache = 20)]
        public CurrencyModel GetCurrency(int id)
        {
            return _Currencys.AsNoTracking().Where(Currency => Currency.Id == id).Select(Currency => new CurrencyModel
            {
                Id = Currency.Id,
                Keyword = Currency.Keyword,
                Title = Currency.Title,
                Icon = Currency.Icon,
                Price = Currency.Price,
                Priority = Currency.Priority,
            }).FirstOrDefault();
        }


        public int Count
        {
            get { return _Currencys.Count(); }
        }


        public Currency Find(int id)
        {
            return _Currencys.Find(id);
        }


        [CacheMethod(SecondsToCache = 300)]
        public IList<RssCurrencyModel> GetRssCurrencys(int count)
        {
            return _Currencys.AsNoTracking().Select(Currency => new RssCurrencyModel
            {
                Title = Currency.Title,
                Keyword = Currency.Keyword,
                Price = Currency.Price,
                ModifiedDate = Currency.ModifiedDate

            }).OrderByDescending(Currency => Currency.Title).Take(count).ToList();
        }

        [CacheMethod]
        public IList<CurrencyModel> GetUserCurrency(string userName, int page, int count)
        {
            return
                _Currencys.AsNoTracking().Where(Currency => Currency.User.UserName == userName).Select(Currency => new CurrencyModel
                {
                    Id = Currency.Id,
                    Title = Currency.Title,
                    Price = Currency.Price,
                    Keyword = Currency.Keyword,
                    Icon = Currency.Icon,
                    Priority = Currency.Priority
                }).OrderByDescending(Currency => Currency.Priority).Skip(page * count).Take(count).ToList();
        }


        public int GetUserCurrencysCount(string userName)
        {
            return _Currencys.Count(Currency => Currency.User.UserName == userName);
        }

        [CacheMethod(SecondsToCache = 300)]
        public IList<SiteMapModel> GetSiteMapData(int count)
        {
            return _Currencys.AsNoTracking().OrderByDescending(Currency => Currency.CreatedDate).Take(count).
                Select(Currency => new SiteMapModel
                {
                    Id = Currency.Id,
                    CreatedDate = Currency.CreatedDate,
                    ModifiedDate = Currency.ModifiedDate,
                    Title = Currency.Title
                }).ToList();
        }

        #region Get Currencys Data

        public Currency GetCurrencyById(int id)
        {
            return _Currencys.Find(id);
        }


        public IList<CurrencyModel> GetAllCurrency()
        {
            return
                _Currencys.AsNoTracking().Select(Currency => new CurrencyModel
                {
                    Id = Currency.Id,
                    Title = Currency.Title,
                    Price = Currency.Price,
                    Keyword = Currency.Keyword,
                    Icon = Currency.Icon,
                    Priority = Currency.Priority
                }).ToList();
        }
        public IList<Currency> GetAllCurrencys()
        {
            return _Currencys.ToList();
        }

        [CacheMethod(SecondsToCache = 120)]
        public IList<Currency> GetCurrencys(Func<Currency, bool> expression)
        {
            return _Currencys.Where(expression).ToList();
        }

        [CacheMethod]
        public Currency GetCurrencyDataById(int id)
        {
            return _Currencys.Where(x => x.Id == id).Include(x => x.User).FirstOrDefault();
        }

        #endregion

        #region Get Currency Status

        public CurrencyStatus GetCurrencyStatusById(long id)
        {
            const CurrencyStatus status = CurrencyStatus.Visible;
            //if (selectedCurrency.Status == "visible")
            //{
            //    status = CurrencyStatus.Visible;
            //}
            //else if (selectedCurrency.Status == "hidden")
            //{
            //    status = CurrencyStatus.Hidden;
            //}
            //else if (selectedCurrency.Status == "draft")
            //{
            //    status = CurrencyStatus.Draft;
            //}
            return status;
        }

        public IList<CurrencyDataTableModel> GetCurrencyDataTable(int page, int count, Order order = Order.Asscending,
            CurrencyOrderBy orderBy = CurrencyOrderBy.ById)
        {
            IQueryable<CurrencyDataTableModel> lstCurrencys =
                _Currencys.Include(Currency => Currency.User)
                    .Select(
                        Currency =>
                            new CurrencyDataTableModel
                            {
                                Id = Currency.Id,
                                Title = Currency.Title,
                                Priority = Currency.Priority,
                                Status = Currency.Status,
                                Price = Currency.Price,
                                Icon = Currency.Icon,
                                Keyword = Currency.Keyword
                            })
                    .AsQueryable();

            if (order == Order.Asscending)
            {
                switch (orderBy)
                {
                    case CurrencyOrderBy.ById:
                        lstCurrencys = lstCurrencys.OrderBy(Currency => Currency.Id).AsQueryable();
                        break;
                    case CurrencyOrderBy.ByTitle:
                        lstCurrencys = lstCurrencys.OrderBy(Currency => Currency.Title).AsQueryable();
                        break;
                    case CurrencyOrderBy.ByPriority:
                        lstCurrencys = lstCurrencys.OrderBy(Currency => Currency.Priority).AsQueryable();
                        break;
                    case CurrencyOrderBy.ByPrice:
                        lstCurrencys = lstCurrencys.OrderBy(Currency => Currency.Price).AsQueryable();
                        break;
                    case CurrencyOrderBy.ByKeyword:
                        lstCurrencys = lstCurrencys.OrderBy(Currency => Currency.Keyword).AsQueryable();
                        break;
                }
            }
            else
            {
                switch (orderBy)
                {
                    case CurrencyOrderBy.ById:
                        lstCurrencys = lstCurrencys.OrderByDescending(Currency => Currency.Id).AsQueryable();
                        break;
                    case CurrencyOrderBy.ByTitle:
                        lstCurrencys = lstCurrencys.OrderByDescending(Currency => Currency.Title).AsQueryable();
                        break;
                    case CurrencyOrderBy.ByPriority:
                        lstCurrencys = lstCurrencys.OrderByDescending(Currency => Currency.Priority).AsQueryable();
                        break;
                    case CurrencyOrderBy.ByPrice:
                        lstCurrencys = lstCurrencys.OrderByDescending(Currency => Currency.Price).AsQueryable();
                        break;
                    case CurrencyOrderBy.ByKeyword:
                        lstCurrencys = lstCurrencys.OrderByDescending(Currency => Currency.Keyword).AsQueryable();
                        break;
                }
            }
            return lstCurrencys.Skip(page * count).Take(count).ToList();
        }


        public int GetCurrencysCount()
        {
            return _Currencys.Count();
        }

        #endregion
    }
}