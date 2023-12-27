using Sms.Infrastructure.Domain.Entitys;
using Sms.Infrastructure.Persistanse.DataContext;
using Sms.Infrastructure.Persistanse.Repsitory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Infrastructure.Persistanse.Repsitory;
public class UserSettingsRepository : EntityRepositoryBase<UserSettings, NotificationDbContext>, IUserSettingsRepository
{
    public UserSettingsRepository(NotificationDbContext dbContext) : base(dbContext)
    {
    }
    public  ValueTask<UserSettings?> GetByIdAsync(Guid userId, bool asNoTracking, CancellationToken cancellationToken)
    {
      return  base.GetByIdAsync(userId, asNoTracking, cancellationToken);
    }
}
