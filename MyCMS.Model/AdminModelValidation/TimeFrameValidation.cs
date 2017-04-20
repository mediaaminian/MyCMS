using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyCMS.Model.AdminModel;

namespace MyCMS.Model.Validation
{
    public class TimeFrameValidation : AbstractValidator<TimeFrameViewModel>
    {
        public TimeFrameValidation()
        {
            RuleFor(q => q.Title)

                .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");


            RuleFor(q => q.Priority)
                .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");

            RuleFor(q => q.Days)
                .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");

            RuleFor(q => q.Picture)
                .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");

            RuleFor(q => q.Status)
                .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");

            RuleFor(q => q.Link)
                .NotEmpty()
                .WithMessage("فیلد اجباری می باشد");


        }
    }
}
