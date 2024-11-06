using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Users.Application.Interfaces;
using Users.Domain.Entities;

namespace Users.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastracture(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(Users.Application.DependencyInjection)));
    }

    public static IServiceCollection RegisterRabbitMq(this IServiceCollection services, string rabbitPort, string rabbitHost)
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
        //services.AddMassTransit(x => { x.UsingRabbitMq(); });
        return services;
    }
}