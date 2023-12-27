using Sms.Infrastructure.Domain.Entitys;
using Sms.Infrastructure.Domain.Enum;
using Sms.Infrustructure.Application.Common.Notification.Model.Querying;

namespace Sms.Infrustructure.Application.Common.Notification.Service;
public interface IEmailTemplateService
{
    ValueTask<IList<EmailTemplate>> GetByFilterAsync(
      FilterPagination paginationOptions,
      bool asNoTracking = false,
      CancellationToken cancellationToken = default
  );

    ValueTask<EmailTemplate?> GetByTypeAsync(
        NotificationTemplateType templateType,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    );

    ValueTask<EmailTemplate> CreateAsync(
        EmailTemplate emailTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );
}
