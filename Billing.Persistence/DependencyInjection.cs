using Billing.Application.Interfaces;
using Billing.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Billing.Persistence;

public static class DependencyInjection
{
    public static void RegisterPersistence(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<BillingContext>(opt =>
        {
            opt.UseNpgsql("Host=localHost;Port=5432;Database=Billing;Username=postgres;Password=postgres",
                builder => builder.MigrationsAssembly(typeof(BillingContext).Assembly.GetName().Name));
        });
    }
}