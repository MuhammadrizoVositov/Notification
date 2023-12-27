using Sms.Infrastructure.Domain.Entitys;
using Sms.Infrastructure.Persistanse.Repsitory.Interface;
using Sms.Infrustructure.Application.Common.Identity.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Infrostucture.Infrastructure.Common.Identity.Service;
public class UserSettingsService:IUserSettingsService
{
    private readonly IUserSettingsRepository _userSettingsRepository;

    public UserSettingsService(IUserSettingsRepository userSettingsRepository)
    {
        _userSettingsRepository = userSettingsRepository;
    }

    public ValueTask<UserSettings?> GetByIdAsync(Guid userSettingsId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
     return   _userSettingsRepository.GetByIdAsync(userSettingsId, asNoTracking, cancellationToken);
    }
}
