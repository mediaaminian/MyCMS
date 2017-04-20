using FluentValidation;
using MyCMS.Utilities.Localized;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCMS.Model
{
    public class TimeFrameViewModelValidator : AbstractValidator<TimeFrameViewModel>
    {
        public TimeFrameViewModelValidator()
        {

            RuleFor(q => q.Days.ToInt())
                            .GreaterThan(0)
                            .WithMessage(ValidationResource.greaterthan_error)
                            .WithName(LocalizedResource.TimeFrame_Days);

            RuleFor(q => q.Priority)
                            .NotEmpty()
                            .WithMessage(ValidationResource.notempty_error)
                            .WithName(LocalizedResource.TimeFrame_Priority);

            RuleFor(q => q.Status)
                            .NotEmpty()
                            .WithMessage(ValidationResource.notempty_error)
                            .WithName(LocalizedResource.TimeFrame_Status);

        }
    }
}
