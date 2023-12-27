using Sms.Infrastructure.Domain.Entitys;
using Sms.Infrastructure.Domain.Enum;
using Sms.Infrustructure.Application.Common.Notification.Model.Querying;

namespace Sms.Infrustructure.Application.Common.Notification.Service;
public interface ISmsTemplateService
{
    ValueTask<IList<SmsTemplate>> GetByFilterAsync(
    FilterPagination paginationOptions,
    bool asNoTracking = false,
    CancellationToken cancellationToken = default
);

    ValueTask<SmsTemplate?> GetByTypeAsync(
        NotificationTemplateType templateType,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    );

    ValueTask<SmsTemplate> CreateAsync(
        SmsTemplate smsTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );
}
