using FluentValidation;
using MyCMS.Utilities.Localized;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCMS.Model
{
    public partial class ProductTypeViewModelValidator : AbstractValidator<ProductTypeViewModel>
    {
        public ProductTypeViewModelValidator()
        {
            RuleFor(q => q.ProductTypeGroupId)
                            .NotEmpty()
                            .WithMessage(ValidationResource.notempty_error)
                            .WithName(MyCMS.Utilities.Localized.LocalizedResource.ProductType_ProductTypeGroup);


            RuleFor(q => q.Priority)
                .NotEmpty()
                .WithMessage(ValidationResource.notempty_error)
                .WithName(MyCMS.Utilities.Localized.LocalizedResource.ProductType_Priority);

            RuleFor(q => q.Name)
                            .NotEmpty()
                            .WithMessage(ValidationResource.notempty_error)
                            .WithName(MyCMS.Utilities.Localized.LocalizedResource.ProductType_Name)
                            .Length(1, 50)
                            .WithMessage(ValidationResource.length_error)
                            .WithName(MyCMS.Utilities.Localized.LocalizedResource.ProductType_Name);


            RuleFor(q => q.Status)
                            .NotEmpty()
                            .WithMessage(ValidationResource.notempty_error)
                            .WithName(MyCMS.Utilities.Localized.LocalizedResource.ProductType_Status);

            RuleFor(q => q.TrialDay)
                            .NotEmpty()
                            .WithMessage(ValidationResource.notempty_error)
                            .WithName(MyCMS.Utilities.Localized.LocalizedResource.ProductType_TrialDay);

            RuleFor(q => q.CancelAmount)
                            .NotEmpty()
                            .WithMessage(ValidationResource.notempty_error)
                            .WithName(MyCMS.Utilities.Localized.LocalizedResource.ProductType_CancelAmount);

            RuleFor(q => q.MoneyBackDay)
                           .NotEmpty()
                           .WithMessage(ValidationResource.notempty_error)
                           .WithName(MyCMS.Utilities.Localized.LocalizedResource.ProductType_MoneyBackDay);



        }

    }
}