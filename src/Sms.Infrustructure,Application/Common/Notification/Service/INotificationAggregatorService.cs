using Sms.Infrastructure.Domain.Common.Exeptions;
using Sms.Infrastructure.Domain.Entitys;
using Sms.Infrustructure.Application.Common.Notification.Model;
using Sms.Infrustructure.Application.Common.Notification.Model.Querying;

namespace Sms.Infrustructure.Application.Common.Notification.Service;

public interface INotificationAggregatorService
{
    ValueTask<FuncResult<bool>> SendAsync(
       NotificationRequest notificationRequest,
       CancellationToken cancellationToken = default
   );

    ValueTask<IList<NotificationTemplate>> GetTemplatesByFilterAsync(
        NotificationTemplateFilter filter,
        CancellationToken cancellationToken = default
    );
}
