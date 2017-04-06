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
    [Validator(typeof(ProductTypeGroupTimeFrameValidation))]

    public class ProductTypeGroupTimeFrameModel
    {
        public int Id { get; set; }

        [Display(Name = "وضعیت")]

        public byte Status { get; set; }

        [Display(Name = "گروه نوع محصول")]

        public int ProductTypeGroupID { get; set; }

        [Display(Name = "تایم فریم")]

        public int TimeFrameID { get; set; }

        [Display(Name = "گروه نوع محصول")]

        public string ProductTypeGroupName { get; set; }

        [Display(Name = "تایم فریم")]

        public string TimeFrameName { get; set; }
    }
}

