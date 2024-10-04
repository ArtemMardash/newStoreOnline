using SharedKernal;

namespace Billing.Application.Interfaces;

public interface IOrderUpdatedUseCase
{
    Task ExecuteAsync(IOrderUpdated orderUpdated, CancellationToken cancellationToken);
}