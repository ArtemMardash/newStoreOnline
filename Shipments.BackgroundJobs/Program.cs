using Shipments.Application.Order.Interfaces;
using Shipments.BackgroundJobs.Order.OrderUpdated;
using Shipments.BackgroundJobs.Shipment;
using Shipments.Infrastructure;
using Shipments.Persistence;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration["DbConnectionString"] ??
                       builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.RegisterRabbitMqWithConsumers();
builder.Services.AddScoped<IOrderUpdatedUseCase, OrderUpdatedUseCase>();
builder.Services.RegisterPersistence(connectionString);
builder.Services.AddHostedService<ShipmentWorker>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();