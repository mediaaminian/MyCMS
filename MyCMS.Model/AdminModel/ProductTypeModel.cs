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
    [Validator(typeof(ProductTypeValidation))]

    public class ProductTypeModel
    {
        public int Id { get; set; }
        [Display(Name = "عنوان")]

        public string Name { get; set; }
        [Display(Name = "اولویت")]

        public int Priority { get; set; }
        [Display(Name = "از نوع خدماتی می باشد")]

        public bool IsService { get; set; }
        [Display(Name = "تصویر")]

        public string Picture { get; set; }
        [Display(Name = "شرح محصول")]

        public string Brief { get; set; }
        [Display(Name = "توضحیات")]

        public string Description { get; set; }
        [Display(Name = "تعداد روزهای آزمایشی")]

        public int TrialDay { get; set; }
        [Display(Name = "مبلغ کنسلی")]

        public double CancelAmount { get; set; }
        [Display(Name = "تعداد روزهای برگرداندن مبلغ")]

        public int MoneyBackDay { get; set; }
        [Display(Name = "قابلیت کنسلی")]

        public bool IsCancelable { get; set; }
        [Display(Name = "گروه نوع محصول")]

        public int ProductTypeGroupID { get; set; }

        [Display(Name = "گروه نوع محصول")]

        public int ProductTypeGroupName { get; set; }


    }
}

