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
public class EmailHistoryRepository : EntityRepositoryBase<EmailHistory, NotificationDbContext>, IEmailHistoryRepository
{
    public EmailHistoryRepository(NotificationDbContext dbContext) : base(dbContext)
    {

    }
    public async ValueTask<EmailHistory> CreateAsync(EmailHistory emailHistory, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        {
            if (emailHistory.EmailTemplate is not null)
                DbContext.Entry(emailHistory.EmailTemplate).State = EntityState.Unchanged;

            var createdHistory = await base.CreateAsync(emailHistory, saveChanges, cancellationToken);

            if (emailHistory.EmailTemplate is not null)
                DbContext.Entry(emailHistory.EmailTemplate).State = EntityState.Detached;

            return createdHistory;
        }
    }

    public IQueryable<EmailHistory> Get(Expression<Func<EmailHistory, bool>>? predicate = null, bool asNoTracking = false)
    {
      return  base.Get(predicate, asNoTracking);
    }
}
