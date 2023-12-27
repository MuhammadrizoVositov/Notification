using Sms.Infrastructure.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
await builder.ConfigureAsync();
var app = builder.Build();

await app.ConfigurAsync();
app.Run();