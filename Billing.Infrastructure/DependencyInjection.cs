using Billing.Infrastructure.Consumers;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Billing.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastracture(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(Billing.Application.DependencyInjection)));
    }

    public static IServiceCollection RegisterRabbitMq(this IServiceCollection services)
    {
        services.AddMassTransit(x => { x.UsingRabbitMq(); });
        return services;
    }
    
    public static IServiceCollection RegisterRabbitMqWithConsumers(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<UserCreatedConsumer>();
            x.AddConsumer<UserUpdatedConsumer>();
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.ReceiveEndpoint("UserCreated", 
                    c=>
                        c.ConfigureConsumer<UserCreatedConsumer>(context) );
                cfg.ReceiveEndpoint("UserUpdatedConsumer", c=>c.ConfigureConsumer<UserUpdatedConsumer>(context));
            });

        });
        return services;
    }
}