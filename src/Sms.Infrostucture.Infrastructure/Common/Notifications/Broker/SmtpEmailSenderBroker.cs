using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Sms.Infrustructure.Application.Common.Notification.Model;
using Sms.Infrustructure.Application.Common.Notification.Broker;
using Sms.Infrostucture.Infrastructure.Common.Setting;
using Microsoft.Extensions.Options;

namespace Sms.Infrostucture.Infrastructure.Common.Notifications.Broker;
public class SmtpEmailSenderBroker : IEmailSenderBroker
{
    private readonly SmtpEmailSenderSettings _smtpEmailSenderSettings;

    public SmtpEmailSenderBroker(IOptions<SmtpEmailSenderSettings> smtpEmailSenderSettings)
    {
        _smtpEmailSenderSettings = smtpEmailSenderSettings.Value;
    }
    public ValueTask<bool> SendAsync(EmailMessage emailMessage, CancellationToken cancellationToken = default)
    {
        emailMessage.SendEmailAddress ??= _smtpEmailSenderSettings.CredentialAddress;

        var mail = new MailMessage(emailMessage.SendEmailAddress, emailMessage.ReceiverEmailAddress);
        mail.Subject = emailMessage.Subject;
        mail.Body = emailMessage.Body;
        mail.IsBodyHtml = true;

        var smtpClient = new SmtpClient(_smtpEmailSenderSettings.Host, _smtpEmailSenderSettings.Port);
        smtpClient.Credentials =
            new NetworkCredential(_smtpEmailSenderSettings.CredentialAddress, _smtpEmailSenderSettings.Password);
        smtpClient.EnableSsl = true;

        smtpClient.Send(mail);

        return new ValueTask<bool>(true);
    }
}
