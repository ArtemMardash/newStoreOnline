
using Billing.Infrastructure;
using Billing.Persistence;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddInfrastracture();
builder.Services.RegisterRabbitMq();
builder.Services.RegisterPersistence();

var host = builder.Build();
host.Run();