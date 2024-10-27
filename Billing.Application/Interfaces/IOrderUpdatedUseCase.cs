using SharedKernal;

namespace Billing.Application.Interfaces;

public interface IOrderUpdatedUseCase
{
    /// <summary>
    /// Method that change bill after updated order
    /// </summary>
    Task ExecuteAsync(IOrderUpdated orderUpdated, CancellationToken cancellationToken);
}