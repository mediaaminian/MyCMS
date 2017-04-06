using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyCMS.Model.AdminModel;

namespace MyCMS.Model.Validation
{
    public class ProductTypeGroupTimeFrameValidation : AbstractValidator<ProductTypeGroupTimeFrameModel>
    {
        public ProductTypeGroupTimeFrameValidation()
        {
            RuleFor(q => q.Status)
                .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");

            RuleFor(q => q.ProductTypeGroupID)
               .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");

            RuleFor(q => q.TimeFrameID)
                .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");

        }
    }
}
