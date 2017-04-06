using CaptchaMvc.Attributes;
using CaptchaMvc.HtmlHelpers;
using System.Web.Mvc;
using MyCMS.Datalayer.Context;
using MyCMS.DomainClasses.Entities;
using MyCMS.Model;
using MyCMS.Servicelayer.Interfaces;
using MyCMS.Utilities.DateAndTime;
using MyCMS.Web.HtmlCleaner;

namespace MyCMS.Web.Controllers
{
    public partial class ContactUsController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IUnitOfWork _uow;
        private readonly IUserService _userService;
        private readonly IPageService _pageService;
        private readonly IOptionService _optionService;

        public ContactUsController(IUnitOfWork uow, IMessageService messageService, IUserService userService, IPageService pageService, IOptionService optionService)
        {
            _uow = uow;
            _messageService = messageService;
            _userService = userService;
            _pageService = pageService;
            _optionService = optionService;
        }

        [HttpGet]
        public virtual ActionResult Index()
        {
            var RoutingKey = "contact";
            var _page = _pageService.FindByExternalLink(RoutingKey);
            if (_page != null)
            {
                TempData["PageTitle"] = _page.Title ?? "تماس با ما";
                TempData["PageSubtitle"] = _page.SubTitle ?? "ارتباط با ما از طریق تلفن ، ایمیل و شبکه های اجتماعی";
                TempData["FeatureImage"] = _page.FeatureImage ?? "/Content/images/slider/swiper/1.jpg";
            }
            else
            {
                TempData["PageTitle"] = "تماس با ما";
                TempData["PageSubtitle"] = "ارتباط با ما از طریق تلفن ، ایمیل و شبکه های اجتماعی";
                TempData["FeatureImage"] = "/Content/images/slider/swiper/1.jpg";
            }
            ViewBag.CompanyAddress = _optionService.GetAll().CompanyAddress;
            ViewBag.Phone = _optionService.GetAll().Phone;
            ViewBag.Linkedin = _optionService.GetAll().Linkedin;
            ViewBag.Facebook = _optionService.GetAll().Facebook;
            ViewBag.GooglePlus = _optionService.GetAll().GooglePlus;
            ViewBag.eMail = _optionService.GetAll().eMail;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CaptchaVerify("کلمه وارد شده صحیح نمی باشد")]

        public virtual ActionResult Submit(ContactUsModel model)
        {
            if (!ModelState.IsValid || !this.IsCaptchaValid("Invalid captcha"))
            {
                return PartialView(MVC.Shared.Views._ValidationSummery, model);
            }

            _messageService.Add(new Message
            {
                AddedDate = DateAndTime.GetDateTime(),
                Body = model.Body.ToSafeHtml(),
                Subject = string.Format("{0} #[نام: ]{1}#[ایمیل: ]{2}#[تلفن: ]{3}#[نام شرکت: ]{4}#[واحد مربوطه: ]{5}#", model.Subject,model.Name,model.Email,model.Phone,model.CompanyName,model.Unit) ,
                IsAnswared = false,
                User = _userService.Find(User.Identity.Name)
            });
            _uow.SaveChanges();

            return PartialView(MVC.Shared.Views._Alert,
                new Alert { Mode = AlertMode.Success, Message = "پیغام شما با موفقیت برای ما ارسال شد." });
        }
    }
}