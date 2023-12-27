using Sms.Infrastructure.Domain.Entitys;
using Sms.Infrustructure.Application.Common.Notification.Model.Querying;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Infrustructure.Application.Common.Notification.Service;
public interface IEmailHistoryService
{
    ValueTask<IList<EmailHistory>> GetByFilterAsync(
     FilterPagination paginationOptions,
     bool asNoTracking = false,
     CancellationToken cancellationToken = default
 );

    ValueTask<EmailHistory> CreateAsync(
        EmailHistory emailHistory,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );
}
