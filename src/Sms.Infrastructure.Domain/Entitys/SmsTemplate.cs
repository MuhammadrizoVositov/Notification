using Sms.Infrastructure.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sms.Infrastructure.Domain.Entitys;
public class SmsTemplate:NotificationTemplate
{
    public SmsTemplate()
    {
        Type = NotificationType.Sms;
    }
}
