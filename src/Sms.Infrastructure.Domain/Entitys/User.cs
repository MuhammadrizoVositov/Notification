using Sms.Infrastructure.Domain.Common.Entities;
using Sms.Infrastructure.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Infrastructure.Domain.Entitys
{
    public class User:IEntity
    {
        public Guid Id { get; set; }

        public string UserName { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public string EmailAddress { get; set; } = default!;

        public RoleType Role { get; set; }

        public UserSettings UserSettings { get; set; }
    }
}
