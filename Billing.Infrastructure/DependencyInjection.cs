using Billing.Infrastructure.Consumers;
using Billing.Infrastructure.Notifications;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Billing.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastracture(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblyContaining(typeof(Billing.Application.DependencyInjection)));
        services.AddSingleton<IServiceNotificationSender, ServiceNotificationSender>();
    }

    public static IServiceCollection RegisterRabbitMq(this IServiceCollection services, string rabbitHost,
        string rabbitPort)
    {
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
        services.AddMassTransit(x =>
        {
            x.AddConsumer<UserCreatedConsumer>();
            x.AddConsumer<UserUpdatedConsumer>();
            x.AddConsumer<OrderUpdatedConsumer>();
            x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host($"rabbitmq://{rabbitHost}", handler =>
                {
                    handler.Username("guest");
                    handler.Password("guest");
                });
                cfg.ReceiveEndpoint("UserCreated",
                    c =>
                        c.ConfigureConsumer<UserCreatedConsumer>(provider));
                cfg.ReceiveEndpoint("UserUpdatedConsumer", c =>
                    c.ConfigureConsumer<UserUpdatedConsumer>(provider));
                cfg.ReceiveEndpoint("OrderUpdatedConsumer", c =>
                    c.ConfigureConsumer<OrderUpdatedConsumer>(provider));
            }));
        });
        return services;
    }
}