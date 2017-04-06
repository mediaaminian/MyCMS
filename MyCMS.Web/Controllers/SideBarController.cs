﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MyCMS.DomainClasses.Entities;
using MyCMS.Model.SideBar;
using MyCMS.Servicelayer.Interfaces;

namespace MyCMS.Web.Controllers
{
    public partial class SideBarController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IBookService _bookService;
        private readonly ICommentService _commentService;
        private readonly ILabelService _labelService;
        private readonly IUserService _userService;

        public SideBarController(IBookService bookService, IUserService userService, ICommentService commentService,
            ILabelService labelService, ICategoryService categoryService)
        {
            _bookService = bookService;
            _userService = userService;
            _commentService = commentService;
            _labelService = labelService;
            _categoryService = categoryService;
        }

        public virtual ActionResult Index()
        {
            return PartialView(MVC.SideBar.Views._SideBar);
        }

        [OutputCache(Duration = 3600)]
        public virtual ActionResult Statistics()
        {
            var model = new SideBarModel
            {
                BookCount = _bookService.Count,
                CommentCount = _commentService.Count,
                UserCount = _userService.Count,
                ActiveUsersNumber = _userService.GetLastMonthActiveUsersCount()
            };
            return PartialView(MVC.SideBar.Views._Statistics, model);
        }

        [OutputCache(Duration = 900)]
        public virtual ActionResult Labels()
        {
            var model = _labelService.GetAll().OrderBy(label => label.Name);
            return PartialView(MVC.SideBar.Views._Labels, model);
        }

        [OutputCache(Duration = 900)]
        public virtual ActionResult Categories()
        {
            var model = _categoryService.GetSideBarData();
            return PartialView(MVC.SideBar.Views._Categories, model);
        }
    }
}