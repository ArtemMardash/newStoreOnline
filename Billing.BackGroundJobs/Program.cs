
using Billing.Application;
using Billing.Infrastructure;
using Billing.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.RegisterRabbitMq();
builder.Services.RegisterPersistence();
builder.Services.RegisterUseCases();
builder.Services.AddInfrastracture();

var host = builder.Build();
using (var scope = host.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetService<BillingContext>();
    context?.Database.Migrate();
}
host.Run();