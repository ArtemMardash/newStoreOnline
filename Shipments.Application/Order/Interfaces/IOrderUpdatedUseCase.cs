using SharedKernal;
using Shipments.Application.Order.Dtos;

namespace Shipments.Application.Order.Interfaces;

public interface IOrderUpdatedUseCase
{
    Task ExecuteAsync(OrderUpdatedDto orderUpdated, CancellationToken cancellationToken);
}