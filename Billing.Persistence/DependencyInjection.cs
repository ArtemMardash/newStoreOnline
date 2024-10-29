using Billing.Application.Interfaces;
using Billing.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Billing.Persistence;

public static class DependencyInjection
{
    public static void RegisterPersistence(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBillingRepository, BillingRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<BillingContext>(opt =>
        {
            opt.UseNpgsql(connectionString,
                builder => builder.MigrationsAssembly(typeof(BillingContext).Assembly.GetName().Name));
        });
    }
}