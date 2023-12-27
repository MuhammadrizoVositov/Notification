using FluentValidation;
using Sms.Infrastructure.Domain.Entitys;
using Sms.Infrastructure.Domain.Enum;
using Sms.Infrustructure.Application.Common.Notification.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Infrostucture.Infrastructure.Common.Validators;
public class SmsMessageValidator: AbstractValidator<SmsMessage>
{
    public SmsMessageValidator()
    {
        RuleSet(NotificationEvent.OnRendering.ToString(),
            () =>
            {
                RuleFor(history => history.Template).NotNull();
                RuleFor(history => history.Variables).NotNull();
                RuleFor(history => history.Template.Content).NotNull().NotEmpty();
            });

        RuleSet(NotificationEvent.OnSending.ToString(),
            () =>
            {
                RuleFor(message => message.SenderPhoneNumber).NotNull().NotEmpty();
                RuleFor(history => history.ReceiverPhoneNumber).NotNull().NotEmpty();
                RuleFor(history => history.Message).NotNull().NotEmpty();
            });
    }
}
