using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyCMS.Model.AdminModel;

namespace MyCMS.Model.Validation
{
    public class ProductPropertyValidation : AbstractValidator<ProductPropertyModel>
    {
        public ProductPropertyValidation()
        {
            RuleFor(q => q.Value)
               .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");

            RuleFor(q => q.ProductID)
               .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");
            RuleFor(q => q.PropertyID)
                .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");
            RuleFor(q => q.Status)
                .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");
        }
    }
}
