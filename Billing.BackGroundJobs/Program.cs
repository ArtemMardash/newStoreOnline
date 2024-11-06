using Billing.Application.Interfaces;
using Billing.BackGroundJobs.UseCases;
using Billing.Infrastructure;
using Billing.Persistence;
using Microsoft.EntityFrameworkCore;
using SharedKernal;

var builder = Host.CreateApplicationBuilder(args);
var connectionString = builder.Configuration["DbConnectionString"] ??
                      builder.Configuration.GetConnectionString("DefaultConnection");
var rabbitHost = builder.Configuration.GetConnectionString("RabbitHost");
var rabbitPort = builder.Configuration.GetConnectionString("RabbitPort");
builder.Services.AddInfrastracture();
builder.Services.RegisterRabbitMqWithConsumers(rabbitHost, rabbitPort);
builder.Services.RegisterPersistence(connectionString);
builder.Services.AddScoped<IUserCreatedUseCase, UserCreatedUseCase>();
builder.Services.AddScoped<IUserUpdatedUseCase, UserUpdatedUseCase>();
builder.Services.AddScoped<IOrderUpdatedUseCase, OrderUpdatedUseCase>();

var host = builder.Build();
using (var scope = host.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetService<BillingContext>();
    context?.Database.Migrate();
}

host.Run();