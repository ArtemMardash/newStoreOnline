using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shipments.Application.Interfaces;
using Shipments.Persistence.TransactionalOutbox;

namespace Shipments.Persistence;

public static class DependencyInjection
{
    public static void RegisterPersistence(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<OutboxRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<ShipmentsContext>(opt =>
        {
            opt.UseNpgsql(connectionString,
                builder => builder.MigrationsAssembly(typeof(ShipmentsContext).Assembly.GetName().Name));
        });
    }
}