namespace Sms.Infrastructure.Api.Configuration
{
    public static partial class HostConfiguration
    {
        public static ValueTask<WebApplicationBuilder>ConfigureAsync(this WebApplicationBuilder builder) 
        {
            builder.AddNotificationInfrosturcture()
                .AddMappers()
                   .AddExposes();
            return new  (builder);
        }
        public static ValueTask<WebApplication>ConfigurAsync(this WebApplication app)
        {
            app.UseExposes();
            return new(app);
        }
    }
   
}
