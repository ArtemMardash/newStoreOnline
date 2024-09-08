using Billing.Domain.Entities;

namespace Billing.Application.Interfaces;

public interface IUserCreatedUseCase
{
    /// <summary>
    /// Create user
    /// </summary>
    public Task ExecuteAsync(User user, CancellationToken cancellationToken);
}