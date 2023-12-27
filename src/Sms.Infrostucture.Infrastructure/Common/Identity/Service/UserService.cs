using Microsoft.EntityFrameworkCore;
using Sms.Infrastructure.Domain.Entitys;
using Sms.Infrastructure.Domain.Enum;
using Sms.Infrastructure.Persistanse.Repsitory.Interface;
using Sms.Infrustructure.Application.Common.Identity.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Infrostucture.Infrastructure.Common.Identity.Service;
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
     return   _userRepository.GetByIdAsync(userId, asNoTracking, cancellationToken);
    }

    public ValueTask<IList<User>> GetByIdsAsync(IEnumerable<Guid> usersId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
      return  _userRepository.GetByIdsAsync(usersId, asNoTracking, cancellationToken);
    }

    public async ValueTask<User?> GetSystemUserAsync(bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return await _userRepository.Get(user => user.Role == RoleType.System, asNoTracking)
         .Include(user => user.UserSettings)
         .SingleOrDefaultAsync(cancellationToken);
    }
}
