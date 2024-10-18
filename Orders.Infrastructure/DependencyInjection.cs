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

    public static IServiceCollection RegisterRabbitMq(this IServiceCollection services)
    {
        services.AddScoped<IBrokerPublisher, BrokerPublisher>();
        services.AddMassTransit(x => { x.UsingRabbitMq(); });
        return services;
    }

    public static IServiceCollection RegisterRabbitMqWithConsumers(this IServiceCollection services)
    {
        services.AddScoped<IBrokerPublisher, BrokerPublisher>();
        services.AddMassTransit(x =>
        {
            x.AddConsumer<BillStatusChangedConsumer>();
            x.AddConsumer<ShipmentOrderStatusChangedConsumer>();
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.ReceiveEndpoint("BillStatusChangedConsumer",
                    c =>
                        c.ConfigureConsumer<BillStatusChangedConsumer>(context));
                cfg.ReceiveEndpoint("ShipmentOrderStatusChangedConsumer",
                    c => c.ConfigureConsumer<ShipmentOrderStatusChangedConsumer>(context));
            });
        });
        return services;
    }
}