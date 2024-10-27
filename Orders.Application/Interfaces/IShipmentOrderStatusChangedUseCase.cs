using SharedKernal;

namespace Orders.Application.Interfaces;

public interface IShipmentOrderStatusChangedUseCase
{
    /// <summary>
    /// Method that processes a message from shipment when status updated
    /// </summary>
    Task ExecuteAsync(IShipmentOrderStatusChanged shipmentOrderStatusChanged, CancellationToken cancellationToken);
}