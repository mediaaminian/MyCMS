using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyCMS.Model.AdminModel;

namespace MyCMS.Model.Validation
{
    public class PropertyValidation : AbstractValidator<PropertyModel>
    {
        public PropertyValidation()
        {
            RuleFor(q => q.Name)

                .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");


            RuleFor(q => q.Priority)
                .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");

            RuleFor(q => q.DataType)
                .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");

            RuleFor(q => q.DefaultValue)
                .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");

            RuleFor(q => q.Status)
                .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");

            RuleFor(q => q.PropertyGroupID)
                .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");


        }
    }
}
