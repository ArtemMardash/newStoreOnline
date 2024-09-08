using Billing.Domain.Entities;

namespace Billing.Application.Interfaces;

public interface IUserRepository
{
    /// <summary>
    /// Method to add user
    /// </summary>
    Task AddAsync(User user, CancellationToken cancellationToken);

    /// <summary>
    /// Method to update user
    /// </summary>
    Task UpdateAsync(User updatedUser, CancellationToken cancellationToken);
}