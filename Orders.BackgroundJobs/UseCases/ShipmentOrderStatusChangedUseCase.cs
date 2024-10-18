using Orders.Application.Interfaces;
using Orders.Domain.Enums;
using SharedKernal;

namespace Orders.BackgroundJobs.UseCases;

public class ShipmentOrderStatusChangedUseCase: IShipmentOrderStatusChangedUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOrderRepository _orderRepository;

    public ShipmentOrderStatusChangedUseCase(IUnitOfWork unitOfWork, IOrderRepository orderRepository)
    {
        _unitOfWork = unitOfWork;
        _orderRepository = orderRepository;
    }
    
    public async Task ExecuteAsync(IShipmentOrderStatusChanged shipmentOrderStatusChanged, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetOrderByIdAsync(shipmentOrderStatusChanged.OrderId, cancellationToken);
        order.SetStatus((OrderStatus) shipmentOrderStatusChanged.OrderStatus);
        await _orderRepository.UpdateAsync(order, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}