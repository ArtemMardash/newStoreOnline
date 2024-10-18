using SharedKernal;

namespace Orders.Application.Interfaces;

public interface IShipmentOrderStatusChangedUseCase
{
    Task ExecuteAsync(IShipmentOrderStatusChanged shipmentOrderStatusChanged, CancellationToken cancellationToken);
}