using Sms.Infrastructure.Domain.Common.Exeptions;
using Sms.Infrastructure.Domain.Enum;
using Sms.Infrustructure.Application.Common.Notification.Model;

namespace Sms.Infrustructure.Application.Common.Notification.Service
{
    public interface ISmsOrchestrationService
    {
        ValueTask<FuncResult<bool>> SendAsync(
            SmsNotificationRequest request,
         NotificationTemplateType templateType,
         Dictionary<string, string> variables,
         CancellationToken cancellationToken = default
     );
    }
}
