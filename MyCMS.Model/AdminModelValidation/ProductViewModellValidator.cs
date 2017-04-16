using FluentValidation;
using MyCMS.Utilities.Localized;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCMS.Model
{
    public partial class ProductViewModelValidator : AbstractValidator<ProductViewModel>
    {
        public ProductViewModelValidator()
        {

            RuleFor(q => q.ProductTypeId)
                    .NotEmpty()
                    .WithMessage(ValidationResource.notempty_error)
                    .WithName(MyCMS.Utilities.Localized.LocalizedResource.Product_fk_ProductTypeId);

            RuleFor(q => q.Priority)
                    .NotEmpty()
                    .WithMessage(ValidationResource.notempty_error)
                    .WithName(MyCMS.Utilities.Localized.LocalizedResource.Product_Priority);

            RuleFor(q => q.Name)
                    .NotEmpty()
                    .WithMessage(ValidationResource.notempty_error)
                    .Length(1, 50)
                    .WithMessage(ValidationResource.length_error)
                    .WithName(MyCMS.Utilities.Localized.LocalizedResource.Product_Name);

            RuleFor(q => q.Status)
                    .NotEmpty()
                    .WithMessage(ValidationResource.notempty_error)
                    .WithName(MyCMS.Utilities.Localized.LocalizedResource.Product_Status);

        }

    }
}