using Sms.Infrastructure.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Infrastructure.Persistanse.Repsitory.Interface;
public interface IEmailTemplateRepository
{
    IQueryable<EmailTemplate> Get(
     Expression<Func<EmailTemplate, bool>>? predicate = default,
     bool asNoTracking = false
 );

    ValueTask<EmailTemplate> CreateAsync(
        EmailTemplate emailTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );
}
