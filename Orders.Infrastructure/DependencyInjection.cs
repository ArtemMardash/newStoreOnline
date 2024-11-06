using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Order.Infrastructure.Consumers;
using Orders.Application.Interfaces;

namespace Order.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblyContaining(typeof(Orders.Application.DependencyInjection)));
    }

    public static IServiceCollection RegisterRabbitMq(this IServiceCollection services, string rabbitHost,
        string rabbitPort)
    {
        services.AddScoped<IBrokerPublisher, BrokerPublisher>();
        services.AddMassTransit(x =>
        {
            x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host($"rabbitmq://{rabbitHost}", handler =>
                {
                    handler.Username("guest");
                    handler.Password("guest");
                });
            }));
        });
        return services;
    }

    public static IServiceCollection RegisterRabbitMqWithConsumers(this IServiceCollection services, string rabbitHost,
        string rabbitPort)
    {
        services.AddScoped<IBrokerPublisher, BrokerPublisher>();
        services.AddMassTransit(x =>
        {
            x.AddConsumer<BillStatusChangedConsumer>();
            x.AddConsumer<ShipmentOrderStatusChangedConsumer>();
            x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq((cfg) =>
            {
                cfg.Host($"rabbitmq://{rabbitHost}", handler =>
                {
                    handler.Username("guest");
                    handler.Password("guest");
                });
                cfg.ReceiveEndpoint("BillStatusChangedConsumer",
                    c =>
                        c.ConfigureConsumer<BillStatusChangedConsumer>(provider));
                cfg.ReceiveEndpoint("ShipmentOrderStatusChangedConsumer",
                    c => c.ConfigureConsumer<ShipmentOrderStatusChangedConsumer>(provider));
            }));
        });
        return services;
    }
}