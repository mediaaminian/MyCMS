using System.IO;
using System.Web;
using System.Web.Mvc;

namespace MyCMS.Web.Areas.Admin.Controllers
{
    public partial class FileController : Controller
    {
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult AvatarImage(string imageName)
        {
            return File(Server.MapPath("~/App_Data/UsersAvatars/" + imageName), "gif");
        }
        ///// <summary>
        ///// ذخيره سازي خودكار
        ///// </summary>
        //[HttpPost]
        //[ValidateInput(false)]
        //public virtual ActionResult FroalaAutoSave(string body, int? postId) // نام پارامتر بادي را تغيير ندهيد
        //{
        //    body = body.ToSafeHtml();

        //    //todo: save body ...
        //    return new EmptyResult();
        //}


        // todo: مسايل امنيتي آپلود را فراموش نكنيد
        /// <summary>
        /// ذخيره سازي تصاوير ارسالي
        /// </summary>
        [HttpPost]
        public virtual ActionResult FroalaUploadImage(HttpPostedFileBase file) // نام پارامتر فايل را تغيير ندهيد
        {
            var fileName = Path.GetFileName(file.FileName);
            var rootPath = Server.MapPath("~/images/");
            file.SaveAs(Path.Combine(rootPath, fileName));
            return Json(new { link = "images/" + fileName }, JsonRequestBehavior.AllowGet);
        }

        // todo: مسايل امنيتي آپلود را فراموش نكنيد
        /// <summary>
        /// ذخيره سازي فايل‌هاي ارسالي
        /// </summary>
        [HttpPost]
        public virtual ActionResult FroalaUploadFile(HttpPostedFileBase file) // نام پارامتر فايل را تغيير ندهيد
        {
            var fileName = Path.GetFileName(file.FileName);
            var rootPath = Server.MapPath("~/files/");
            file.SaveAs(Path.Combine(rootPath, fileName));
            return Json(new { link = "files/" + fileName }, JsonRequestBehavior.AllowGet);
        }
    }
}