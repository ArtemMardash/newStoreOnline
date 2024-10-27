using SharedKernal;
using Shipments.Application.Order.Dtos;

namespace Shipments.Application.Order.Interfaces;

public interface IOrderUpdatedUseCase
{
    /// <summary>
    /// Order updated use case
    /// </summary>
    Task ExecuteAsync(OrderUpdatedDto orderUpdated, CancellationToken cancellationToken);
}