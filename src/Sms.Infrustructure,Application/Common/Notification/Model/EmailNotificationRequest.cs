using Sms.Infrastructure.Domain.Enum;

namespace Sms.Infrustructure.Application.Common.Notification.Model;
public class EmailNotificationRequest : NotificationRequest
{
    public EmailNotificationRequest() => Type = NotificationType.Email;
}
