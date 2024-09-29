using SharedKernal;

namespace Billing.Application.Interfaces;

public interface IOrderCreatedUseCase
{
    Task ExecuteAsync(IOrderCreated orderCreated, CancellationToken cancellationToken);
}