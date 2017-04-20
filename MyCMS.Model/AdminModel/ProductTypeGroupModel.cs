using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using MyCMS.Model.Validation;

namespace MyCMS.Model.AdminModel
{
    [Validator(typeof(ProductTypeGroupValidation))]

    public class ProductTypeGroupModel
    {
        public int Id { get; set; }
        [Display(Name = "عنوان")]

        public string Name { get; set; }
        [Display(Name = "کلید")]

        public string AppKey { get; set; }
        [Display(Name = "اولویت")]

        public int Priority { get; set; }
        [Display(Name = "از نوع خدماتی می باشد")]

        public bool IsService { get; set; }
        [Display(Name = "قابل موجود برای سفارش")]

        public bool IsAvailableToOrder { get; set; }
        [Display(Name = "تصویر")]

        public string Picture { get; set; }
        [Display(Name = "شرح محصول")]

        public string Brief { get; set; }
        [Display(Name = "توضحیات")]

        public string Description { get; set; }
        [Display(Name = "تایم فریم پیش فرض")]

        public int TimeFrameId { get; set; }

        [Display(Name = "تایم فریم پیش فرض")]

        public string TimeFrameName { get; set; }
    }
}

