using Sms.Infrastructure.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Infrastructure.Persistanse.Repsitory.Interface;
public interface IEmailHistoryRepository
{
    IQueryable<EmailHistory> Get(
    Expression<Func<EmailHistory, bool>>? predicate = default,
    bool asNoTracking = false
);

    ValueTask<EmailHistory> CreateAsync(
        EmailHistory emailHistory,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );
}
