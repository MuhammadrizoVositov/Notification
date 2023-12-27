using Sms.Infrastructure.Domain.Enum;

namespace Sms.Infrustructure.Application.Common.Notification.Model;
public class SmsNotificationRequest : NotificationRequest
{
    public SmsNotificationRequest() => Type = NotificationType.Sms;
    public string SenderPhoneNumber { get; set; }
    public string ReceiverPhoneNumber { get; set; }
}
