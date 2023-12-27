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
public class SmsTemplateRepository : EntityRepositoryBase<SmsTemplate, NotificationDbContext>, ISmsTemplateRepository
{
    public SmsTemplateRepository(NotificationDbContext dbContext) : base(dbContext)
    {
    }
   public ValueTask<SmsTemplate> CreateAsync(SmsTemplate smsTemplate, bool saveChanges, CancellationToken cancellationToken)
    {
      return  base.CreateAsync(smsTemplate, saveChanges, cancellationToken);
    }

    public   IQueryable<SmsTemplate> Get(Expression<Func<SmsTemplate, bool>>? predicate, bool asNoTracking)
    {
     return   base.Get(predicate, asNoTracking);
    }
}
