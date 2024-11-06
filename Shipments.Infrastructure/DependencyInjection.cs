using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Shipments.Infrastructure.Order;

namespace Shipments.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblyContaining(typeof(Shipments.Application.DependencyInjection)));
    }

    public static IServiceCollection RegisterRabbitMqWithConsumers(this IServiceCollection services, string rabbitHost,
        string rabbitPort)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<OrderUpdatedConsumer>();
            x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host($"rabbitmq://{rabbitHost}", handler =>
                {
                    handler.Username("guest");
                    handler.Password("guest");
                });
                cfg.ReceiveEndpoint("OrderUpdatedConsumer",
                    c =>
                        c.ConfigureConsumer<OrderUpdatedConsumer>(provider));
            }));
        });
        return services;
    }
}