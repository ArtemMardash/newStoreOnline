using Common.Enums;
using Orders.Application.Interfaces;

namespace Orders.BackgroundJobs.UseCases;

public class OrderStatusToDeliveryServicesUseCase: IOrderStatusToDeliveryServicesUseCase
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public OrderStatusToDeliveryServicesUseCase(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
    }
    
    /// <summary>
    /// Method to set status from Assembly to TransferredDeliveryServices
    /// </summary>
    public async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetOrdersWithStatusAssemblyAsync(cancellationToken);
        orders.ForEach(o=>
        {
            o.SetStatus(OrderStatus.TransferredDeliveryService);
            _orderRepository.UpdateAsync(o, cancellationToken);
        });
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}