using FluentValidation;
using MyCMS.Utilities.Localized;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCMS.Model
{
    public partial class PropertyViewModelValidator : AbstractValidator<PropertyViewModel>
    {
        public PropertyViewModelValidator()
        {

            RuleFor(q => q.PropertyGroupId)
                            .NotEmpty()
                            .WithMessage(ValidationResource.notempty_error)
                            .WithName(MyCMS.Utilities.Localized.LocalizedResource.Property_fk_PropertyGroupId);



            RuleFor(q => q.DataType)
                .NotEmpty()
                .WithMessage(ValidationResource.notempty_error)
                .WithName(MyCMS.Utilities.Localized.LocalizedResource.Property_DataType);


            RuleFor(q => q.Name)
                            .NotEmpty()
                            .WithMessage(ValidationResource.notempty_error)
                            .WithName(MyCMS.Utilities.Localized.LocalizedResource.Property_Name)
                            .Length(1, 50)
                            .WithMessage(ValidationResource.length_error)
                            .WithName(MyCMS.Utilities.Localized.LocalizedResource.Property_Name);

            RuleFor(q => q.Priority)
                            .NotEmpty()
                            .WithMessage(ValidationResource.notempty_error)
                            .WithName(MyCMS.Utilities.Localized.LocalizedResource.Property_Priority);

            RuleFor(q => q.Status)
                .NotEmpty()
                .WithMessage(ValidationResource.notempty_error)
                .WithName(MyCMS.Utilities.Localized.LocalizedResource.Property_Status);



        }

    }
}