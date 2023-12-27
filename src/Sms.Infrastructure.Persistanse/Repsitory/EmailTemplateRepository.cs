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
public class EmailTemplateRepository : EntityRepositoryBase<EmailTemplate, NotificationDbContext>,
    IEmailTemplateRepository
{
    public EmailTemplateRepository(NotificationDbContext dbContext) : base(dbContext)
    {
    }
    public ValueTask<EmailTemplate> CreateAsync(EmailTemplate emailTemplate, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
      return  base.CreateAsync(emailTemplate, saveChanges, cancellationToken);
    }

    public IQueryable<EmailTemplate> Get(Expression<Func<EmailTemplate, bool>>? predicate = null, bool asNoTracking = false)
    {
      return  base.Get(predicate, asNoTracking);
    }
}
