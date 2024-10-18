using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Shipments.Infrastructure.Order;

namespace Shipments.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(Shipments.Application.DependencyInjection)));
    }
    
    public static IServiceCollection RegisterRabbitMqWithConsumers(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<OrderUpdatedConsumer>();
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.ReceiveEndpoint("OrderUpdatedConsumer", 
                    c=>
                        c.ConfigureConsumer<OrderUpdatedConsumer>(context) );
            });

        });
        return services;
    }
}