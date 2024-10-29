using Catalog.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Catalog.Persistence;

public static class DependencyInjection
{
    public static void RegisterPersistence(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<CatalogContext>(opt =>
        {
            opt.UseNpgsql(connectionString,
                builder => builder.MigrationsAssembly(typeof(CatalogContext).Assembly.GetName().Name));
        });
    }
}