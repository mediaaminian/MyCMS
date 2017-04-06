using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using MyCMS.Model.Validation;
using System.Web;

namespace MyCMS.Model.AdminModel
{
    [Validator(typeof(TimeFrameValidation))]

    public class TimeFrameModel
    {
        public int Id { get; set; }
        [Display(Name ="عنوان")]
        public string Title { get; set; }
        [Display(Name = "وضعیت")]

        public byte Status { get; set; }
        [Display(Name = "تعداد روزها")]

        public byte Days { get; set; }
        [Display(Name = "اولویت")]

        public int Priority { get; set; }
        [Display(Name = "تصویر")]

        public string Picture { get; set; }
        [Display(Name = "لینک")]

        public string Link { get; set; }

        public HttpPostedFileBase TimeFramePicture { get; set; }


    }
}

