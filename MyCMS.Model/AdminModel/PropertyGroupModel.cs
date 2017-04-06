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
    [Validator(typeof(PropertyGroupValidation))]

    public class PropertyGroupModel
    {
        public PropertyGroupModel()
        {
        }
        public virtual int ID { get; set; }
        [Display(Name = "وضعیت")]

        public byte Status { get; set; }
        [Display(Name = "عنوان")]

        public virtual string Name { get; set; }
        [Display(Name = "تصویر")]

        public virtual string Picture { get; set; }
        [Display(Name = "اولویت")]

        public virtual int Priority { get; set; }
        [Display(Name = "توضحیات")]

        public string Description { get; set; }
        [Display(Name = "گروه نوع محصول")]

        public int ProductTypeGroupID { get; set; }

        [Display(Name = "گروه نوع محصول")]

        public string ProductTypeGroupName { get; set; }


    }
}

