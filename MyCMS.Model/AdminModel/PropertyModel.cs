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
    [Validator(typeof(PropertyValidation))]

    public class PropertyModel
    {
        public int Id { get; set; }
        [Display(Name ="عنوان")]
        public string Name { get; set; }
        [Display(Name = "اولویت")]

        public int Priority { get; set; }
        [Display(Name = "در جزئیات محصول نمایش داده شود")]

        public bool IsVisibleInProductDetail { get; set; }
        [Display(Name = "در هشدارها نمایش داده شود")]

        public bool IsVisibleInNotification { get; set; }
        [Display(Name = "در تبلیغات نمایش داده شود")]

        public bool IsVisibleInAdvertisements { get; set; }
        [Display(Name = "قابل فیلتر می باشد")]

        public bool IsFilterable { get; set; }
        [Display(Name = "نوع داده")]

        public byte DataType { get; set; }
        [Display(Name = "مقدار پیش فرض")]

        public string DefaultValue { get; set; }
        [Display(Name = "توضیحات")]

        public string Description { get; set; }
        [Display(Name = "وضعیت")]

        public byte Status { get; set; }
        [Display(Name = "گروه ویژگی")]

        public int PropertyGroupID { get; set; }
        [Display(Name = "گروه ویژگی")]


        public string PropertyGroupName { get; set; }
    }
}

