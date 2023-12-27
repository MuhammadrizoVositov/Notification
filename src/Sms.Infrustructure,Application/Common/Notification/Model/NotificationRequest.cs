using Sms.Infrastructure.Domain.Enum;

namespace Sms.Infrustructure.Application.Common.Notification.Model;
public class NotificationRequest
{
    public Guid? SenderUserId { get; set; } = null;

    public Guid ReceiverUserId { get; set; }

    public NotificationTemplateType TemplateType { get; set; }

    public NotificationType? Type { get; set; } = null;

    public Dictionary<string, string>? Variables { get; set; }

}