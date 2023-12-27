using FluentValidation;
using Sms.Infrastructure.Domain.Entitys;
using Sms.Infrastructure.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Infrostucture.Infrastructure.Common.Validators;
public class SmsHistoryValidator : AbstractValidator<SmsHistory>
{
    public SmsHistoryValidator()
    {
        RuleSet(EntityEvent.OnCreate.ToString(),
        () =>
        {
            RuleFor(history => history.TemplateId).NotEqual(Guid.Empty);

            RuleFor(history => history.SenderUserId).NotEqual(Guid.Empty);

            RuleFor(history => history.ReceiverUserId).NotEqual(Guid.Empty);

            RuleFor(history => history.Content).NotEmpty().MaximumLength(129_536);

            RuleFor(history => history.ErrorMessage).NotNull().NotEmpty().When(history => !history.IsSuccessful);

            RuleFor(history => history.SenderPhoneNumber).NotEmpty().MaximumLength(64);

            RuleFor(history => history.ReceiverPhoneNumber).NotEmpty().MaximumLength(64);
        });
    }
}
