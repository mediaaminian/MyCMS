using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyCMS.Model.AdminModel;

namespace MyCMS.Model.Validation
{
    public class ProductTypeGroupValidation : AbstractValidator<ProductTypeGroupModel>
    {
        public ProductTypeGroupValidation()
        {
            RuleFor(q => q.Name)
                .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");

            RuleFor(q => q.AppKey)
               .NotEmpty()
               .WithMessage("فیلد اجباری می باشد");

            RuleFor(q => q.Priority)
                .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");

            RuleFor(q => q.Brief)
                .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");


        }
    }
}
