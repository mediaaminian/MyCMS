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
    [Validator(typeof(ProductValidation))]

    public class ProductModel
    {
        public int Id { get; set; }

        [Display(Name = "عنوان")]
        public string Name { get; set; }

        [Display(Name = "اولویت")]
        public int Priority { get; set; }

        [Display(Name = "تصویر")]
        public string Picture { get; set; }

        [Display(Name = "شرح محصول")]
        public string Brief { get; set; }

        [Display(Name = "توضحیات")]
        public string Description { get; set; }

        [Display(Name = "توضیحات سفارش")]
        public string OrderDescription { get; set; }

        [Display(Name = "محصول جانبی")]
        public bool IsExtra { get; set; }

        [Display(Name = "خاص می باشد")]
        public bool IsSpecial { get; set; }

        [Display(Name = "وضعیت")]
        public byte Status { get; set; }

        [Display(Name = "نوع محصول")]
        public int ProductTypeID { get; set; }

        [Display(Name = "نوع محصول")]
        public string ProductTypeName { get; set; }

        [Display(Name = "گروه محصول")]
        public int ProductTypeGroupID { get; set; }

        [Display(Name = "گروه محصول")]
        public string ProductTypeGroupName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int UserID { get; set; }


        //public int EditedByUserID { get; set; }

    }
}

