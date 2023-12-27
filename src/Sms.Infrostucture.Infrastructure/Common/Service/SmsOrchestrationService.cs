using AutoMapper;
using Sms.Infrastructure.Domain.Common.Exeptions;
using Sms.Infrastructure.Domain.Entitys;
using Sms.Infrastructure.Domain.Enum;
using Sms.Infrastructure.Domain.Extensions;
using Sms.Infrastructure.Persistanse.DataContext;
using Sms.Infrustructure.Application.Common.Identity.Service;
using Sms.Infrustructure.Application.Common.Notification.Model;
using Sms.Infrustructure.Application.Common.Notification.Service;
using System.Text;
using System.Text.RegularExpressions;

namespace Sms.Infrostucture.Infrastructure.Common.Service;

public class SmsOrchestrationService : ISmsOrchestrationService
{
    private readonly IMapper _mapper;
    private readonly ISmsSenderService _smsSenderService;
    private readonly ISmsHistoryService _smsHistoryService;
    private readonly NotificationDbContext _dbContext;
    private readonly IUserService _userService;
    private readonly ISmsTemplateService _smsTemplateService;
    private readonly ISmsRenderingService _smsRenderingService;

    public SmsOrchestrationService(
        IMapper mapper,
        ISmsTemplateService smsTemplateService,
        ISmsRenderingService smsRenderingService,
        ISmsSenderService smsSenderService,
        ISmsHistoryService smsHistoryService,
        NotificationDbContext dbContext,
        IUserService userService
    )
    {
        _mapper = mapper;
        _smsTemplateService = smsTemplateService;
        _smsRenderingService = smsRenderingService;
        _smsSenderService = smsSenderService;
        _smsHistoryService = smsHistoryService;
        _dbContext = dbContext;
        _userService = userService;
    }

    public async ValueTask<FuncResult<bool>> SendAsync(
        SmsNotificationRequest request,
        NotificationTemplateType templateType,
        Dictionary<string, string> variables,
        CancellationToken cancellationToken = default)
    {
        var sendNotificationRequest = async () =>
        {
            var message = _mapper.Map<SmsMessage>(request);

            // get users
            // set receiver phone number and sender phone number
            var senderUser =
                (await _userService.GetByIdAsync(request.SenderUserId!.Value, cancellationToken: cancellationToken))!;

            var receiverUser =
                (await _userService.GetByIdAsync(request.ReceiverUserId, cancellationToken: cancellationToken))!;

            message.SenderPhoneNumber = senderUser.PhoneNumber;
            message.ReceiverPhoneNumber = receiverUser.PhoneNumber;

            // get template
            message.Template =
                await _smsTemplateService.GetByTypeAsync(request.TemplateType, true, cancellationToken) ??
                throw new InvalidOperationException(
                    $"Invalid template for sending {NotificationType.Sms} notification");

            // blogs.Comments.Add(new Comment { Title = "My comment" });

            // render template
            await _smsRenderingService.RenderAsync(message, cancellationToken);

            // send message
            await _smsSenderService.SendAsync(message, cancellationToken);

            // save history

            var history = _mapper.Map<SmsHistory>(message);
            var test = _dbContext.Entry(history.Template).State;

            await _smsHistoryService.CreateAsync(history, cancellationToken: cancellationToken);

            return history.IsSuccessful;
        };

        return await sendNotificationRequest.GetValueAsync();
    }

    public string GetTemplate(NotificationTemplateType templateType)
    {
        var temaplete = templateType switch
        {
            NotificationTemplateType.SystemWelcomeNotification => "Welcome tu the system {{Username}}",
            NotificationTemplateType.EmailVerificationNotification => "Verify your Email bu linking {{Verifiaction link :}}",
            _ => throw new ArgumentException(nameof(templateType)),
        };
        return temaplete;
    }

    public string GetMessage(string template, Dictionary<string, string> variables)
    {
        var messageBulider = new StringBuilder(template);

        var pattern = @"\{\{([^\{\}]+)\}\}";
        var matchValuePattern = "{{(.*?)}}";
        var matchs = Regex.Matches(template, pattern)
        .Select(match =>
         {
             var placeholder = match.Value;
             var placeholderValue = Regex.Match(placeholder, matchValuePattern).Groups[1].Value;
             var valid = variables.TryGetValue(placeholderValue, out var value);
             return new
             {
                 Placeholder = placeholder,
                 Value = value,
                 IsValid = valid
             };

         });
        foreach (var match in matchs)
            messageBulider.Replace(match.Placeholder, match.Value);
        var massage = messageBulider.ToString();
        return massage;
    }
}



