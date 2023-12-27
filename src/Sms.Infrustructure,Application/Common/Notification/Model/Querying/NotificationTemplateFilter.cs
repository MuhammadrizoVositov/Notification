using Sms.Infrastructure.Domain.Enum;

namespace Sms.Infrustructure.Application.Common.Notification.Model.Querying
{
    public class NotificationTemplateFilter : FilterPagination
    {
        public IList<NotificationType> TemplateType { get; set; }
    }
}
