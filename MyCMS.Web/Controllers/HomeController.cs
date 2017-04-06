using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MyCMS.Model;
using MyCMS.Servicelayer.Interfaces;
using MvcSiteMapProvider.Web;

namespace MyCMS.Web.Controllers
{
    public partial class HomeController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly IPageService _pageService;
        private readonly IPostService _postService;
        private readonly ISliderService _sliderService;
        private readonly IOptionService _optionService;

        public HomeController(IPostService postService, IBookService bookService, IPageService pageService,
            ICategoryService categoryService, ISliderService sliderService, IOptionService optionService)
        {
            _sliderService = sliderService;
            _postService = postService;
            _bookService = bookService;
            _pageService = pageService;
            _categoryService = categoryService;
            _optionService = optionService;
        }

        public virtual ActionResult Index()
        {
            ViewBag.CompanyAddress = _optionService.GetAll().CompanyAddress;
            ViewBag.Phone = _optionService.GetAll().Phone;
            ViewBag.Linkedin = _optionService.GetAll().Linkedin;
            ViewBag.Facebook = _optionService.GetAll().Facebook;
            //IList<BooksListModel> booksList = _postService.GetBooksList(0, 8);           
            return View();
        }

        public virtual ActionResult IFrame()
        {
            return View();
        }

        public virtual ActionResult Standalone()
        {
            return View();
        }
        [HttpPost]
        public virtual ActionResult BooksList(int page = 0, int count = 8)
        {
            //IList<BooksListModel> booksList = _postService.GetBooksList(page, count);
            //if (booksList == null || !booksList.Any())
            return Content("no-more");

            //return PartialView(MVC.Home.Views._BooksList, booksList);
        }

        //[OutputCache(Duration = 1200)]
        public virtual ActionResult Breadcrumb()
        {
            ViewBag.PageTitle = TempData != null ? TempData["PageTitle"] ?? "" : "";
            ViewBag.PageSubtitle = TempData != null ? TempData["PageSubtitle"] ?? "" : "";
            ViewBag.FeatureImage = TempData != null ? TempData["FeatureImage"] ?? "/Content/images/material/breadcrumb.jpg" : "/Content/images/material/breadcrumb.jpg";
            return PartialView(MVC.Home.Views._Breadcrumb);
        }
        [OutputCache(Duration = 1200)]
        public virtual ActionResult Slider()
        {
            var model = _sliderService.GetAllSliders();
            return PartialView(MVC.Home.Views._Slider, model);
        }
        [OutputCache(Duration = 1200)]
        public virtual ActionResult Telegram()
        {
            ViewBag.TelegramLink = _optionService.GetAll().Telegram;
            return PartialView(MVC.Home.Views._Telegram);
        }
        [OutputCache(Duration = 1200)]
        public virtual ActionResult FooterContactInfo()
        {
            ViewBag.CompanyAddress = _optionService.GetAll().CompanyAddress;
            ViewBag.Phone = _optionService.GetAll().Phone;
            return PartialView(MVC.Home.Views._FooterContactInfo);
        }

        public virtual ActionResult FooterSocialNetwork()
        {
            ViewBag.Linkedin = _optionService.GetAll().Linkedin;
            ViewBag.Facebook = _optionService.GetAll().Facebook;
            return PartialView(MVC.Home.Views._FooterSocialNetwork);
        }
        public virtual ActionResult NavBar()
        {
            return PartialView(MVC.Home.Views._NavBar);
        }

        [OutputCache(Duration = 900)]
        public virtual ActionResult NavbarItems()
        {
            return PartialView(MVC.Home.Views._NavBarItems, _pageService.GetNavBarData(page => page.Status == "visible"));
        }

        [OutputCache(Duration = 900)]
        public virtual ActionResult Announce()
        {
            return PartialView(MVC.Home.Views._Announce, _categoryService.GetAnnounceData(3));
        }

        public virtual ActionResult SiteMapXml()
        {
            return new XmlSiteMapResult();
        }
    }
}