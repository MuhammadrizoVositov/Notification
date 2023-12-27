using Sms.Infrustructure.Application.Common.Notification.Broker;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Sms.Infrostucture.Infrastructure.Common.Notifications.Broker;

public class TwilioSmsSenderBroker :ISmsSenderBroker
{
    public ValueTask<bool>SendAsync(
        string senderPhoneNumber,
        string reciverPhoneNumber,
        string massage,
        CancellationToken cancellationToken)
    {
        var test = "6637bedcaeb5fa7234479b78d847cdd1-968d4909-0be6-492a-8c95-b593752d522c";
        var test2 = "6F947CA563B5F79B24F26A06E121605B";

        TwilioClient.Init(test, test2);

        var messageContent = MessageResource.Create
            (
                body: massage,
                from: new Twilio.Types.PhoneNumber(senderPhoneNumber),
                to: new Twilio.Types.PhoneNumber(reciverPhoneNumber)

            );
        return new ValueTask<bool>(true);
    }
}
