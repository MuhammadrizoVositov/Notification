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
public class UserRepository : EntityRepositoryBase<User, NotificationDbContext>, IUserRepository
{
    public UserRepository(NotificationDbContext dbContext) : base(dbContext)
    {
    }
   public IQueryable<User>Get(Expression<Func<User, bool>>? predicate, bool asNoTracking)
    {
         return   base.Get(predicate, asNoTracking);
    }

    public ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking, CancellationToken cancellationToken)
    {
      return  base.GetByIdAsync(userId, asNoTracking, cancellationToken);
    }

    ValueTask<IList<User>> IUserRepository.GetByIdsAsync(IEnumerable<Guid> usersId, bool asNoTracking, CancellationToken cancellationToken)
    {
        return base.GetByIdsAsync(usersId, asNoTracking, cancellationToken);
    }
}
