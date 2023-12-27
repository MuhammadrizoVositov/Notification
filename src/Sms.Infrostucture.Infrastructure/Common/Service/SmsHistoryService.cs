using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Sms.Infrastructure.Domain.Entitys;
using Sms.Infrastructure.Domain.Enum;
using Sms.Infrastructure.Persistanse.Repsitory.Interface;
using Sms.Infrustructure.Application.Common.Notification.Model.Querying;
using Sms.Infrustructure.Application.Common.Notification.Service;
using Sms.Infrustructure.Application.Quering.Extension;
namespace Sms.Infrostucture.Infrastructure.Common.Service;
public class SmsHistoryService : ISmsHistoryService
{
    private readonly ISmsHistoryRepository _smsHistoryRepository;
    private readonly IValidator<SmsHistory> _smsHistoryValidator;

    public SmsHistoryService(ISmsHistoryRepository smsHistoryRepository, IValidator<SmsHistory> smsHistoryValidator)
    {
        _smsHistoryRepository = smsHistoryRepository;
        _smsHistoryValidator = smsHistoryValidator;
    }
    public async ValueTask<SmsHistory> CreateAsync(SmsHistory smsHistory, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var validationResult = await _smsHistoryValidator.ValidateAsync(smsHistory,
      options => options.IncludeRuleSets(EntityEvent.OnCreate.ToString()),
      cancellationToken);
        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

        return await _smsHistoryRepository.CreateAsync(smsHistory, saveChanges, cancellationToken);
    }

    public async ValueTask<IList<SmsHistory>> GetByFilterAsync(FilterPagination paginationOptions, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
       return await _smsHistoryRepository.Get().ApplyPagination(paginationOptions).ToListAsync(cancellationToken);
    }
}
