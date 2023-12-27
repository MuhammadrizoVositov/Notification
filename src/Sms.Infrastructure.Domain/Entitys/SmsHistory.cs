using Sms.Infrastructure.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Infrastructure.Domain.Entitys;
public class SmsHistory:NotificationHistory
{
    public SmsHistory()
    {
        Type = NotificationType.Sms;
    }

    public string SenderPhoneNumber { get; set; } = default!;

    public string ReceiverPhoneNumber { get; set; } = default!;

    [NotMapped]
    public SmsTemplate SmsTemplate
    {
        get => Template is not null ? Template as SmsTemplate : null;
        set => Template = value;
    }
}
