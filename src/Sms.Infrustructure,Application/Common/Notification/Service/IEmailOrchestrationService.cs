using Sms.Infrastructure.Domain.Common.Exeptions;
using Sms.Infrustructure.Application.Common.Notification.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Infrustructure.Application.Common.Notification.Service;
public interface IEmailOrchestrationService
{
    ValueTask<FuncResult<bool>> SendAsync(
    EmailNotificationRequest request,
    CancellationToken cancellationToken = default
);
}
