using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyCMS.Model.AdminModel;

namespace MyCMS.Model.Validation
{
    public class PropertyGroupValidation : AbstractValidator<PropertyGroupModel>
    {
        public PropertyGroupValidation()
        {
            RuleFor(q => q.Status)

                           .NotEmpty()
                           .WithMessage("لطفا فیلد را پر نمایید").WithName("وضعیت");
            

            RuleFor(q => q.Name)
               .NotEmpty()
               .WithMessage("لطفا فیلdddد را پر نمایید").WithName("عنوان");
            RuleFor(q => q.Picture)
   .NotEmpty()
   .WithMessage("لطفا فیلدddd را پر نمایید").WithName("آیکن");
        }
    }
}
