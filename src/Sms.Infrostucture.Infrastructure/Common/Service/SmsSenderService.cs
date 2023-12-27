using Sms.Infrustructure.Application.Common.Notification.Broker;
using Sms.Infrustructure.Application.Common.Notification.Model;
using Sms.Infrustructure.Application.Common.Notification.Service;
using Twilio.TwiML.Messaging;

namespace Sms.Infrostucture.Infrastructure.Common.Service
{
    public class SmsSenderService : ISmsSenderService
    {
        private readonly IEnumerable<ISmsSenderBroker> _smsSenderBrokers;

        public SmsSenderService(IEnumerable<ISmsSenderBroker> smsSenderBrokers)
        {
            _smsSenderBrokers = smsSenderBrokers;
        }

        public async ValueTask<bool> SendAsync(SmsMessage smsMessage, CancellationToken cancellationToken = default)
        {
            var result = false;
            foreach (var smsSender in _smsSenderBrokers)
            {
                try
                {
                    result = await smsSender.SendAsync(smsMessage.SenderPhoneNumber, smsMessage.ReceiverPhoneNumber, smsMessage.Message, cancellationToken);
                    if (result) return result;
                }
                catch (Exception ex)
                {

                }
            }

            return result;
        }
    }
}
