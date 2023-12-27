using Sms.Infrustructure.Application.Common.Notification.Model;

namespace Sms.Infrustructure.Application.Common.Notification.Service;

public interface ISmsSenderService
{
    ValueTask<bool> SendAsync(SmsMessage smsMessage, CancellationToken cancellationToken = default);
}
