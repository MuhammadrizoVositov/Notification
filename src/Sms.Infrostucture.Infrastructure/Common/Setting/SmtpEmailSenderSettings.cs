using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Infrostucture.Infrastructure.Common.Setting;
public class SmtpEmailSenderSettings
{
    public string Host { get; set; } = default!;

    public int Port { get; set; }

    public string CredentialAddress { get; set; } = default!;

    public string Password { get; set; } = default!;
}
