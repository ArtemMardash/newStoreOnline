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
    
    public async Task Consume(ConsumeContext<IShipmentOrderStatusChanged> context)
    {
        var message = context.Message;
        await _shipmentOrderStatusChangedUseCase.ExecuteAsync(message, CancellationToken.None);
    }
}