using Billing.Domain.Entities;

namespace Billing.Application.Interfaces;

public interface IUserRepository
{
    public Task SaveAsync(User user, CancellationToken cancellationToken);
}