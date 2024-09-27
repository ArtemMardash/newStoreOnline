using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Orders.Application.Interfaces;

namespace Orders.Persistence;

public static class DependencyInjection
{
    public static void RegisterPersistence(this IServiceCollection services)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<OrderContext>(opt =>
        {
            opt.UseNpgsql("Host=localHost;Port=5432;Database=Orders;Username=postgres;Password=postgres",
                builder => builder.MigrationsAssembly(typeof(OrderContext).Assembly.GetName().Name));
        });
    }
}