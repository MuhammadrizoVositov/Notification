using Sms.Infrustructure.Application.Common.Notification.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Infrustructure.Application.Common.Notification.Service;
public interface IEmailRenderingService
{
    ValueTask<string> RenderAsync(
    EmailMessage emailMessage,
    // string template,
    // Dictionary<string, string> variables,
    CancellationToken cancellationToken = default
);
}
