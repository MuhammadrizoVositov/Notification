﻿using FluentValidation;
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
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Infrostucture.Infrastructure.Common.Service;
public class SmsTemplateService : ISmsTemplateService
{
    private readonly ISmsTemplateRepository _smsTemplateRepository;
    private readonly IValidator<SmsTemplate> _smsTemplateValidator;

    public SmsTemplateService(
        ISmsTemplateRepository smsTemplateRepository,
        IValidator<SmsTemplate> smsTemplateValidator
    )
    {
        _smsTemplateRepository = smsTemplateRepository;
        _smsTemplateValidator = smsTemplateValidator;
    }
    public IQueryable<SmsTemplate> Get(
       Expression<Func<SmsTemplate, bool>>? predicate = default,
       bool asNoTracking = false
   ) =>
       _smsTemplateRepository.Get(predicate, asNoTracking);
    public ValueTask<SmsTemplate> CreateAsync(SmsTemplate smsTemplate, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var validationResult = _smsTemplateValidator.Validate(smsTemplate);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return _smsTemplateRepository.CreateAsync(smsTemplate, saveChanges, cancellationToken);
    }

    public async ValueTask<IList<SmsTemplate>> GetByFilterAsync(FilterPagination paginationOptions, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
      return  await Get(asNoTracking: asNoTracking)
           .ApplyPagination(paginationOptions)
           .ToListAsync(cancellationToken: cancellationToken);
    }

    public async ValueTask<SmsTemplate?> GetByTypeAsync(NotificationTemplateType templateType, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
      return  await _smsTemplateRepository.Get(template => template.TemplateType == templateType, asNoTracking)
             .SingleOrDefaultAsync(cancellationToken);
    }
}
