using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Users.Application.Interfaces;

namespace Users.Persistence;

public static class DependencyInjection
{
    public static void RegisterPersistence(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<UserContext>(opt =>
        {
            opt.UseNpgsql(connectionString,
                builder => builder.MigrationsAssembly(typeof(UserContext).Assembly.GetName().Name));
        });
    }
}