﻿using FluentValidation;
using Sms.Infrastructure.Domain.Entitys;
using Sms.Infrastructure.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Infrostucture.Infrastructure.Common.Validators;
public class SmsTemplateValidator : AbstractValidator<SmsTemplate>
{
    public SmsTemplateValidator()
    {
        RuleFor(template => template.Content)
            .NotEmpty()
            .WithMessage("Sms template content is required")
            .MinimumLength(10)
            .WithMessage("Sms template content must be at least 10 characters long")
            .MaximumLength(256)
            .WithMessage("Sms template content must be at most 256 characters long");

        RuleFor(template => template.Type)
            .Equal(NotificationType.Sms)
            .WithMessage("Sms template notification type must be Sms");
    }
}
