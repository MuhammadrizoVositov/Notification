using Sms.Infrastructure.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Infrastructure.Domain.Entitys;
public class EmailTemplate : NotificationTemplate
{
    public EmailTemplate()
    {
        Type = NotificationType.Email;
    }

    public string Subject { get; set; } = default!;
}
