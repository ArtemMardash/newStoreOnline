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
}