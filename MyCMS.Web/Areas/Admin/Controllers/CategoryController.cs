﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MyCMS.Datalayer.Context;
using MyCMS.DomainClasses.Entities;
using MyCMS.Model.AdminModel;
using MyCMS.Servicelayer.EFServices.Enums;
using MyCMS.Servicelayer.Interfaces;
using MyCMS.Web.Filters;
using MyCMS.Web.Helpers;

namespace MyCMS.Web.Areas.Admin.Controllers
{
    [SiteAuthorize(Roles = "admin,moderator")]
    public partial class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IUnitOfWork _uow;

        public CategoryController(IUnitOfWork uow, ICategoryService categoryService)
        {
            _uow = uow;
            _categoryService = categoryService;
        }

        public virtual ActionResult Index()
        {
            return PartialView(MVC.Admin.Category.Views._Index);
        }

        public virtual ActionResult DataTable(string term = "", int page = 0, int count = 10,
            Order order = Order.Descending, CategoryOrderBy orderBy = CategoryOrderBy.Id,
            CategorySearchBy searchBy = CategorySearchBy.Name)
        {
            ViewBag.CurrentPage = page;
            ViewBag.Count = count;

            ViewBag.TERM = term;
            ViewBag.PAGE = page;
            ViewBag.COUNT = count;
            ViewBag.ORDER = order;
            ViewBag.ORDERBY = orderBy;
            ViewBag.SEARCHBY = searchBy;

            var selectListOrderBy = new List<SelectListItem>
            {
                new SelectListItem {Text = "تاریخ", Value = "Id"},
                new SelectListItem {Text = "نام", Value = "Name"},
            };

            ViewBag.OrderByItems = new SelectList(selectListOrderBy, "Value", "Text", orderBy);

            ViewBag.OrderByList = DropDownList.OrderList(order);

            ViewBag.CountList = DropDownList.CountList(count);

            IList<CategoryDataTableModel> model = _categoryService.GetDataTable(term, page, count, order, orderBy,
                searchBy);

            ViewBag.TotalRecords = (string.IsNullOrEmpty(term)) ? _categoryService.Count : model.Count;

            return PartialView(MVC.Admin.Category.Views._DataTable, model);
        }

        public virtual ActionResult AutoCompleteSearch(string term)
        {
            //var result = _labelService.GetLabels(label => label.Name.Contains(term))
            //    .Select(label => new { label = label.Name }).ToList();
            //return Json(result, JsonRequestBehavior.AllowGet);
            throw new NotImplementedException();
        }

        [HttpGet]
        public virtual ActionResult Add()
        {
            var model = new Category { Order = _categoryService.GetMaxOrder() + 1 };
            return PartialView(MVC.Admin.Category.Views._Add, model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Add(Category category)
        {
            if (_categoryService.IsExistByName(category.Name))
            {
                return PartialView(MVC.Admin.Shared.Views._Alert,
                    new Alert { Message = "گروهی با این نام موجود می باشد", Mode = AlertMode.Error });
            }
            if (category.Order != 0 && _categoryService.IsExistByOrder(category.Order ?? 0))
            {
                return PartialView(MVC.Admin.Shared.Views._Alert,
                    new Alert { Message = "گروهی با این ترتیب موجود می باشد", Mode = AlertMode.Error });
            }

            _categoryService.Add(category);
            _uow.SaveChanges();
            return PartialView(MVC.Admin.Shared.Views._Alert,
                new Alert
                {
                    Message = "گروه جدید با موفقیت در سیستم ثبت شد",
                    Mode = AlertMode.Success
                });
        }

        [HttpGet]
        public virtual ActionResult ConfirmDelete(int id)
        {
            ViewBag.Id = id;
            ViewBag.EntityName = "دسته بندی";
            ViewBag.DeleteActionName = MVC.Admin.Category.ActionNames.Delete;
            ViewBag.ControllerName = MVC.Admin.Category.Name;
            ViewBag.ReturnActionName = MVC.Admin.Category.ActionNames.Index;
            return PartialView(MVC.Admin.Shared.Views._ConfirmDelete);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Delete(int id)
        {
            _categoryService.Remove(id);
            _uow.SaveChanges();
            return PartialView(MVC.Admin.Shared.Views._Alert,
                new Alert { Message = "گروه مورد نظر با موفقیت حذف شد", Mode = AlertMode.Success });
        }

        [HttpGet]
        public virtual ActionResult Edit(int id)
        {
            Category selectedCategory = _categoryService.Find(id);
            return PartialView(MVC.Admin.Category.Views._Edit, selectedCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(Category model)
        {
            _categoryService.Update(model);
            _uow.SaveChanges();
            return PartialView(MVC.Admin.Shared.Views._Alert,
                new Alert
                {
                    Message = "گروه مورد نظر با موفقیت ویرایش شد",
                    Mode = AlertMode.Success
                });
        }
    }
}