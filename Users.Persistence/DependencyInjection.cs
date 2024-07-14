using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Users.Application.Interfaces;

namespace Users.Persistence;

public static class DependencyInjection
{
    public static void RegisterPersistence(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<Context>(opt =>
        {
            opt.UseNpgsql("Host=localHost;Port=5432;Database=Users;Username=postgres;Password=postgres",
                builder => builder.MigrationsAssembly(typeof(Context).Assembly.GetName().Name));
        });
    }
}