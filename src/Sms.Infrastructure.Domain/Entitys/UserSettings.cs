using Sms.Infrastructure.Domain.Common.Entities;
using Sms.Infrastructure.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Infrastructure.Domain.Entitys;
public class UserSettings:IEntity
{
    public Guid Id { get; set; }

    public NotificationType? PreferredNotificationType { get; set; }
}
