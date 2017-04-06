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
using System.Web;
using System.IO;

namespace MyCMS.Web.Areas.Admin.Controllers
{
    public partial class TimeFrameController : Controller
    {
        private readonly ITimeFrameService _TimeFrameService;
        private readonly IUnitOfWork _uow;
        public TimeFrameController(IUnitOfWork uow, ITimeFrameService TimeFrameService, IUserService userService)
        {
            _uow = uow;
            _TimeFrameService = TimeFrameService;
        }
        public virtual ActionResult Index()
        {
            return PartialView(MVC.Admin.TimeFrame.Views._Index);
        }
        public virtual ActionResult GetDataTable()
        {
            var list = _TimeFrameService.GetAllTimeFrames();

            //List<TimeFrameModel> list = new List<TimeFrameModel>();

            return PartialView(MVC.Admin.TimeFrame.Views._DataTable, list);
        }


        public virtual JsonResult GetDropDown()
        {
            var list = _TimeFrameService.GetAllTimeFrames();


            return Json(list, JsonRequestBehavior.AllowGet);
        }
        //
        public virtual ActionResult uploadFile(HttpPostedFileBase PictureFile)
        {
                string tempFileName = "";
            try
            {
                var webPath = Server.MapPath("/Content/TimeFramePicture");

                var fileName = Path.GetFileName(PictureFile.FileName);
                var files = Directory.GetFiles(webPath).Select(Path.GetFileName);
                int count = 1;
                    tempFileName = fileName;
                foreach (var item in files)
                {

                    if (item == tempFileName)
                    {
                        var sd = item.Split('.');
                        tempFileName = sd[0] + "_" + count.ToString()+"."+sd[1];
                        count++;
                    }

                }

                PictureFile.SaveAs(Path.Combine(webPath, tempFileName));
                return Json(  new { text=tempFileName}, "text/plain" );
            }
            catch 
            {

                return JavaScript(tempFileName);
            }

        }
        public virtual ActionResult Create(TimeFrameModel model)
        {
            _TimeFrameService.AddTimeFrame(model);
            var sd = _uow.SaveChanges();
            return null;

        }
        public virtual ActionResult Update(TimeFrameModel model)
        {
            _TimeFrameService.UpdateTimeFrame(model);
            var sd = _uow.SaveChanges();
            return null;

        }
        public virtual ActionResult Delete(TimeFrameModel model)
        {
            _TimeFrameService.DeleteTimeFrame(model.Id);
            var sd = _uow.SaveChanges();

            return null;

        }
    }
}