using Catalog.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Persistence;

public static class DependencyInjection
{
    public static void RegisterPersistence(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<ProductContext>(opt =>
        {
            opt.UseNpgsql("Host=localHost;Port=5432;Database=Products;Username=postgres;Password=postgres",
                builder => builder.MigrationsAssembly(typeof(ProductContext).Assembly.GetName().Name));
        });
    }
}