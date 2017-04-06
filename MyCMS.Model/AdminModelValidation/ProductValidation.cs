using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyCMS.Model.AdminModel;

namespace MyCMS.Model.Validation
{
    public class ProductValidation : AbstractValidator<ProductModel>
    {
        public ProductValidation()
        {
            RuleFor(q => q.Name)
                .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");

            RuleFor(q => q.Priority)
               .NotEmpty()
               .WithMessage("فیلد اجباری می باشد");

            RuleFor(q => q.Picture)
                .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");

            RuleFor(q => q.Brief)
                .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");
            RuleFor(q => q.OrderDescription)
                .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");
            RuleFor(q => q.Status)
                .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");

            RuleFor(q => q.ProductTypeGroupID)
                 .NotEmpty()
                 .WithMessage("فیلد اجباری می باشد");

            RuleFor(q => q.ProductTypeID)
                .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");


        }
    }
}
