using Billing.Application.Interfaces;
using Billing.BackGroundJobs.UseCases;
using Billing.Infrastructure;
using Billing.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.RegisterRabbitMq();
builder.Services.RegisterPersistence();
builder.Services.AddInfrastracture();
builder.Services.AddScoped<IUserCreatedUseCase, UserCreatedUseCase>();
builder.Services.AddScoped<IUserUpdatedUseCase, UserUpdatedUseCase>();

var host = builder.Build();
using (var scope = host.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetService<BillingContext>();
    context?.Database.Migrate();
}

host.Run();