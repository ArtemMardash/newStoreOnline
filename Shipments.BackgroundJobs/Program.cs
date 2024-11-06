using Shipments.Application.Order.Interfaces;
using Shipments.BackgroundJobs.Order.OrderUpdated;
using Shipments.BackgroundJobs.Shipment;
using Shipments.Infrastructure;
using Shipments.Persistence;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration["DbConnectionString"] ??
                       builder.Configuration.GetConnectionString("DefaultConnection");
var rabbitHost = builder.Configuration.GetConnectionString("RabbitHost");
var rabbitPort = builder.Configuration.GetConnectionString("RabbitPort");
builder.Services.RegisterPersistence(connectionString);
builder.Services.AddInfrastructure();
builder.Services.RegisterRabbitMqWithConsumers(rabbitHost, rabbitPort);
builder.Services.AddScoped<IOrderUpdatedUseCase, OrderUpdatedUseCase>();
builder.Services.AddHostedService<ShipmentWorker>();
var app = builder.Build();


app.Run();