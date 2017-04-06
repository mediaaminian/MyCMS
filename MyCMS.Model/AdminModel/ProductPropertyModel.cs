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
    [Validator(typeof(ProductPropertyValidation))]

    public class ProductPropertyModel
    {
        public int Id { get; set; }
        [Display(Name = "مقدار")]

        public string Value { get; set; }
        [Display(Name = "مقدار پیش فرض")]

        public bool UseDefaultValue { get; set; }
        [Display(Name = "محصول")]

        public int ProductID { get; set; }
        [Display(Name = "ویژگی")]

        public int PropertyID { get; set; }
        [Display(Name = "وضعیت")]

        public byte Status { get; set; }
    }
}

