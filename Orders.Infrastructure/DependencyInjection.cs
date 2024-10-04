using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Orders.Application.Interfaces;

namespace Order.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastracture(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(Orders.Application.DependencyInjection)));
    }
    
    public static IServiceCollection RegisterRabbitMq(this IServiceCollection services)
    {
        services.AddScoped<IBrokerPublisher, BrokerPublisher>();
        services.AddMassTransit(x => { x.UsingRabbitMq(); });
        return services;
    }
}