using FluentValidation;
using MyCMS.Utilities.Localized;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCMS.Model
{
    public partial class ProductTypeGroupViewModelValidator : AbstractValidator<ProductTypeGroupViewModel>
    {
        public ProductTypeGroupViewModelValidator()
        {

            RuleFor(q => q.Name)
                            .NotEmpty()
                            .WithMessage(ValidationResource.notempty_error)
                            .WithName(MyCMS.Utilities.Localized.LocalizedResource.ProductTypeGroup_Name)
                            .Length(1, 50)
                            .WithMessage(ValidationResource.length_error)
                            .WithName(MyCMS.Utilities.Localized.LocalizedResource.ProductTypeGroup_Name);

            RuleFor(q => q.Priority)
                            .NotEmpty()
                            .WithMessage(ValidationResource.notempty_error)
                            .WithName(MyCMS.Utilities.Localized.LocalizedResource.ProductTypeGroup_Priority);


            RuleFor(q => q.Status)
                            .NotEmpty()
                            .WithMessage(ValidationResource.notempty_error)
                            .WithName(MyCMS.Utilities.Localized.LocalizedResource.ProductTypeGroup_Status);

            RuleFor(q => q.AppKey)
                            .NotEmpty()
                            .WithMessage(ValidationResource.notempty_error)
                            .WithName(MyCMS.Utilities.Localized.LocalizedResource.ProductTypeGroup_AppKey);

            RuleFor(q => q.TimeFrameId)
                .NotEmpty()
                .WithMessage(ValidationResource.notempty_error)
                .WithName(MyCMS.Utilities.Localized.LocalizedResource.ProductTypeGroup_fk_TimeFrameId); 
        }

    }
}