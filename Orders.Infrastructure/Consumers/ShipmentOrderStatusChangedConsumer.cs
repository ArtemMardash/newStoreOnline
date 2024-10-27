using MassTransit;
using Orders.Application.Interfaces;
using SharedKernal;

namespace Order.Infrastructure.Consumers;

public class ShipmentOrderStatusChangedConsumer: IConsumer<IShipmentOrderStatusChanged>
{
    private readonly IShipmentOrderStatusChangedUseCase _shipmentOrderStatusChangedUseCase;

    public ShipmentOrderStatusChangedConsumer(IShipmentOrderStatusChangedUseCase shipmentOrderStatusChangedUseCase)
    {
        _shipmentOrderStatusChangedUseCase = shipmentOrderStatusChangedUseCase;
    }
    
    /// <summary>
    /// Method to consume message about changed status from shipment
    /// </summary>
    public async Task Consume(ConsumeContext<IShipmentOrderStatusChanged> context)
    {
        var message = context.Message;
        await _shipmentOrderStatusChangedUseCase.ExecuteAsync(message, CancellationToken.None);
    }
}