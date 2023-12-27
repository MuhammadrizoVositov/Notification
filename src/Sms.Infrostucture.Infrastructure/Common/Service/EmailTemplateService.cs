using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Sms.Infrastructure.Domain.Entitys;
using Sms.Infrastructure.Domain.Enum;
using Sms.Infrastructure.Persistanse.Repsitory.Interface;
using Sms.Infrustructure.Application.Common.Notification.Model.Querying;
using Sms.Infrustructure.Application.Common.Notification.Service;
using Sms.Infrustructure.Application.Quering.Extension;
using System.Linq.Expressions;
namespace Sms.Infrostucture.Infrastructure.Common.Service;
public class EmailTemplateService : IEmailTemplateService
{
    private readonly IEmailTemplateRepository _emailTemplateRepository;
    private readonly IValidator<EmailTemplate> _emailTemplateValidator;

    public EmailTemplateService(
        IEmailTemplateRepository emailTemplateRepository,
        IValidator<EmailTemplate> emailTemplateValidator
    )
    {
        _emailTemplateRepository = emailTemplateRepository;
        _emailTemplateValidator = emailTemplateValidator;
    }
    public IQueryable<EmailTemplate> Get(
    Expression<Func<EmailTemplate, bool>>? predicate = default,
    bool asNoTracking = false
) =>
    _emailTemplateRepository.Get(predicate, asNoTracking);
    public ValueTask<EmailTemplate> CreateAsync(EmailTemplate emailTemplate, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var validationResult = _emailTemplateValidator.Validate(emailTemplate);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return _emailTemplateRepository.CreateAsync(emailTemplate, saveChanges, cancellationToken);
    }

    public async ValueTask<IList<EmailTemplate>> GetByFilterAsync(FilterPagination paginationOptions, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
     return   await Get(asNoTracking: asNoTracking)
        .ApplyPagination(paginationOptions)
        .ToListAsync(cancellationToken: cancellationToken);
    }

    public async ValueTask<EmailTemplate?> GetByTypeAsync(NotificationTemplateType templateType, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
       return await _emailTemplateRepository.Get(template => template.TemplateType.Equals(templateType), asNoTracking)
            .SingleOrDefaultAsync(cancellationToken);
    }
}
