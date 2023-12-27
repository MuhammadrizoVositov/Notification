using Sms.Infrastructure.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Infrustructure.Application.Common.Identity.Service;
public interface IUserService
{
    ValueTask<IList<User>> GetByIdsAsync(
    IEnumerable<Guid> usersId,
    bool asNoTracking = false,
    CancellationToken cancellationToken = default
);

    ValueTask<User?> GetSystemUserAsync(bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<User?> GetByIdAsync(
        Guid userId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    );
}
