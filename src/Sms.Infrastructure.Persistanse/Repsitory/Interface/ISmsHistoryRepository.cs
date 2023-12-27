using Sms.Infrastructure.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Infrastructure.Persistanse.Repsitory.Interface;
public interface ISmsHistoryRepository
{
    IQueryable<SmsHistory> Get(
      Expression<Func<SmsHistory, bool>>? predicate = default,
      bool asNoTracking = false
  );

    ValueTask<SmsHistory> CreateAsync(
        SmsHistory smsHistory,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );
}
