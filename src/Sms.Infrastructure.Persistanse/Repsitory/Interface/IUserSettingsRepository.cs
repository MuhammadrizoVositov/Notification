using Sms.Infrastructure.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Infrastructure.Persistanse.Repsitory.Interface;
public interface IUserSettingsRepository
{
    ValueTask<UserSettings?> GetByIdAsync(
    Guid userId,
    bool asNoTracking = false,
    CancellationToken cancellationToken = default
);
}
