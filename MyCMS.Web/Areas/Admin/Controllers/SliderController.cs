using System.Collections.Generic;
using System.Linq;
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
    public partial class SliderController : Controller
    {
        private readonly ISliderService _SliderService;
        private readonly IUnitOfWork _uow;
        private readonly IUserService _userService;

        public SliderController(IUnitOfWork uow, ISliderService SliderService, IUserService userService)
        {
            _uow = uow;
            _SliderService = SliderService;
            _userService = userService;
        }

        public virtual ActionResult Index()
        {
            return PartialView(MVC.Admin.Slider.Views._Index);
        }

        public virtual ActionResult GetSliderDataTable(int page = 0, int count = 10, Order order = Order.Descending,
            SliderOrderBy orderBy = SliderOrderBy.ById)
        {
            ViewBag.CurrentPage = page + 1;
            ViewBag.TotalRecords = _SliderService.GetSlidersCount();
            ViewBag.Count = count;
            return PartialView(MVC.Admin.Slider.Views._SliderDataTable,
                _SliderService.GetSliderDataTable(page, count, order, orderBy));
        }

        #region Add Slider

        [HttpGet]
        public virtual ActionResult Add()
        {
            var lstSliderStatus = new List<SelectListItem>
            {
                new SelectListItem {Text = "عادی", Value = "visible", Selected = true},
                new SelectListItem {Text = "پنهان", Value = "hidden"},
                new SelectListItem {Text = "پیش نویس", Value = "draft"},
                new SelectListItem {Text = "آرشیو", Value = "archive"}
            };
            ViewBag.SliderStatus = lstSliderStatus;

            return PartialView(MVC.Admin.Slider.Views._Add);
        }
        


        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult AddSlider(AddSliderModel SliderModel)
        {
            var lstSliderStatus = new List<SelectListItem>
            {
                new SelectListItem {Text = "عادی", Value = "visible", Selected = true},
                new SelectListItem {Text = "پنهان", Value = "hidden"},
                new SelectListItem {Text = "پیش نویس", Value = "draft"},
                new SelectListItem {Text = "آرشیو", Value = "archive"}
            };
            ViewBag.SliderStatus = lstSliderStatus;

            if (!ModelState.IsValid)
                return PartialView(MVC.Admin.Shared.Views._ValidationSummery);


            var Slider = new Slider
            {
                Priority = SliderModel.SliderPriority,
                CreatedDate = DateAndTime.GetDateTime(),
                Link = SliderModel.SliderLink,
                Picture = SliderModel.SliderPicture,
                Status = SliderModel.SliderStatus.ToString().ToLower(),
                Title = SliderModel.SliderTitle,
                EditedByUser = _userService.GetUserByUserName(User.Identity.Name)
            };


            Slider.User = _userService.GetUserByUserName(User.Identity.Name);

            _SliderService.AddSlider(Slider);
            _uow.SaveChanges();


            return PartialView(MVC.Admin.Shared.Views._Alert,
                new Alert { Message = "اسلاید جدید با موقیت در سیستم ثبت شد", Mode = AlertMode.Success });
        }

        #endregion

        #region Edit Slider

        [HttpGet]
        public virtual ActionResult EditSlider(int id)
        {
            EditSliderModel model = _SliderService.GetSliderForEdit(id);

            var lstSliderStatus = new List<SelectListItem>
            {
                new SelectListItem {Text = "عادی", Value = "visible"},
                new SelectListItem {Text = "پنهان", Value = "hidden"},
                new SelectListItem {Text = "پیش نویس", Value = "draft"},
                new SelectListItem {Text = "آرشیو", Value = "archive"}
            };
            ViewBag.SliderStatus = new SelectList(lstSliderStatus, "Value", "Text", model.SliderStatus);


            return PartialView(MVC.Admin.Slider.Views._EditSlider, model);
        }
        


        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult EditSlider(EditSliderModel SliderModel)
        {
            if (!ModelState.IsValid)
                return PartialView(MVC.Admin.Shared.Views._ValidationSummery);

            SliderModel.ModifiedDate = DateAndTime.GetDateTime();
            SliderModel.EditedByUser = _userService.GetUserByUserName(User.Identity.Name);
            
            UpdateSliderStatus status = _SliderService.UpdateSlider(SliderModel);

            if (status == UpdateSliderStatus.Successfull)
            {
                _uow.SaveChanges();

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

        #region Delete Slider

        [HttpGet]
        public virtual ActionResult ConfirmDelete(int id)
        {
            ViewBag.Id = id;
            ViewBag.EntityName = "اسلاید";
            ViewBag.DeleteActionName = MVC.Admin.Slider.ActionNames.Delete;
            ViewBag.ControllerName = MVC.Admin.Slider.Name;
            ViewBag.ReturnActionName = MVC.Admin.Slider.ActionNames.Index;
            return PartialView(MVC.Admin.Shared.Views._ConfirmDelete);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Delete(int id)
        {
            _SliderService.RemoveSliderById(id);
            _uow.SaveChanges();

            return PartialView(MVC.Admin.Shared.Views._Alert, new Alert { Message = "اسلاید مورد نظر با موفقیت حذف شد" });
        }

        #endregion
    }
}