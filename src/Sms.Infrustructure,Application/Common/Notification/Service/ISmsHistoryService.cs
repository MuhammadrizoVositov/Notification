using Sms.Infrastructure.Domain.Entitys;
using Sms.Infrustructure.Application.Common.Notification.Model.Querying;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Infrustructure.Application.Common.Notification.Service;
public interface ISmsHistoryService
{
    ValueTask<IList<SmsHistory>> GetByFilterAsync(
      FilterPagination paginationOptions,
      bool asNoTracking = false,
      CancellationToken cancellationToken = default
  );

    ValueTask<SmsHistory> CreateAsync(
        SmsHistory smsHistory,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );
}
