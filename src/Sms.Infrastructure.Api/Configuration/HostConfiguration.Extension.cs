using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Sms.Infrastructure.Persistanse.DataContext;
using Sms.Infrastructure.Persistanse.Repsitory;
using Sms.Infrastructure.Persistanse.Repsitory.Interface;
using Sms.Infrostucture.Infrastructure.Common.Identity.Service;
using Sms.Infrostucture.Infrastructure.Common.Notifications.Broker;
using Sms.Infrostucture.Infrastructure.Common.Service;
using Sms.Infrostucture.Infrastructure.Common.Setting;
using Sms.Infrustructure.Application.Common.Identity.Service;
using Sms.Infrustructure.Application.Common.Notification.Broker;
using Sms.Infrustructure.Application.Common.Notification.Service;
using System.Reflection;

namespace Sms.Infrastructure.Api.Configuration
{
    public static partial class HostConfiguration
    {
        private static WebApplicationBuilder AddNotificationInfrosturcture(this WebApplicationBuilder builder)
        {

            builder.Services.AddDbContext<NotificationDbContext>(option=>option.UseNpgsql(builder.Configuration.GetConnectionString("DefaoultConnection")));
            builder.Services.
                AddScoped<ISmsSenderBroker, TwilioSmsSenderBroker>();

            builder.Services
                .AddScoped<ISmsSenderService, SmsSenderService>();
            builder.Services
                .AddScoped<ISmsOrchestrationService, SmsOrchestrationService>()
                .AddScoped<INotificationAggregatorService, NotificationAggregatorService>()
                .AddScoped<ISmsTemplateService, SmsTemplateService>()
                .AddScoped<ISmsRenderingService, SmsRenderingService>()
                .AddScoped<ISmsHistoryService, SmsHistoryService>()
                ;

            builder.Services.AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IUserSettingsRepository, UserSettingsRepository>();

            builder.Services.AddScoped<IUserService, UserService>().AddScoped<IUserSettingsService, UserSettingsService>();

            builder.Services
            .Configure<TemplateRenderingSettings>(builder.Configuration.GetSection(nameof(TemplateRenderingSettings)))
            .Configure<SmtpEmailSenderSettings>(builder.Configuration.GetSection(nameof(SmtpEmailSenderSettings)))
            .Configure<TwilioSmsSenderSettings>(builder.Configuration.GetSection(nameof(TwilioSmsSenderSettings)))
            .Configure<NotificationSettings>(builder.Configuration.GetSection(nameof(NotificationSettings)));

            builder.Services.AddScoped<IEmailTemplateRepository, EmailTemplateRepository>()
            .AddScoped<ISmsTemplateRepository, SmsTemplateRepository>()
            .AddScoped<IEmailHistoryRepository, EmailHistoryRepository>()
            .AddScoped<ISmsHistoryRepository, SmsHistoryRepository>();

            // register brokers
            builder.Services.AddScoped<ISmsSenderBroker, TwilioSmsSenderBroker>()
                .AddScoped<IEmailSenderBroker, SmtpEmailSenderBroker>();

            // register data access foundation services
            builder.Services.AddScoped<ISmsTemplateService, SmsTemplateService>()
                .AddScoped<IEmailTemplateService, EmailTemplateService>()
                .AddScoped<IEmailHistoryService, EmailHistoryService>()
                .AddScoped<ISmsHistoryService, SmsHistoryService>();

            // register helper foundation services
            builder.Services.AddScoped<IEmailSenderService, EmailSenderService>()
                .AddScoped<ISmsSenderService, SmsSenderService>()
                .AddScoped<IEmailRenderingService, EmailRenderingService>()
                .AddScoped<ISmsRenderingService, SmsRenderingService>();

            // register orchestration and aggregation services
            builder.Services.AddScoped<ISmsOrchestrationService, SmsOrchestrationService>()
                .AddScoped<IEmailOrchestrationService, EmailOrchestrationService>()
                .AddScoped<INotificationAggregatorService, NotificationAggregatorService>();

            return builder;
        }
        private static WebApplicationBuilder AddMappers(this WebApplicationBuilder builder)
        {
            var assambles = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
            assambles.Add(Assembly.GetExecutingAssembly());
            builder.Services.AddAutoMapper(assambles);
            builder.Services.AddValidatorsFromAssemblies(assambles);

            return builder;
        }
        private static WebApplicationBuilder AddExposes(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer()
                .AddSwaggerGen();



            builder.Services.AddRouting(option => option.LowercaseUrls = true);
            builder.Services.AddControllers();
            return builder;
        }
        private static WebApplication UseExposes(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapControllers();
            return app;
        }
    }
}