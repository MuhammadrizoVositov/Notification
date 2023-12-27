using Microsoft.EntityFrameworkCore;
using Sms.Infrastructure.Domain.Entitys;
using Sms.Infrastructure.Persistanse.DataContext;
using Sms.Infrastructure.Persistanse.Repsitory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Infrastructure.Persistanse.Repsitory;
public class SmsHistoryRepository : EntityRepositoryBase<SmsHistory, NotificationDbContext>, ISmsHistoryRepository
{
    public SmsHistoryRepository(NotificationDbContext dbContext) : base(dbContext)
    {
    }
    public async  ValueTask<SmsHistory> CreateAsync(SmsHistory smsHistory, bool saveChanges, CancellationToken cancellationToken)
    {
        {
            if (smsHistory.SmsTemplate is not null)
                DbContext.Entry(smsHistory.SmsTemplate).State = EntityState.Unchanged;

            var createdHistory = await base.CreateAsync(smsHistory, saveChanges, cancellationToken);

            if (smsHistory.SmsTemplate is not null)
                DbContext.Entry(smsHistory.SmsTemplate).State = EntityState.Detached;

            return createdHistory;
        }
    }

    public IQueryable<SmsHistory> Get(Expression<Func<SmsHistory, bool>>? predicate, bool asNoTracking)
    {
      return  base.Get(predicate, asNoTracking);
    }
}

