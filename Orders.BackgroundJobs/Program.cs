using Order.Infrastructure;
using Order.Infrastructure.Consumers;
using Orders.Application.Interfaces;
using Orders.BackgroundJobs.UseCases;
using Orders.Persistence;
using SharedKernal;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterPersistence();
builder.Services.AddInfrastructure();
builder.Services.RegisterRabbitMqWithConsumers();
builder.Services.AddScoped<IBillStatusChangedUseCase, BillStatusChangedUseCase>();
builder.Services.AddScoped<IShipmentOrderStatusChangedUseCase, ShipmentOrderStatusChangedUseCase>();

var app = builder.Build();


app.Run();