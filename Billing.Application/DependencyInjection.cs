using Billing.Application.Interfaces;
using Billing.Application.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Billing.Application;

public static class DependencyInjection
{
    public static void RegisterUseCases(this IServiceCollection services)
    {
        services.AddScoped<IUserCreatedUseCase, UserCreatedUseCase>();
        services.AddScoped<IUserUpdatedUseCase, UserUpdatedUseCase>();
        
    }
}