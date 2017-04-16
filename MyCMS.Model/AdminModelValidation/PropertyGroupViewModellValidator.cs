using FluentValidation;
using MyCMS.Utilities.Localized;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCMS.Model
{
    public partial class PropertyGroupViewModelValidator : AbstractValidator<PropertyGroupViewModel>
    {
        public PropertyGroupViewModelValidator()
        {
            RuleFor(q => q.Name)
                            .NotEmpty()
                            .WithMessage(ValidationResource.notempty_error)
                            .WithName(MyCMS.Utilities.Localized.LocalizedResource.PropertyGroup_Name)
                            .Length(1, 200)
                            .WithMessage(ValidationResource.length_error)
                            .WithName(MyCMS.Utilities.Localized.LocalizedResource.PropertyGroup_Name);

            RuleFor(q => q.Status)
                            .NotEmpty()
                            .WithMessage(ValidationResource.notempty_error)
                            .WithName(MyCMS.Utilities.Localized.LocalizedResource.Status);

            RuleFor(q => q.ProductTypeGroupId)
                            .NotEmpty()
                            .WithMessage(ValidationResource.notempty_error)
                            .WithName(MyCMS.Utilities.Localized.LocalizedResource.PropertyGroup_fk_ProductTypeGroupID);


        }

    }
}