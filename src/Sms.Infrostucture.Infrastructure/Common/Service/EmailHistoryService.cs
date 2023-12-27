using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Sms.Infrastructure.Domain.Entitys;
using Sms.Infrastructure.Domain.Enum;
using Sms.Infrastructure.Persistanse.Repsitory.Interface;
using Sms.Infrustructure.Application.Common.Notification.Model.Querying;
using Sms.Infrustructure.Application.Common.Notification.Service;
using Sms.Infrustructure.Application.Quering.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Infrostucture.Infrastructure.Common.Service;
public class EmailHistoryService : IEmailHistoryService
{

    private readonly IEmailHistoryRepository _emailHistoryRepository;
    private readonly IValidator<EmailHistory> _emailHistoryValidator;

    public EmailHistoryService(IEmailHistoryRepository emailHistoryRepository, IValidator<EmailHistory> emailHistoryValidator)
    {
        _emailHistoryRepository = emailHistoryRepository;
        _emailHistoryValidator = emailHistoryValidator;
    }
    public async ValueTask<EmailHistory> CreateAsync(EmailHistory emailHistory, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var validationResult = await _emailHistoryValidator.ValidateAsync(emailHistory,
       options => options.IncludeRuleSets(EntityEvent.OnCreate.ToString()),
       cancellationToken);
        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

        return await _emailHistoryRepository.CreateAsync(emailHistory, saveChanges, cancellationToken);
    }

    public async ValueTask<IList<EmailHistory>> GetByFilterAsync(FilterPagination paginationOptions, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
      return  await _emailHistoryRepository.Get().ApplyPagination(paginationOptions).ToListAsync(cancellationToken);
    }
}
