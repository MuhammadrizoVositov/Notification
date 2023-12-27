using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Infrustructure.Application.Common.Notification.Broker;

public interface ISmsSenderBroker
{
    ValueTask<bool> SendAsync(
        string senderPhoneNumber,
        string recivePhoneNumber,
        string massage,
        CancellationToken cancellationToken);
}
