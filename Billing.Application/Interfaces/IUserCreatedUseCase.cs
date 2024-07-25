using Billing.Domain.Entities;

namespace Billing.Application.Interfaces;

public interface IUserCreatedUseCase
{
    public Task ExecuteAsync(User user, CancellationToken cancellationToken);
}