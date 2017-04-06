using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyCMS.Model.AdminModel;

namespace MyCMS.Model.Validation
{
    public class ProductTypeValidation : AbstractValidator<ProductTypeModel>
    {
        public ProductTypeValidation()
        {
            RuleFor(q => q.Name)
                .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");

            RuleFor(q => q.Priority)
                .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");

            RuleFor(q => q.Brief)
                .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");

            RuleFor(q => q.TrialDay)
                .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");

            RuleFor(q => q.CancelAmount)
                .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");

            RuleFor(q => q.MoneyBackDay)
                .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");

            RuleFor(q => q.ProductTypeGroupID)
                .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");


        }
    }
}
