using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Infrastructure.Domain.Enum;
public enum NotificationTemplateType
{
    WelcomeNotification = 0,
    EmailAddressVerificationNotification = 1,
    PhoneNumberVerificationNotification = 2,
    ReferralNotification = 3,

    SystemWelcomeNotification,
    EmailVerificationNotification
}
