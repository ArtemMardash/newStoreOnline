using Billing.Domain.Entities;

namespace Billing.Application.Interfaces;

public interface IUserUpdatedUseCase
{
    /// <summary>
    /// Update User
    /// </summary>
    Task ExecuteAsync(User updatedUser,CancellationToken cancellationToken);
}