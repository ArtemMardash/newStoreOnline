using Order.Infrastructure;
using Orders.Application.Interfaces;
using Orders.BackgroundJobs.UseCases;
using Orders.Persistence;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration["DbConnectionString"] ??
                       builder.Configuration.GetConnectionString("DefaultConnection");
var rabbitHost = builder.Configuration.GetConnectionString("RabbitHost");
var rabbitPort = builder.Configuration.GetConnectionString("RabbitPort");
builder.Services.RegisterPersistence(connectionString);
builder.Services.AddInfrastructure();
builder.Services.RegisterRabbitMqWithConsumers(rabbitHost, rabbitPort);
builder.Services.AddScoped<IBillStatusChangedUseCase, BillStatusChangedUseCase>();
builder.Services.AddScoped<IShipmentOrderStatusChangedUseCase, ShipmentOrderStatusChangedUseCase>();

var app = builder.Build();


app.Run();