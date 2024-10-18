using Orders.Application.Interfaces;
using Orders.Domain.Enums;
using SharedKernal;

namespace Orders.BackgroundJobs.UseCases;

public class BillStatusChangedUseCase: IBillStatusChangedUseCase
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public BillStatusChangedUseCase(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task ExecuteAsync(IBillUpdated billUpdated, CancellationToken cancellationToken)
    {
        if (billUpdated.NewStatus != 2)
        {
            return;
        }

        var order = await _orderRepository.GetOrderByIdAsync(billUpdated.OrderId, cancellationToken);
        order.SetStatus(OrderStatus.Assembly);
        await _orderRepository.UpdateAsync(order, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}